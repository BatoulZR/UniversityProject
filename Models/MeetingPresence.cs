using SeniorProject.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SeniorProject.Models
{
    public class MeetingPresence
    {
      
        public int ID { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }

        public virtual AppUser User { get; set; }


        [DisplayName("Name")]
        public String name { get; set; }

        
        [DisplayName("MeetingRR ID")]
        public int mrrId { get; set; }


        [ForeignKey("mrrId")]
        public virtual MeetingRoomReservation meetingRR { get; set; }
    }
}
