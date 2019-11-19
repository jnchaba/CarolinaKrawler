/**
 * author: Jakub Chaba
 * file: Enemy.cs
 *
 * Class for creating enemy objects.
 * Inherits from LivingCreater.cs
 */

using Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Enemy : LivingCreature
    {

        /**
         * ID for enemy object
         */
        public int ID { get; set; }

        /**
         * Name of enemy object
         */
        public string Name { get; set; }

        /**
         * Maximum amount of damage that the enemy can deal to player
         */
        public int MaximumDamage { get; set; }

        /**
         * Amount of xp that the enemy can reward upon successful defeat
         */
        public int RewardExperiencePoints { get; set; }

        /**
         * Amount of gold that enemy can reward upon successful defeat
         */
        public int RewardGold { get; set; }

        /**
         * List containing possible loot drops from enemy
         */
        public List<Item> LootTable { get; set; }

        /**
         * Constructor function - creates a new enemy object
         * 
         * @param id id of enemy
         * @param name name of enemy
         * @param maximumDamage maximum damage enemy can deal
         * @param rewardExperiencePoints xp enemy rewards on defeat
         * @param rewardGold gold enemy rewards on defeat
         * @param currentHitPoints the current health of the enemy
         * @param maximumHitPoints the maximum health of the enemy
         */
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

        /**
         * Method for adding items to the enemy's loot table
         * @param item item to add to loot table
         */
        public void addLoot(Item item)
        {
            LootTable.Add(item);
        }
    }
}
