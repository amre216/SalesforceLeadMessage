using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Net.Http;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace SalesForceLeadMessages.Models
{
    public class Lead
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }

        public async Task<List<Lead>> GetLeads(string instanceUrl, string api, string token)
        {
            List<Lead> LeadsReturn = new List<Lead>();

            HttpClient queryClient = new HttpClient();

            string query = "SELECT FirstName, LastName, Company, Email, Phone FROM Lead";

            string serviceUrl = instanceUrl + "/services/data/" + api + "/query?q=" + query;

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, serviceUrl);

            request.Headers.Add("Authorization", "Bearer " + token);
            request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage reponse = await queryClient.SendAsync(request);

            string result = reponse.Content.ReadAsStringAsync().ToString();

            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();

            List<Lead> Leads = jsSerializer.Deserialize<List<Lead>>(result);

            return LeadsReturn;
        }
    }
}