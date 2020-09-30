using SeniorProject.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SeniorProject.Models
{
    public class Accident
    {
        
        public int ID { get; set; }


        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        
        
        public TimeSpan Time { get; set; }

        public string Type { get; set; }


        [DataType(DataType.MultilineText)]
        public string Damages { get; set; }


        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }

        public virtual AppUser User { get; set; }

        [ForeignKey("LabDayId")]
        public int LabDayId { get; set; }

        public virtual LabDay LabDay { get; set; }
    }
}
