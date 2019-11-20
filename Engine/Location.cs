using Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    /// <summary>
    /// Class for creating location objects.
    /// Location objects are used to create rooms that can contain:
    /// Quests, Enemies, Lootable objects.
    /// Locations can have other locations adjacent to them.
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Location ID.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Location Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Location Description.
        /// This is displayed in the main text-field and offers some
        /// environmental exposition upon entering the location.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Item object that can be set to be required in order to enter
        /// the location.
        /// </summary>
        public Item ItemRequiredEntry { get; set; }

        /// <summary>
        /// Quest object that can be set to start at this location.
        /// </summary>
        public Quest QuestHere { get; set; }

        /// <summary>
        /// Enemy object that can be set to spawn at this location.
        /// </summary>
        public Enemy EnemyHere { get; set; }

        /// <summary>
        /// Lootable/container object that can be set to exist at this
        /// location.
        /// </summary>
        public Lootable LootableHere { get; set; }

        /// <summary>
        /// Number of enemies to create at this location.
        /// </summary>
        public int NumberEnemy { get; set; }

        /// <summary>
        /// List of possible environmental objects to be at this location.
        /// </summary>
        public List<EnvironmentalObject> LocationEnvironment { get; set; }

        /// <summary>
        /// Location to the north of this location.
        /// </summary>
        public Location LocationNorth { get; set; }

        /// <summary>
        /// Location to the east of this location.
        /// </summary>
        public Location LocationEast { get; set; }

        /// <summary>
        /// Location to the south of this location.
        /// </summary>
        public Location LocationSouth { get; set; }

        /// <summary>
        /// Location to the west of this location.
        /// </summary>
        public Location LocationWest { get; set; }

        /// <summary>
        /// Location outside this location (example, outdoors a house).
        /// </summary>
        public Location LocationOutside { get; set; }

        /// <summary>
        /// Location inside this location (example, a house on a street).
        /// </summary>
        public Location LocationInside { get; set; }

        /// <summary>
        /// Constructor object for creating new locations.
        /// </summary>
        /// <param name="id"> Location ID. </param>
        /// <param name="name"> Location Name. </param>
        /// <param name="description"> Location Description. </param>
        /// <param name="numberEnemy"> Number of enemies at this location.
        /// </param>
        /// <param name="itemRequiredEntry"> Item required to enter location.
        /// </param>
        /// <param name="lootableHere"> Lootables at this location. </param>
        /// <param name="questHere"> Quests at this location. </param>
        /// <param name="enemyHere"> Enemies at this location. </param>
        public Location(int id, string name, string description, int numberEnemy,
            Item itemRequiredEntry = null,
                Lootable lootableHere = null,
                Quest questHere = null,
                    Enemy enemyHere = null)
        {
            ID = id;
            Name = name;
            Description = description;
            ItemRequiredEntry = itemRequiredEntry;
            QuestHere = questHere;
            EnemyHere = enemyHere;
            NumberEnemy = numberEnemy;
            LootableHere = lootableHere;

            LocationEnvironment = new List<EnvironmentalObject>();
        }

        /// <summary>
        /// Method for adding environmental objects to this location.
        /// </summary>
        /// <param name="objectToAdd"> The object to add. </param>
        public void AddObjectToEnvironment(Lootable objectToAdd)
        {
            foreach (EnvironmentalObject eo in LocationEnvironment)
            {
                if(eo.Details.ID == objectToAdd.ID)
                {
                    eo.Quantity++;
                    return;
                }
            }
            LocationEnvironment.Add(new EnvironmentalObject(objectToAdd, 1));
        }
    }
}
