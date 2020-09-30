using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SeniorProject.Models
{
    public class Researcher
    {
        
        public int ID { get; set; }

        [Required]
        [DisplayName("Reseacher Name")]
        public String reseacherName { get; set; }

        [DisplayName("Tasks")]
        [DataType(DataType.MultilineText)]
        public String tasks { get; set; }

        public virtual ICollection<ProjectResearcher> ProjectResearchers { get; set; }
    }
}
