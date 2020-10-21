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
    public class Experiment
    {
        [Key]
        public int ID{ get; set; }

        [ForeignKey("Project Id")]
        public int? projectId { get; set; }

        public virtual Project project { get; set; }


        [DisplayName("Title")]
        public String Title { get; set; }

        [DisplayName("Supervisor")]
        public string Superv { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DataType(DataType.MultilineText)]
        [DisplayName("Description")]
        public string Desc { get; set; }


        public virtual ICollection<Equipment> Equipments { get; set; }

        

        public virtual ICollection<Biowaste> Biowastes { get; set; }



        [ForeignKey("LabDayId")]
        public int LabDayId { get; set; }

        public virtual LabDay LabDay { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }

        public virtual AppUser User { get; set; }
    }
}
