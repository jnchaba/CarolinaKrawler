using Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class MedPack : Item
    {
        public int HealAmount { get; set; }

        public MedPack(int id, string name, string namePlural, int size, int healAmount, int dropPercentage) : base(id, name, namePlural, size, dropPercentage)
        {
            HealAmount = healAmount;
        }
    }
}
