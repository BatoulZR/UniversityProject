using Microsoft.AspNetCore.Identity;
using SeniorProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SeniorProject.Data
{
    public class AppUser: IdentityUser<int>
    {
        [DisplayName("First Name")]
        public string firstName { get; set; }

        [DisplayName("Last Name")]
        public string lastName { get; set; }



        public Boolean AdminConfirmation { set; get; }
       
        [NotMapped]
        public string role { set; get; }
        public virtual ICollection<Attendance> Attendances { get; set; }

        public virtual ICollection<Assesment> AssesmentStudents { get; set; }

        public virtual ICollection<Assesment> AssesmentTrainees { get; set; }

        public virtual ICollection<Form> Forms { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }

        public virtual ICollection<Collaboration> Collaborations { get; set; }

        public virtual ICollection<Project> Projects { get; set; }


        public virtual ICollection<Order> Orders { get; set; }


        public virtual ICollection<Experiment> Experiments { get; set; }

        public virtual ICollection<TestingAndCalibration> TestingAndCalibrations { get; set; }
        public virtual ICollection<MeetingRoomReservation> MeetingRoomReservations { get; set; }

        public virtual ICollection<MeetingPresence> MeetingPresences { get; set; }
        public virtual ICollection<Accident> Accidents { get; set; }

        public virtual ICollection<Rotation> Rotations { get; set; }
    


    }
}
