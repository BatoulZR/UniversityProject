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
    public class Order
    {
        
        public int ID { get; set; }

        [Required]
        [DisplayName("Product Name")]
        public String productName { get; set; }

        [DisplayName("Supervisor Name")]
        public String supervisorName { get; set; }

    
        [DisplayName("Quantity")]
        public int quantity { get; set; }


        [Required]
        [DisplayName("Specifity Notes")]
        public String specifityNotes { get; set; }

        [DisplayName("Date of order")]
        [DataType(DataType.Date)]
        public DateTime dateOfOrder { get; set; }


        [DisplayName("Date of usage")]
        [DataType(DataType.Date)]
        public DateTime dateOfUsage { get; set; }

        public Boolean confirmed { get; set; }

        [ForeignKey("LabDayId")]
        public int LabDayId { get; set; }

        public virtual LabDay LabDay { get; set; }



        [ForeignKey("companyID")]
        public int companyID { get; set; }

        public virtual Company company { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }

        public virtual AppUser User { get; set; }

        [ForeignKey("project")]
        public int projectId { get; set; }

        public virtual Project project { get; set; }


    }
}
