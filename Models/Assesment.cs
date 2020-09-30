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
    public class Assesment
    {
        
        public int ID { get; set; }

        [ForeignKey("studentId")]
        public int studentId { get; set; }

        public virtual AppUser Student { get; set; }

        [ForeignKey("TraineeId")]
        public int TraineeId { get; set; }

        public virtual AppUser Trainee { get; set; }

       /* [DisplayName("Trainee Name")]
        public string TraineeName { get; set; }


        [DisplayName("Student Name")]
        public string StudentName { get; set; } */

        [DisplayName("Date")]
        [DataType(DataType.Date)]
        public DateTime date { get; set; }


        [DisplayName("Quality of work")]
        public int quality { get; set; }


        [DisplayName("Quantity of work")]
        public int quantity { get; set; }


        [DisplayName("Work Habits")]
        public int work_habits { get; set; }


        [DisplayName("Communication")]
        public int communication { get; set; }


        [DisplayName("Attitude")]
        public int attitude { get; set; }


        [DisplayName("Professionalism")]
        public int professionalism { get; set; }


        [DisplayName("Leadership")]
        public int leadership { get; set; }


        [ForeignKey("LabDayId")]
        public int LabDayId { get; set; }

        public virtual LabDay LabDay { get; set; }

        
    }
}
