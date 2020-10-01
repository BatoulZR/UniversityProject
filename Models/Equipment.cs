using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace SeniorProject.Models
{
    public class Equipment
    {
        public int ID { get; set; }
        [DisplayName("Type")]
        public string type { get; set; }
        [DisplayName("Name")]
        public string name { get; set; }
        [DisplayName("Weight")]
        public int? weight { get; set; }
        [DisplayName("Units")]
        public string units { get; set; }

        [DisplayName("Quantity")]
        public int? quantity { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayName("Arrival Date")]
        public DateTime arrivalDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Expiry Date")]
        public DateTime? expiryDate { get; set; }
        [DataType(DataType.MultilineText)]
        [DisplayName("Notes")]
        public string? notes { get; set; }

        [DisplayName("Room")]
        public string room { get; set; }

        public Boolean inUse { get; set; }


        public virtual ICollection<UsedEquipment> UsedEquipments { get; set; }


    }
}
