using Nov4thYr_Project.Models;
using Stripe;
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
            //var stripePublishKey = ConfigurationManager.AppSettings["pk_test_23F5QsiVh2SushbfKrDhIyVQ"];
            //ViewBag.StripePublishKey = stripePublishKey;

            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult Charge()
        {
            ViewBag.Message = "Learn how to process payments with Stripe";
            return View(new StripeChargeModel());
        }

        



        //public ActionResult Charge(string stripeEmail, string stripeToken)
        //{
        //    var customers = new StripeCustomerService();
        //    var charges = new StripeChargeService();

        //    var customer = customers.Create(new StripeCustomerCreateOptions
        //    {
        //        Email = stripeEmail,
        //        SourceToken = stripeToken
        //    });

        //    var charge = charges.Create(new StripeChargeCreateOptions
        //    {
        //        Amount = 500,//charge in cents
        //        Description = "Sample Charge",
        //        Currency = "usd",
        //        CustomerId = customer.Id
        //    });

        //    // further application specific code goes here

        //    return View();
        //}
    }
}