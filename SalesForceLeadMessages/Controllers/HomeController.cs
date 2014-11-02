using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesForceLeadMessages.Models;


namespace SalesForceLeadMessages.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Request.QueryString.HasKeys() && Request.QueryString != null)
            {
                ViewBag.token = Request.QueryString["token"].ToString();
                ViewBag.apiVersion = Request.QueryString["api"].ToString();
                ViewBag.instanceUrl = Request.QueryString["instance_url"].ToString();
                ViewBag.LoggedIn = true;

                string test = null;

                var leads = new Lead().GetLeads(Request.QueryString["instance_url"].ToString(), Request.QueryString["api"].ToString(), Request.QueryString["token"].ToString());

            }
            else
            {
                ViewBag.LoggedIn = false;
            }

            return View();
        }

    }
}