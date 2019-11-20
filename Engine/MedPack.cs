using Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    /// <summary>
    /// Class representing medical items that can restore a player's HP.
    ///
    /// Extends the item class.
    /// </summary>
    public class MedPack : Item
    {
        /// <summary>
        /// Integer value representing how much HP to heal on use.
        /// </summary>
        public int HealAmount { get; set; }

        /// <summary>
        /// Constructor object for creating medical items.
        /// </summary>
        /// <param name="id"> MedPack ID. </param>
        /// <param name="name"> MedPack Name. </param>
        /// <param name="namePlural"> MedPack Name in plural form. </param>
        /// <param name="size"> MedPack size. </param>
        /// <param name="healAmount"> MedPack heal amount. </param>
        /// <param name="dropPercentage">MedPack drop percentage. </param>
        public MedPack(int id, string name, string namePlural, int size, int healAmount, int dropPercentage) : base(id, name, namePlural, size, dropPercentage)
        {
            HealAmount = healAmount;
        }
    }
}
