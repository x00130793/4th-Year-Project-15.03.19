using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nov4thYr_Project.Models;
using Microsoft.AspNet.Identity;

namespace Nov4thYr_Project.Controllers
{
    public class AppointmentController : Controller
    {
        //Event1 e1 = new Event1();

        // GET: Appointment
        [HttpGet]
        public ActionResult AppointmentForm()
        {
            myDataBaseAuthEntities2 dbc = new myDataBaseAuthEntities2();
            DataClasses1DataContext eve = new DataClasses1DataContext();
            //IEnumerable<SelectListItem> Doctor = dbc.AspNetUserRoles.Where(x => x.RoleId == "e8f1347d-a369-4842-ac06-a4dee22150f1").Select(u => new SelectListItem
            //{
            //    Value = u.UserId,
            //    Text = u.UserId
            //});
            //ViewBag.Doctor = Doctor;

            

            var doctordrop = dbc.AspNetUserRoles.Where(x => x.RoleId == "e8f1347d-a369-4842-ac06-a4dee22150f1").Select(u => new SelectListItem
            {
                Value = u.UserId,
                Text = u.UserId
            }).ToList();

            ViewBag.doctordrop = doctordrop;

            ViewBag.startitme = eve.Event1s.Select(t => new SelectListItem
            {
                Value = t.eventstart.ToString(),
                Text = t.eventstart.ToString()
            }).ToList();

            ViewBag.orderedTime = eve.Event1s.OrderBy(x => x.eventstart).Select(t => new SelectListItem
            {
                Value = t.eventstart.ToString(),
                Text = t.eventstart.ToString()
            }).ToList();

            var currentUserID = User.Identity.GetUserId();
            ViewBag.currID = currentUserID;

            ViewBag.iddrop = dbc.AspNetUserRoles.Where(x => x.UserId == currentUserID).Select(u => new SelectListItem
            {
                Value = u.UserId,
                Text = u.UserId
            }).ToList();

            //IEnumerable<SelectListItem> startTimes = e1.eventstart.ToString().Select(ts => new SelectListItem { Value = e1.eventstart.ToString(), Text = e1.eventstart.ToString() });
            //ViewBag.StartTime = startTimes;

            //IEnumerable<SelectListItem> finishTimes = e1.eventend.ToString().Select(ts => new SelectListItem { Value = e1.eventend.ToString(), Text = e1.eventend.ToString() });
            //ViewBag.FinishTime = finishTimes;

            Appointment4 appointmentModel = new Appointment4();
            return View(appointmentModel);

        }

        [HttpPost]
        public ActionResult AppointmentForm(Appointment4 appointmentModel)
        {
            myDataBaseAuthEntities2 dbc = new myDataBaseAuthEntities2();
            DataClasses1DataContext eve = new DataClasses1DataContext();
            using (ProjectDBEntities appModel = new ProjectDBEntities())
            {
                appModel.Appointment4.Add(appointmentModel);
                appModel.SaveChanges();
            }

            ViewBag.doctordrop = dbc.AspNetUserRoles.Where(x => x.RoleId == "e8f1347d-a369-4842-ac06-a4dee22150f1").Select(u => new SelectListItem
            {
                Value = u.UserId,
                Text = u.UserId
            }).ToList();

            //ViewBag.startitme = dbc1.Event1.Select(z => z.eventstart.ToString()).ToList();
            //ViewBag.startitme = dbc1.Event1s.Select(z => z.eventstart.ToString()).ToList();
            ViewBag.startitme = eve.Event1s.Select(t => new SelectListItem
            {
                Value = t.eventstart.ToString(),
                Text = t.eventstart.ToString()
            }).ToList();

            ViewBag.orderedTime = eve.Event1s.OrderBy(x => x.eventstart).Select(t => new SelectListItem
            {
                Value = t.eventstart.ToString(),
                Text = t.eventstart.ToString()
            }).ToList();

            var currentUserID = User.Identity.GetUserId();
            ViewBag.currID = currentUserID;

            ViewBag.iddrop = dbc.AspNetUserRoles.Where(x => x.UserId == currentUserID).Select(u => new SelectListItem
            {
                Value = u.UserId,
                Text = u.UserId
            }).ToList();
            //IEnumerable<SelectListItem> startTimes = e1.eventstart.ToString().Select(ts => new SelectListItem { Value = e1.eventstart.ToString(), Text = e1.eventstart.ToString() });
            //ViewBag.StartTime = startTimes;

            //IEnumerable<SelectListItem> finishTimes = e1.eventend.ToString().Select(ts => new SelectListItem { Value = e1.eventend.ToString(), Text = e1.eventend.ToString() });
            //ViewBag.FinishTime = finishTimes;

            //var items = e1.text.ToList();
            //if (items != null)
            //{
            //    ViewBag.data = items;
            //}

            ModelState.Clear();
            ViewBag.SuccessMessage = "Booking Successful.";
            return View("AppointmentForm", new Appointment4());
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