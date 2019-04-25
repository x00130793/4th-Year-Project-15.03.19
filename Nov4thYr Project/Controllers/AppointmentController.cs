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

        // GET: Appointment
        [HttpGet]
        public ActionResult AppointmentForm()
        {
            ProjectDBEntities1 dbc = new ProjectDBEntities1();
            ProjectDBEntitiesSymptoms sym = new ProjectDBEntitiesSymptoms();
            DataClasses1DataContext eve = new DataClasses1DataContext();

            var doctordrop = dbc.AspNetUserRoles.Where(x => x.RoleId == "e8f1347d-a369-4842-ac06-a4dee22150f1").Select(u => new SelectListItem
            {
                Value = u.UserId,
                Text = u.UserId
            }).ToList();

            ViewBag.doctordrop = doctordrop;

            ViewBag.symptomName = sym.Symptoms.Select(n => n.Price);

            ViewBag.symptoms = sym.Symptoms.Select(s => new SelectListItem
            {
                Value = s.Symptom1,
                Text = s.Symptom1,
            }).ToList();

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

            var currentUserEmail = User.Identity.GetUserName();
            ViewBag.currEmail = currentUserEmail;

            ViewBag.iddrop = dbc.AspNetUserRoles.Where(x => x.UserId == currentUserID).Select(u => new SelectListItem
            {
                Value = u.UserId,
                Text = u.UserId
            }).ToList();

            Appointment4 appointmentModel = new Appointment4();
            return View(appointmentModel);

        }

        [HttpPost]
        public ActionResult AppointmentForm(Appointment4 appointmentModel)
        {
            ProjectDBEntities1 dbc = new ProjectDBEntities1();
            ProjectDBEntitiesSymptoms sym = new ProjectDBEntitiesSymptoms();
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

            ViewBag.symptomName = sym.Symptoms.Select(n => n.Price);

            ViewBag.symptoms = sym.Symptoms.Select(s => new SelectListItem
            {
                Value = s.Symptom1,
                Text = s.Symptom1
            }).ToList();

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

            var currentUserEmail = User.Identity.GetUserName();
            ViewBag.currEmail = currentUserEmail;

            ViewBag.iddrop = dbc.AspNetUserRoles.Where(x => x.UserId == currentUserID).Select(u => new SelectListItem
            {
                Value = u.UserId,
                Text = u.UserId
            }).ToList();

            ModelState.Clear();
            ViewBag.SuccessMessage = "Booking Successful.";
            return View("AppointmentForm", new Appointment4());
        }

    }
}