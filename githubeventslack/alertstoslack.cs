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
using System.Collections.Generic;
using System.Linq;

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
            payload.repository = data.repository.name;


            if (data.action == "fixed")
            {
                log.LogInformation(requestBody);
            }
            else
            {
                await SendSlackMessage(payload);
            }

            Payload responseMessage = payload;
            return new OkObjectResult(responseMessage);
        }

        public static async Task<string> SendSlackMessage(Payload payload)
        {


            var slackWebHookUrl = "https://hooks.slack.com/services/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";
           // var slackWebHookUrl = Environment.GetEnvironmentVariable("SLACKWEBHOOKURL");
            using (var client = new HttpClient())
            {

                SlackText.Root st = new SlackText.Root();
                SlackText.Attachment at = new SlackText.Attachment();
                at.blocks = new();

                st.attachments = new List<SlackText.Attachment>();
                SlackText.Block bl = new SlackText.Block();

                bl.type = "section";
                bl.text = new SlackText.BText();
                bl.text.type = "mrkdwn";
                bl.text.text = $"*Package Name :* {payload.package_name}  \n " +
                   $"*Vulnerability Version Range :* {payload.vulnerable_version_range} \n" +
                   $"*Patched Version :* {payload.identifier} \n " +
                   $"*Severity :* {payload.severity} \n " +
                   $"*Summary :* {payload.summary}\n" +
                   $"*Manifest_path :* {payload.manifest_path}\n" +
                   $"*Repository Name :* {payload.repository}";
                bl.accessory = new SlackText.Accessory();
                bl.accessory.type = "button";

                bl.accessory.text = new();

                bl.accessory.text.type = "plain_text";
                bl.accessory.text.text = "View Advisory";
                bl.accessory.text.emoji = true;
                bl.accessory.value = "view advisory";
                bl.accessory.url = $"https://github.com/advisories/{payload.ghsa_id}";
                bl.accessory.action_id = "button-action";
                bl.accessory.style = "danger";
                
                at.blocks.Add(bl);
                st.attachments.Add(at);

                string sa = JsonConvert.SerializeObject(st);

                var data = new StringContent(JsonConvert.SerializeObject(st), Encoding.UTF8, "application/json");
                HttpMethod method = HttpMethod.Post;
                var requestMessage = new HttpRequestMessage(method, slackWebHookUrl) { Content = data };
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
        public class Accessory
        {
            public string type { get; set; }
            public Text text { get; set; }
            public string value { get; set; }
            public string url { get; set; }
            public string action_id { get; set; }
            public string style { get; set; }
        }

        public class Attachment
        {
            public List<Block> blocks { get; set; }
        }

        public class Block
        {
            public string type { get; set; }
            public BText text { get; set; }
            public Accessory accessory { get; set; }
        }

        public class Root
        {
            public List<Attachment> attachments { get; set; }
        }

        public class Text
        {
            public string type { get; set; }
            public string text { get; set; }
            public bool emoji { get; set; }
        }
        public class BText
        {
            public string type { get; set; }
            public string text { get; set; }
        }
    }
}
