using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SeniorProject.Models
{
    public class MeetingRoomReservation
    {
       
        public int ID { get; set; }

        

        [Required]
        [DisplayName("Date")]
        [DataType(DataType.Date)]
        public DateTime date { get; set; }

        [Required]
        [DisplayName("Starting time")]
        [DataType(DataType.Time)]
        public DateTime time1 { get; set; }

        [Required]
        [DisplayName("Ending time")]
        [DataType(DataType.Time)]
        public DateTime time2 { get; set; }


        [Required]
        [DisplayName("Objective")]
        public String objective { get; set; }

        [DataType(DataType.MultilineText)]
        [DisplayName("Summary")]
        public String summary { get; set; }

        [ForeignKey("LabDayId")]
        public int LabDayId { get; set; }

        public virtual LabDay LabDay { get; set; }

       


        public virtual ICollection<MeetingPresence> presences { get; set; }
    }
}
