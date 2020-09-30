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
    public class Rotation
    {
       
        public int ID { get; set; }

        [Required]
        [DisplayName("Entrance Permission")]
        public String entrancePermission { get; set; }

        [Required]
        [DisplayName("Photos And Demand Letter")]
        public String photosAndDemandLetter { get; set; }

        [Required]
        [DisplayName("Inventory")]
        public String inventory { get; set; }

        [Required]
        [DisplayName("Cafeteria Fees")]
        public String cafeteriaFees { get; set; }

        [Required]
        [DisplayName("Events And Ceremonies")]
        public String eventsAndCeremonies { get; set; }

        [Required]
        [DisplayName("Stock Updates")]
        public String stockUpdates { get; set; }

        [Required]
        [DisplayName("Ordering Consumables")]
        public String orderingConsumables { get; set; }

        [Required]
        [DisplayName("Month")]
        public String month { get; set; }

        [Required]
        [DisplayName("Year")]
        public String year { get; set; }

        [ForeignKey("LabDayId")]
        public int LabDayId { get; set; }

        public virtual LabDay LabDay { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }

        public virtual AppUser User { get; set; }


    }
}
