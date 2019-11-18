using Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Location
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Item ItemRequiredEntry { get; set; }
        public Quest QuestHere { get; set; }
        public Enemy EnemyHere { get; set; }
        public Lootable LootableHere { get; set; }
        public int NumberEnemy { get; set; }
        public List<EnvironmentalObject> LocationEnvironment { get; set; }


        public Location LocationNorth { get; set; }
        public Location LocationEast { get; set; }
        public Location LocationSouth { get; set; }
        public Location LocationWest { get; set; }

        public Location LocationOutside { get; set; }
        public Location LocationInside { get; set; }

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
