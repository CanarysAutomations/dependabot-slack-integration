using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace githubeventslack.Model
{
    public class Githubhook
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Alert
        {
            public int number { get; set; }
            public string state { get; set; }
            public Dependency dependency { get; set; }
            public SecurityAdvisory security_advisory { get; set; }
            public SecurityVulnerability security_vulnerability { get; set; }
            public string url { get; set; }
            public string html_url { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public object dismissed_at { get; set; }
            public object dismissed_by { get; set; }
            public object dismissed_reason { get; set; }
            public object dismissed_comment { get; set; }
            public object fixed_at { get; set; }
        }

        public class Cvss
        {
            public string vector_string { get; set; }
            public double score { get; set; }
        }

        public class Cwe
        {
            public string cwe_id { get; set; }
            public string name { get; set; }
        }

        public class Dependency
        {
            public Package package { get; set; }
            public string manifest_path { get; set; }
            public string scope { get; set; }
        }

        public class Enterprise
        {
            public int id { get; set; }
            public string slug { get; set; }
            public string name { get; set; }
            public string node_id { get; set; }
            public string avatar_url { get; set; }
            public string description { get; set; }
            public string website_url { get; set; }
            public string html_url { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
        }

        public class FirstPatchedVersion
        {
            public string identifier { get; set; }
        }

        public class Identifier
        {
            public string value { get; set; }
            public string type { get; set; }
        }

        public class License
        {
            public string key { get; set; }
            public string name { get; set; }
            public string spdx_id { get; set; }
            public string url { get; set; }
            public string node_id { get; set; }
        }

        public class Organization
        {
            public string login { get; set; }
            public int id { get; set; }
            public string node_id { get; set; }
            public string url { get; set; }
            public string repos_url { get; set; }
            public string events_url { get; set; }
            public string hooks_url { get; set; }
            public string issues_url { get; set; }
            public string members_url { get; set; }
            public string public_members_url { get; set; }
            public string avatar_url { get; set; }
            public string description { get; set; }
        }

        public class Owner
        {
            public string login { get; set; }
            public int id { get; set; }
            public string node_id { get; set; }
            public string avatar_url { get; set; }
            public string gravatar_id { get; set; }
            public string url { get; set; }
            public string html_url { get; set; }
            public string followers_url { get; set; }
            public string following_url { get; set; }
            public string gists_url { get; set; }
            public string starred_url { get; set; }
            public string subscriptions_url { get; set; }
            public string organizations_url { get; set; }
            public string repos_url { get; set; }
            public string events_url { get; set; }
            public string received_events_url { get; set; }
            public string type { get; set; }
            public bool site_admin { get; set; }
        }

        public class Package
        {
            public string ecosystem { get; set; }
            public string name { get; set; }
        }

        public class Reference
        {
            public string url { get; set; }
        }

        public class Repository
        {
            public int id { get; set; }
            public string node_id { get; set; }
            public string name { get; set; }
            public string full_name { get; set; }
            public bool @private { get; set; }
            public Owner owner { get; set; }
            public string html_url { get; set; }
            public object description { get; set; }
            public bool fork { get; set; }
            public string url { get; set; }
            public string forks_url { get; set; }
            public string keys_url { get; set; }
            public string collaborators_url { get; set; }
            public string teams_url { get; set; }
            public string hooks_url { get; set; }
            public string issue_events_url { get; set; }
            public string events_url { get; set; }
            public string assignees_url { get; set; }
            public string branches_url { get; set; }
            public string tags_url { get; set; }
            public string blobs_url { get; set; }
            public string git_tags_url { get; set; }
            public string git_refs_url { get; set; }
            public string trees_url { get; set; }
            public string statuses_url { get; set; }
            public string languages_url { get; set; }
            public string stargazers_url { get; set; }
            public string contributors_url { get; set; }
            public string subscribers_url { get; set; }
            public string subscription_url { get; set; }
            public string commits_url { get; set; }
            public string git_commits_url { get; set; }
            public string comments_url { get; set; }
            public string issue_comment_url { get; set; }
            public string contents_url { get; set; }
            public string compare_url { get; set; }
            public string merges_url { get; set; }
            public string archive_url { get; set; }
            public string downloads_url { get; set; }
            public string issues_url { get; set; }
            public string pulls_url { get; set; }
            public string milestones_url { get; set; }
            public string notifications_url { get; set; }
            public string labels_url { get; set; }
            public string releases_url { get; set; }
            public string deployments_url { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public DateTime pushed_at { get; set; }
            public string git_url { get; set; }
            public string ssh_url { get; set; }
            public string clone_url { get; set; }
            public string svn_url { get; set; }
            public object homepage { get; set; }
            public int size { get; set; }
            public int stargazers_count { get; set; }
            public int watchers_count { get; set; }
            public string language { get; set; }
            public bool has_issues { get; set; }
            public bool has_projects { get; set; }
            public bool has_downloads { get; set; }
            public bool has_wiki { get; set; }
            public bool has_pages { get; set; }
            public int forks_count { get; set; }
            public object mirror_url { get; set; }
            public bool archived { get; set; }
            public bool disabled { get; set; }
            public int open_issues_count { get; set; }
            public License license { get; set; }
            public bool allow_forking { get; set; }
            public bool is_template { get; set; }
            public bool web_commit_signoff_required { get; set; }
            public List<object> topics { get; set; }
            public string visibility { get; set; }
            public int forks { get; set; }
            public int open_issues { get; set; }
            public int watchers { get; set; }
            public string default_branch { get; set; }
        }

        public class Root
        {
            public string action { get; set; }
            public Alert alert { get; set; }
            public Repository repository { get; set; }
            public Organization organization { get; set; }
            public Enterprise enterprise { get; set; }
            public Sender sender { get; set; }
        }

        public class SecurityAdvisory
        {
            public string ghsa_id { get; set; }
            public string cve_id { get; set; }
            public string summary { get; set; }
            public string description { get; set; }
            public string severity { get; set; }
            public List<Identifier> identifiers { get; set; }
            public List<Reference> references { get; set; }
            public DateTime published_at { get; set; }
            public DateTime updated_at { get; set; }
            public object withdrawn_at { get; set; }
            public List<Vulnerability> vulnerabilities { get; set; }
            public Cvss cvss { get; set; }
            public List<Cwe> cwes { get; set; }
        }

        public class SecurityVulnerability
        {
            public Package package { get; set; }
            public string severity { get; set; }
            public string vulnerable_version_range { get; set; }
            public FirstPatchedVersion first_patched_version { get; set; }
        }

        public class Sender
        {
            public string login { get; set; }
            public int id { get; set; }
            public string node_id { get; set; }
            public string avatar_url { get; set; }
            public string gravatar_id { get; set; }
            public string url { get; set; }
            public string html_url { get; set; }
            public string followers_url { get; set; }
            public string following_url { get; set; }
            public string gists_url { get; set; }
            public string starred_url { get; set; }
            public string subscriptions_url { get; set; }
            public string organizations_url { get; set; }
            public string repos_url { get; set; }
            public string events_url { get; set; }
            public string received_events_url { get; set; }
            public string type { get; set; }
            public bool site_admin { get; set; }
        }

        public class Vulnerability
        {
            public Package package { get; set; }
            public string severity { get; set; }
            public string vulnerable_version_range { get; set; }
            public FirstPatchedVersion first_patched_version { get; set; }
        }



    }
}
