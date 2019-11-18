using Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Weapon : Item 
    {
        public int MinmumDamage { get; set; }
        public int MaximumDamage { get; set; }
        

        public Weapon(int id, string name, string namePlural, int size, int minimumDamage, int maximumDamage, int dropPercentage) : base(id, name, namePlural, size, dropPercentage)
        {
            MinmumDamage = minimumDamage;
            MaximumDamage = maximumDamage;
        }
    }
}
