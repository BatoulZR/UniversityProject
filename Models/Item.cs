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
    public class Item
    {

        // an item belongs to an experiment, an experiment is a part of a project
        //a photo/image attribute is needed

        public int ID { get; set; }
        [DisplayName("Type")]
        public string type { get; set; }
        [DisplayName("Name")]
        public string name { get; set; }

        public string Capacity { get; set; }

        [DisplayName("Serial Number")]
        public string serialNumber { get; set; }

        [DisplayName("LOT Number")]
        public string lotNumber { get; set; }

        [DisplayName("Weight")]
        public int? weight { get; set; }
        [DisplayName("Units")]
        public string units { get; set; }

        [DisplayName("Initial Quantity")]
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

        [DisplayName("Price")]
        public string price { get; set; }

        [DisplayName("Calibration")]
        public Boolean calibration { get; set; }

        public Boolean inUse { get; set; } = false;

        public Boolean expired { get; set; } = false;

        public Boolean remainingQuantity { get; set; } = false;

        [Required]
        [DisplayName("Quantity Used")]
        public int quantityUsed { get; set; }


        [DataType(DataType.Time)]
        public TimeSpan from { get; set; }


        [DataType(DataType.Time)]
        public TimeSpan to { get; set; }


        [Required]
        [DisplayName("Experiment ID")]
        public int exId { get; set; }
        [ForeignKey("ex_id")]
        public virtual Experiment Experiment { get; set; }

        
        public int companyId { get; set; }
        [ForeignKey("CompanyId")]
        public virtual Company company { get; set; }




    }
}
