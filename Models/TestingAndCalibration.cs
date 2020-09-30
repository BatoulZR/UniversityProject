using SeniorProject.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SeniorProject.Models
{
    public class TestingAndCalibration
    {
        public int ID { get; set; }

        [ForeignKey("machine ID")]
        public int machineId { get; set; }
        public virtual Machine machine { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }

        public virtual AppUser User { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime date { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime nextCheck { get; set; }
      

        [ForeignKey("LabDayId")]
        public int LabDayId { get; set; }

        public virtual LabDay LabDay { get; set; }
    }
}
