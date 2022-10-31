using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace githubeventslack.Model
{
    public class Payload
    {
        public string ghsa_id { get; set; }
        public string cve_id { get; set; }
        public string summary { get; set; }
        public string description { get; set; }
        public string severity { get; set; }
        public string ecosystem { get; set; }
        public string package_name { get; set; }
        public string vulnerable_version_range { get; set; }
        public string identifier { get; set; }
        public string manifest_path { get; set; }
        public string repository { get; set; }
        

    }
}
