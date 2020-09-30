using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SeniorProject.Models
{
    public class UsedEquipment
    {
        
        public int ID { get; set; }


        [Required]
        [DisplayName("Quantity")]
        public int quantity { get; set; }


        [DataType(DataType.Time)]
        public DateTime from { get; set; }


        [DataType(DataType.Time)]
        public DateTime to { get; set; }


        [Required]
        [DisplayName("Experiment ID")]
        public int exId { get; set; }
        [ForeignKey("ex_id")]
        public virtual Experiment Experiment { get; set; }

        [ForeignKey("Machine ID")]
        public int machineID { get; set; }
        public virtual Machine Machine { get; set; }

        [ForeignKey("Equipment ID")]
        public int equipmentID { get; set; }
        public virtual Equipment equipment { get; set; }

      
    }
}
