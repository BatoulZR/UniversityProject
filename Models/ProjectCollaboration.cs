using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SeniorProject.Models
{
    public class ProjectCollaboration
    {
        public int ID { get; set; }
        [ForeignKey("project_id")]
        public int projectId { get; set; }
        [ForeignKey("collaborationId")]
        public int collaborationId { get; set; }

        public virtual Project Project { get; set; }
        public virtual Collaboration Collaboration { get; set; }
    }
}
