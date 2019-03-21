using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nov4thYr_Project.Models
{
    public class DisplayAppointments
    {
        public string PatientName { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Symptoms { get; set; }
        public string Doctor { get; set; }
        public string Date { get; set; }
        public string UserId { get; set; }

        public List<DisplayAppointments> patientInfo { get; set; }

    }
}