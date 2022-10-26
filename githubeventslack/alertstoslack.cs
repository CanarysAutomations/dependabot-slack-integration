using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using githubeventslack.Model;
using System.Net.Http;
using System.Text;
using System.Configuration;
using System.Collections.Specialized;
using System.Reflection.Emit;

namespace githubeventslack
{
    public static class alertstoslack
    {

        [FunctionName("alertstoslack")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Sending GitHub Payload to Slack function started");

            
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<Githubhook.Root>(requestBody);
            Payload payload = new Payload();
            payload.ghsa_id = data.alert.security_advisory.ghsa_id;
            payload.cve_id = data.alert.security_advisory.cve_id;
            payload.summary = data.alert.security_advisory.summary;
            payload.description = data.alert.security_advisory.description;
            payload.severity = data.alert.security_advisory.severity;
            payload.package_name = data.alert.security_vulnerability.package.name;
            payload.ecosystem = data.alert.security_vulnerability.package.ecosystem;
            payload.vulnerable_version_range = data.alert.security_vulnerability.vulnerable_version_range;
            payload.identifier = data.alert.security_vulnerability.first_patched_version.identifier;
            payload.manifest_path = data.alert.dependency.manifest_path;
            

            if (data.action =="reintroduced"||data.action =="fixed")
            {
                log.LogInformation(requestBody);
            }
            else
            {
                await SendSlackMessage(payload);
            }

            Payload  responseMessage = payload ;
            return new OkObjectResult(responseMessage);
        }
        
        public static async Task<string> SendSlackMessage(Payload payload)
        {

            
            var slackWebhookUrl = "https://hooks.slack.com/services/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";

            using (var client = new HttpClient())
            {
               
                SlackText st = new SlackText();
                st.text = $"*Package name:* {payload.package_name}  \n " +
                    $"*Vulnerability Version Range:* {payload.vulnerable_version_range} \n" +
                    $"*Patched Version:* {payload.identifier} \n " +
                    $"*Severity:* {payload.severity} \n " +
                    $"*Summary:* {payload.summary}\n" +
                    $"*Manifest URL Path:* {payload.manifest_path}";
                if(st.accessory == null|| st.accessory.type == null)
                {
                    st.accessory = new();
                    st.accessory.text = new();
                }
                st.accessory.type = "button";
                st.accessory.text.type = "plain_text";
                st.accessory.text.text = "View Advisory";
                st.accessory.text.emoji = true;
                st.accessory.style = "danger";
                st.accessory.url = $"https://github.com/advisories/{payload.ghsa_id}";



                var data = new StringContent(JsonConvert.SerializeObject(st), Encoding.UTF8, "application/json");
                HttpMethod method = HttpMethod.Post;
                var requestMessage = new HttpRequestMessage(method, slackWebhookUrl) { Content = data };
                var response = await client.SendAsync(requestMessage);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    return result;
                }
                return "error";

            }
        }

    }

    public class SlackText
    {
        public string text { get; set; }

        public Accessory accessory { get; set; }
        public class Accessory
        {
            public string type { get; set; }
            public Text text { get; set; }
            public string style { get; set; }
            public string url { get; set; }
        }

        public class Text
        {
            public string type { get; set; }
            public string text { get; set; }
            public bool emoji { get; set; }
        }
    }
}
