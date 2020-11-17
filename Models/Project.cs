using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SeniorProject.Models
{
    public class Project
    {
        
        public int ID { get; set; }


        [DisplayName("Project Title")]
        public String title { get; set; }

        [DisplayName("Funding Organism")]
        public String fundingorganism { get; set; }

        [Required]
        [DisplayName("Funding Duration")]
        public String fundingDuration { get; set; }

        [Required]
        [DisplayName("Fund Amount")]
        public String fundAmount { get; set; }

        [DisplayName("From")]
        [DataType(DataType.Date)]
        public DateTime from { set; get; }

        [DisplayName("To")]
        [DataType(DataType.Date)]
        public DateTime to { set; get; }

        [Required]
        [DisplayName("Reasearch Assistant Fees")]
        public Boolean reasearchAssistantFees { get; set; }

        [Required]
        [DisplayName("Congress")]
        public Boolean congress { get; set; }

        [Required]
        [DisplayName("Field Fees")]
        public Boolean fieldFees { get; set; }

        [Required]
        [DisplayName("Publication and Patent Fees")]
        public Boolean publicationAndPatentFees { get; set; }

        [Required]
        [DisplayName("Consumables")]
        public Boolean consumables { get; set; }

        [Required]
        [DisplayName("Machines and Equipements")]
        public Boolean machinesAndEquipements { get; set; }

        [Required]
        [DisplayName("Others")]
        [DataType(DataType.MultilineText)]
        public String others { get; set; }

        public Boolean? collaborationOrNot { get; set; }

        [ForeignKey("LabDayId")]
        public int? LabDayId { get; set; }

        public virtual LabDay LabDay { get; set; }


        public virtual ICollection<Experiment> Experiments { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<ProjectCollaboration> ProjectCollaborations { get; set; }
        public virtual ICollection<ProjectResearcher> ProjectResearchers { get; set; }
    }
}
