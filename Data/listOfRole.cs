using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SeniorProject.Data
{
    public class listOfRole
    {
        public int userId { set; get; }


        public IEnumerable<SelectListItem> Items { get; set; } = new List<SelectListItem>
            {
                new SelectListItem {Value ="Admin", Text ="Admin"},
                 new SelectListItem {Value ="Trainee", Text ="Trainee"},
                 new SelectListItem {Value ="Admin", Text ="Admin"},
                 new SelectListItem {Value ="Admin", Text ="Admin"},
                 new SelectListItem {Value ="Admin", Text ="Admin"},
                 new SelectListItem {Value ="Admin", Text ="Admin"},

            };
    }
}
