using Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    /// <summary>
    /// Class for creating inventory items.
    /// </summary>
    public class InventoryItem
    {
        /// <summary>
        /// Item object represnting the item itself.
        /// </summary>
        public Item Details { get; set; }

        /// <summary>
        /// Quantity of items to create.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Constructor for creating inventory items.
        /// </summary>
        /// <param name="details"> Item object to create inventory item
        /// version of. </param>
        /// <param name="quantity"> Quantity of items to create. </param>
        public InventoryItem(Item details, int quantity)
        {
            Details = details;
            Quantity = quantity;
        }
    }
}
