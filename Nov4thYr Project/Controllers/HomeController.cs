using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DayPilot.Web.Mvc;
using DayPilot.Web.Mvc.Enums;
using DayPilot.Web.Mvc.Events.Calendar;

namespace Nov4thYr_Project.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.UserName = User.Identity.Name;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Backend()
        {
            return new Dpc().CallBack(this);
        }

        class Dpc : DayPilotCalendar
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            protected override void OnInit(InitArgs e)
            {
                Update(CallBackUpdateType.Full);
            }

            protected override void OnEventResize(EventResizeArgs e)
            {
                var toBeResized = (from ev in db.Event1s where ev.id == Convert.ToInt32(e.Id) select ev).First();
                toBeResized.eventstart = e.NewStart;
                toBeResized.eventend = e.NewEnd;
                db.SubmitChanges();
                Update();
            }

            protected override void OnEventMove(EventMoveArgs e)
            {
                var toBeResized = (from ev in db.Event1s where ev.id == Convert.ToInt32(e.Id) select ev).First();
                toBeResized.eventstart = e.NewStart;
                toBeResized.eventend = e.NewEnd;
                db.SubmitChanges();
                Update();
            }

            protected override void OnTimeRangeSelected(TimeRangeSelectedArgs e)
            {
                var toBeCreated = new Event1
                {
                    eventstart = e.Start,
                    eventend = e.End,
                    text = (string)e.Data["name"]
                };
                db.Event1s.InsertOnSubmit(toBeCreated);
                if(DataTextField == null)
                {
                    throw new Exception("Can not store empty value");
                }
                else
                {
                    db.SubmitChanges();
                    Update();
                }
                
            }

            protected override void OnFinish()
            {
                if (UpdateType == CallBackUpdateType.None)
                {
                    return;
                }

                Events = from ev in db.Event1s select ev;

                DataIdField = "id";
                DataTextField = "text";
                DataStartField = "eventstart";
                DataEndField = "eventend";
            }
        }
    }
}