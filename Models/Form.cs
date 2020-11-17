using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SeniorProject.Models
{
    public class Form
    {
        
        public int ID { get; set; }

        [DisplayName("Student ID")]
        public string StudentID { get; set; }

        [DisplayName("First Name")]
        public string firstname { get; set; }

        [DisplayName("Father's Name")]
        public string fathername { get; set; }

        [DisplayName("Last Name")]
        public string lastname { get; set; }


        [DisplayName("Phone Number")]
        public string phone { get; set; }

        [DisplayName("Request Type")]
        public string requestType { get; set; }

        [DisplayName("Email")]
        public string email { get; set; }

        [DisplayName("Speciality")]
        public string speciality { get; set; }

        [DisplayName("Year")]
        public string year { get; set; }

        public Boolean requestStatus { get; set; }

        [DisplayName("Date")]
        [DataType(DataType.Date)]
        public DateTime date { set; get; }

        [DisplayName("Place")]
        public string place { get; set; }

        [DisplayName("Duration")]
        public string duration { get; set; }

        [DisplayName("Content")]
        [DataType(DataType.MultilineText)]
        public string Paragraph { get; set; }


        [ForeignKey("LabDayId")]
        public int? LabDayId { get; set; }

        public virtual LabDay LabDay { get; set; }
    }
}
