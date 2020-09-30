using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeniorProject.Models
{
    public class ItemGrid
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public int boxId { get; set; }

        public ItemGrid(int bacId, string name, int x, int y, int boxId)
        {
            Id = bacId;
            Name = name;
            X = x;
            Y = y;
            this.boxId = boxId;
        }

    }
}
