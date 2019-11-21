namespace Engine
{
    /// <summary>
    /// Class for creating items.
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Item ID.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Item Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Item Name (Plural Form).
        /// </summary>
        public string NamePlural { get; set; }

        /// <summary>
        /// Item size, represents how much capacity it takes up.
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Percentage chance of dropping the given item.
        /// </summary>
        public int DropPercentage { get; set; }

        /// <summary>
        /// Constructor for creating the item.
        /// </summary>
        /// <param name="id"> Item ID. </param>
        /// <param name="name"> Item Name. </param>
        /// <param name="namePlural"> Item Name (plural). </param>
        /// <param name="size"> Item Size. </param>
        /// <param name="dropPercentage"> Item drop % chance. </param>
        public Item(int id, string name, string namePlural,
            int size, int dropPercentage)
        {
            ID = id;
            Name = name;
            NamePlural = namePlural;
            Size = size;
            DropPercentage = dropPercentage;
        }
    }
}
