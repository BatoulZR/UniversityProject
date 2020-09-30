using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SeniorProject.Models
{
    public class Box
    {
        
        public int ID { set; get; }


        [DisplayName("Box Name")]
        public String Box_Name { set; get; }

        [DisplayName("Location")]
        public String Location { set; get; }

        
        public ICollection<Bacteria> Bacterias { get; set; }

       

    }
}
