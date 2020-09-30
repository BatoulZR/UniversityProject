using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SeniorProject.Models
{
    public class Bacteria
    {
        public int ID { set; get; }

        [DisplayName("Bacteria Name")]
        public String BacteriaName { set; get; }


        public int x { set; get; }


        public int y { set; get; }

        [ForeignKey("box ID")]
        public int boxID { get; set; }

        public virtual Box box { get; set; }
    }
}
