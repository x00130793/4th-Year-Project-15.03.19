using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nov4thYr_Project.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.AspNet.Identity;


namespace Nov4thYr_Project.Controllers
{
    [Authorize(Roles = "Administrator,Patient")]
    public class PatientsController : Controller
    {
        // GET: Patients
        public ActionResult Index(DisplayAppointments da)
        {
            var currentUserID = User.Identity.GetUserId();
            ViewBag.userid = currentUserID;

            string mainconn = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string s1 = "select * from [myDataBaseAuth].[dbo].[Appointment4]";
            SqlCommand sqlcomm = new SqlCommand(s1);
            sqlcomm.Connection = sqlconn;
            sqlconn.Open();
            SqlDataReader sdr = sqlcomm.ExecuteReader();
            List<DisplayAppointments> objmodel = new List<DisplayAppointments>();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    var details = new DisplayAppointments();
                    details.PatientName = sdr["PatientName"].ToString();
                    details.Gender = sdr["Gender"].ToString();
                    details.PhoneNumber = sdr["PatientPhoneNum"].ToString();
                    details.Email = sdr["Email"].ToString();
                    details.Symptoms = sdr["Symptoms"].ToString();
                    details.Doctor = sdr["Doctor"].ToString();
                    details.Date = sdr["Date"].ToString();
                    details.UserId = sdr["UserId"].ToString();
                    objmodel.Add(details);
                }
                da.patientInfo = objmodel;
                sqlconn.Close();
            }
            return View("Index", da);
        }
        


    }


}