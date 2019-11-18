using Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class EnvironmentalObject
    {
        public Lootable Details { get; set; }
        public int Quantity { get; set; }

        public EnvironmentalObject(Lootable details, int quantity)
        {
            Details = details;
            Quantity = quantity;
        }
    }
}
