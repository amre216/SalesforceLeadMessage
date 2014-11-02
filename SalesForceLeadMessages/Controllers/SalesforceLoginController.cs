using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net;
using System.Configuration;
using System.Collections.Specialized;
using System.Text;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using SalesForceLeadMessages.Models;
using System.Web.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Salesforce.Common;
using Salesforce.Common.Models;

namespace SalesForceLeadMessages.Controllers
{


    public class SalesforceLoginController : Controller
    {

        private readonly string _authorizeEndpointUrl = ConfigurationSettings.AppSettings["AuthorizationEndpointUrl"];
        private readonly string _consumerKey = ConfigurationSettings.AppSettings["ConsumerKey"];
        private readonly string _consumerSeceret = ConfigurationSettings.AppSettings["ConsumerSeceret"];
        private readonly string _callbackUrl = ConfigurationSettings.AppSettings["CallbackUrl"];

        //
        // GET: /SalesforceLogin/
        public ActionResult Index()
        {
            //return "Ok";
            var url = Common.FormatAuthUrl(_authorizeEndpointUrl, ResponseTypes.Code, _consumerKey, HttpUtility.UrlEncode(_callbackUrl));

            return Redirect(url);
        }
	}
}