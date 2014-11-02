using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Configuration;
using Newtonsoft.Json;
using Salesforce.Common;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web;
using SalesForceLeadMessages.Models;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;


namespace SalesForceLeadMessages.Controllers
{
    public class OAuthCallbackController : ApiController
    {

        private readonly string _consumerKey = ConfigurationSettings.AppSettings["ConsumerKey"];
        private readonly string _consumerSeceret = ConfigurationSettings.AppSettings["ConsumerSeceret"];
        private readonly string _callbackUrl = ConfigurationSettings.AppSettings["CallbackUrl"];
        private readonly string _tokenEndPoint = ConfigurationSettings.AppSettings["TokenRequestEndPointUrl"];

        private const string UserAgent = "forcedotcom-toolkit-dotnet";

        public async Task<HttpResponseMessage> Get(string display, string code)
        {
            //var auth = new AuthenticationClient();
            //await auth.WebServerAsync(_consumerKey, _consumerSeceret, _callbackUrl, code, _tokenEndPoint);

            //var url = string.Format("/?token={0}&api={1}&instance_url={2}", auth.AccessToken, auth.ApiVersion, auth.InstanceUrl);

            HttpClient sforceClient = new HttpClient();

            HttpContent requestContent = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                {"grant_type", "authorization_code"},
                {"client_id", _consumerKey},
                {"client_secret", _consumerSeceret},
                {"redirect_uri", _callbackUrl},
                {"code", code}
            });

            HttpResponseMessage responseMsg = await sforceClient.PostAsync(_tokenEndPoint, requestContent);

            string responseString = await responseMsg.Content.ReadAsStringAsync();

            JavaScriptSerializer js = new JavaScriptSerializer();

            var token = js.Deserialize<OauthToken>(responseString);

            JObject jObject = JObject.Parse(responseString);

            token.api_version = "v32.0";

            var url = string.Format("/?token={0}&api={1}&instance_url={2}", token.access_token, token.api_version, token.instance_url);

            var response = new HttpResponseMessage(HttpStatusCode.Redirect);
            response.Headers.Location = new Uri(url, UriKind.Relative);

            return response;
        }

    }
}
