using DayPilot.Web.Mvc;
using System;
using System.Linq;
using System.Web.Mvc;
using DayPilot.Web.Mvc.Enums;
using DayPilot.Web.Mvc.Events.Calendar;
using System.Data;
using Nov4thYr_Project.Models;

namespace Nov4thYr_Project.Controllers
{
    public class DoctorsController : Controller
    {
        // GET: Doctors
        public ActionResult Index()
        {
            
            return View();
        }


    }
}