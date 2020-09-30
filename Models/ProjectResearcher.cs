using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SeniorProject.Models
{
    public class ProjectResearcher
    {

        public int ID { get; set; }
        [ForeignKey("projectId")]
        public int projectId { get; set; }
        [ForeignKey("researcherId")]
        public int researcherId { get; set; }

        public virtual Project Project { get; set; }
        public virtual Researcher Researcher { get; set; }
    }
}
