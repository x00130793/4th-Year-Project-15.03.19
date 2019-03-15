using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nov4thYr_Project.Models;

namespace Nov4thYr_Project.Controllers
{
    public class AppointmentController : Controller
    {
        Event1 e1 = new Event1();

        // GET: Appointment
        [HttpGet]
        public ActionResult AppointmentForm(int id=0)
        {
            ////Drop down Box for doctors Functionality
            //myDataBaseAuthEntities1 dbContext = new myDataBaseAuthEntities1();
            //IEnumerable<SelectListItem> items1 = dbContext.Event1.Select(c => new SelectListItem
            //{
            //    Value = c.text,
            //    Text = c.text
            //});
            //ViewBag.Doctors = items1;
            ////Drop down ends here

            //Getting user Ids 
            //db.Items.Where(x=> x.userid == user_ID).Select(x=>x.Id).Distinct();


            //IEnumerable<SelectListItem> items2 = dbc.AspNetUserRoles.Select(u => new SelectListItem
            //{
            //    Value = u.UserId,
            //    Text = u.UserId
            //});

            myDataBaseAuthEntities2 dbc = new myDataBaseAuthEntities2();
            IEnumerable<SelectListItem> items2 = dbc.AspNetUserRoles.Where(x => x.RoleId == "e8f1347d-a369-4842-ac06-a4dee22150f1").Select(u => new SelectListItem
            {
                Value = u.UserId,
                Text = u.UserId
            });
            ViewBag.Doctors = items2;

            IEnumerable<SelectListItem> startTimes = e1.eventstart.ToString().Select(ts => new SelectListItem { Value = e1.eventstart.ToString(), Text = e1.eventstart.ToString() });
            ViewBag.StartTime = startTimes;

            IEnumerable<SelectListItem> finishTimes = e1.eventend.ToString().Select(ts => new SelectListItem { Value = e1.eventend.ToString(), Text = e1.eventend.ToString() });
            ViewBag.FinishTime = finishTimes;

            Appointment2 appointmentModel = new Appointment2();
            return View(appointmentModel);

        }

        [HttpPost]
        public ActionResult AppointmentForm(Appointment2 appointmentModel)
        {
            using (AppointmentModel2 appModel = new AppointmentModel2())
            {
                appModel.Appointment2.Add(appointmentModel);
                appModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Booking Successful.";

            //var items = e1.text.ToList();
            //if (items != null)
            //{
            //    ViewBag.data = items;
            //}

            return View("AppointmentForm", new Appointment2());
        }

        //public ActionResult docName()
        //{
        //    var items = e1.text.ToList();
        //    if (items != null)
        //    {
        //        ViewBag.data = items;
        //    }

        //    return View();
        //}
    }
}