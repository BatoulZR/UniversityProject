using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SeniorProject.Models
{
    public class Company
    {
        
        public int ID { get; set; }

        [DisplayName("Company Name")]
        public String name { get; set; }

        [DisplayName("Telephone")]
        [DataType(DataType.PhoneNumber)]
        public long num { get; set; }

        [DisplayName("Fax")]
        public String Fax { get; set; }

        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public String email { get; set; }

        [DisplayName("Address")]
        public String Address { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<Item> Items { get; set; }

        public ICollection<Biowaste> Biowastes { get; set; }
    }
}
