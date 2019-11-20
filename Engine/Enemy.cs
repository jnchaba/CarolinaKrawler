using Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    /// <summary>
    /// Class for enemy objects.
    /// Inherits from LivingCreature.cs.
    /// </summary>
    public class Enemy : LivingCreature
    {
        /// <summary>
        /// ID of enemy.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Name of enemy.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Maximum damage enemy can deal.
        /// </summary>
        public int MaximumDamage { get; set; }

        /// <summary>
        /// Amount of XP enemy rewards upon death.
        /// </summary>
        public int RewardExperiencePoints { get; set; }

        /// <summary>
        /// Amount of gold enemy rewards upon death.
        /// </summary>
        public int RewardGold { get; set; }

        /// <summary>
        /// List of possible loot items enemy can drop.
        /// </summary>
        public List<Item> LootTable { get; set; }

        /// <summary>
        /// Constructor for new enemy objects.
        /// </summary>
        /// <param name="id"> the enemy's id. </param>
        /// <param name="name"> the enemy's name. </param>
        /// <param name="maximumDamage"> the max damage the enemy can deal.
        /// </param>
        /// <param name="rewardExperiencePoints"> xp rewarded. </param>
        /// <param name="rewardGold"> gold rewarded. </param>
        /// <param name="currentHitPoints"> current HP. </param>
        /// <param name="maximumHitPoints"> max HP. </param>
        public Enemy( int id, string name, int maximumDamage,
            int rewardExperiencePoints, int rewardGold, int currentHitPoints,
            int maximumHitPoints) : base(currentHitPoints, maximumHitPoints)
        {
            ID = id;
            Name = name;
            MaximumDamage = maximumDamage;
            RewardExperiencePoints = rewardExperiencePoints;
            RewardGold = rewardGold;

            LootTable = new List<Item>();
        }

        /// <summary>
        /// Method for adding items to the enemy's loot table.
        /// </summary>
        /// <param name="item"> item to add. </param>
        public void addLoot(Item item)
        {
            LootTable.Add(item);
        }
    }
}
