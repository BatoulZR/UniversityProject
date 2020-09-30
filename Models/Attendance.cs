using SeniorProject.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SeniorProject.Models
{
    public class Attendance
    {
       
        public int ID { set; get; }

        public string type { set; get; }


        [ForeignKey("UserId")]
        public int UserId { get; set; }

        public virtual AppUser User { get; set; }


        [DisplayName("Arrival Time")]
        
        public TimeSpan? ArrivalTime { set; get; }


        [DisplayName("Leaving Time")]
        
        public TimeSpan? LeavingTime { set; get; }


        [ForeignKey("LabDayId")]
        public int LabDayId { get; set; }

        public virtual LabDay LabDay { get; set; }
    }
}
