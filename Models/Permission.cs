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

        public string Schedule { get; set; }

        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }


        [ForeignKey("LabDayId")]
        public int LabDayId { get; set; }

        public virtual LabDay LabDay { get; set; }
    }
}
