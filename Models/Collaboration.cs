using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SeniorProject.Models
{
    public class Collaboration
    {
      
        public int ID { get; set; }


        [DisplayName("Collaborator Name")]
        public String ColabboratorName { get; set; }

        [DisplayName("Institute")]
        public String Institute { get; set; }

        [DisplayName("Compounds")]
        public String Compounds { get; set; }

        [DisplayName("Position")]
        public String Position { get; set; }

        [DisplayName("PhD/M2/Others")]
        public String phdM2 { get; set; }

        [DisplayName("Test")]
        public String Test { get; set; }


        [ForeignKey("LabDayId")]
        public int LabDayId { get; set; }

        public virtual LabDay LabDay { get; set; }

        public virtual ICollection<ProjectCollaboration> ProjectCollaborations { get; set; }
    }
}
