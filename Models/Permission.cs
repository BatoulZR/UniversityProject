using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace SeniorProject.Models
{
    public class Permission
    {
       
        public int ID { set; get; }

        [DisplayName("Permission Type")]
        public String type { set; get; }

        [DisplayName("Name")]
        public String name { set; get; }

        [DisplayName("Phone Number")]
        public string phoneNumber { get; set; }

        [DisplayName("Email")]
        public string email { get; set; }

        [DisplayName("Supervised by")]
        public string supervised { get; set; }

        [DisplayName("Project Title")]
        public string project { get; set; }

        [DisplayName("University")]
        public string university { get; set; }

        [DisplayName("Position")]
        public string position { get; set; }

        [DisplayName("Pages Number")]
        public int PagesNumber { set; get; }

        [DisplayName("Colored")]
        public Boolean Colored { set; get; }


        [DisplayName("Borrowed Object")]
        public String BorrowedObject { set; get; }

        [DisplayName("Date")]
        [DataType(DataType.Date)]
        public DateTime Date { set; get; }

        [DisplayName("Return Date")]
        [DataType(DataType.Date)]
        public DateTime ReturnDate { set; get; }

        [DisplayName("Returned")]
        public Boolean Returned { set; get; }

        public string Work { get; set; }


        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        [DisplayName("Confirmation")]
        public Boolean confirmation { set; get; }


        [ForeignKey("LabDayId")]
        public int? LabDayId { get; set; }

        public virtual LabDay LabDay { get; set; }
    }
}
