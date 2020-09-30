using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SeniorProject.Models
{
    public class Biowaste
    {
        public int ID { set; get; }


        [ForeignKey("CompId")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }


        [DisplayName("Box Number")]
        public int Boxnum { set; get; }

        [DisplayName("Weight")]
        public int weight { set; get; }

        [DisplayName("Date")]
        [DataType(DataType.Date)]
        public DateTime date { get; set; }


        [ForeignKey("ExperimentId")]
        public int ExperimentId { get; set; }

        public virtual Experiment Experiment{ get; set; }
    }
}
