using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesForceLeadMessages.Models
{
    public class OauthToken
    {
        public string id { get; set; }
        public string issued_at { get; set; }
        public string refresh_token { get; set; }
        public string instance_url { get; set; }
        public string signature { get; set; }
        public string access_token { get; set; }
        public string api_version { get; set; }
    }
}