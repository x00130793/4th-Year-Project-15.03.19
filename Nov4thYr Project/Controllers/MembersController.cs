using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nov4thYr_Project.Controllers
{
    [Authorize]
    public class MembersController : Controller
    {
        // GET: Members
        public ActionResult Index()
        {
            var stripePublishKey = ConfigurationManager.AppSettings["pk_test_23F5QsiVh2SushbfKrDhIyVQ"];
            ViewBag.StripePublishKey = stripePublishKey;
            return View();
        }
    }
}