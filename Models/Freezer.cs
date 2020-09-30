using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SeniorProject.Models
{
    public class Freezer
    {
        
        public int ID { get; set; }



        //A B C
        public string name { get; set; }

        //freezer -20 or -80
        [DisplayName("Temperature")]
        public String temperature { get; set; }

      

        [DisplayName("Name Of Consumable")]
        public String Cons { get; set; }

        [DisplayName("Box Name")]
        public String BoxName { get; set; }

        [DisplayName("Box Type")]
        public String BoxType { get; set; }

        [DisplayName("Level Number")]
        public int LevelNum { get; set; }

        [DisplayName("Side")]
        public String Side { get; set; }

        [DisplayName("Level Within Side")]
        public String LevSide { get; set; }

 


    }
}
