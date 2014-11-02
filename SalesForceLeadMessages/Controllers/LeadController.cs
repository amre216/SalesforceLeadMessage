using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalesForceLeadMessages.Controllers
{
    public class LeadController : Controller
    {
        //
        // GET: /Lead/
        public ActionResult Index()
        {
            string gitTest = "Another git test";
            return View();
        }
	}
}