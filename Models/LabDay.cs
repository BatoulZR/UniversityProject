using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SeniorProject.Models
{
    public class LabDay
    {
        public int ID { get; set; }
        [DataType(DataType.Date)]
        public DateTime date { get; set; }

        
        public TimeSpan openingTime { get; set; }

        
        public TimeSpan? closingTime { get; set; }

        //attendances
        public virtual ICollection<Attendance> Attendances { get; set; }
       

        //forms
        public virtual ICollection<Assesment> Assesments { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }
        public virtual ICollection<Form> Forms { get; set; }

        public virtual ICollection<Accident> Accidents { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Experiment> Experiments { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Collaboration> Collaborations { get; set; }
        public virtual ICollection<TestingAndCalibration> TestingAndCalibrations { get; set; }

        public virtual ICollection<MeetingRoomReservation> MeetingRoomReservations { get; set; }

  
    }
}
