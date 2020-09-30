using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SeniorProject.Models
{
    public class Machine
    {
        public int ID { get; set; }

        [DisplayName("Name")]
        public string name { get; set; }

        [DisplayName("Serial Number")]
        public string serialNumber { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Arrival Date")]
        public DateTime arrivalDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Expiry Date")]
        public DateTime expiryDate { get; set; }
        [DataType(DataType.MultilineText)]
        [DisplayName("Notes")]
        public string notes { get; set; }

        [DisplayName("Room")]
        public string room { get; set; }

        public virtual ICollection<UsedEquipment> UsedEquipments { get; set; }

        [DisplayName("Calibration")]
        public Boolean calibration { get; set; }
    }
}
