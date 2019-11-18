
using Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Lootable
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string NamePlural { get; set; }
        public int Capacity { get; set; }
        public List<Item> Contents { get; set; }
        public bool IsLooted { get; set; }

        public Lootable(int id, string name, string namePlural, int capacity, bool isLooted)
        {
            ID = id;
            Name = name;
            NamePlural = namePlural;
            Capacity = Capacity;
            IsLooted = isLooted;

            Contents = new List<Item>();
        }

        public void addContent(Item item)
        {
            Contents.Add(item);
        }
    }
        
}
