
using Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    /// <summary>
    /// Class for creating lootable container objects.
    /// </summary>
    public class Lootable
    {
        /// <summary>
        /// Lootable/container id.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Lootable/container name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Lootable/container name in plural form.
        /// </summary>
        public string NamePlural { get; set; }

        /// <summary>
        /// Lootable/container capacity.
        /// </summary>
        public int Capacity { get; set; }

        /// <summary>
        /// List representing the container/lootable's storage capacity.
        /// </summary>
        public List<Item> Contents { get; set; }

        /// <summary>
        /// Boolean value representing whether the lootable/container has
        /// been looted.
        /// </summary>
        public bool IsLooted { get; set; }

        /// <summary>
        /// Constructor method for creating lootable/container objects.
        /// </summary>
        /// <param name="id"> Lootable/container ID. </param>
        /// <param name="name"> Lootable/container name. </param>
        /// <param name="namePlural"> Lootable/container name in
        /// plural form. </param>
        /// <param name="capacity"> Lootable/container storage capacity.
        /// </param>
        /// <param name="isLooted"> Value representing whether
        /// lootable/container has been looted. </param>
        public Lootable(int id, string name, string namePlural,
            int capacity, bool isLooted)
        {
            ID = id;
            Name = name;
            NamePlural = namePlural;
            Capacity = Capacity;
            IsLooted = isLooted;

            Contents = new List<Item>();
        }

        /// <summary>
        /// Method to add item to the container.
        /// </summary>
        /// <param name="item"> Item to add. </param>
        public void addContent(Item item)
        {
            Contents.Add(item);
        }
    }
        
}
