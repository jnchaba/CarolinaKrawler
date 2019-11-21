namespace Engine
{
    /// <summary>
    /// Class for creating environmental objects that can be looted for items.
    /// </summary>
    public class EnvironmentalObject
    {

        public Lootable Details { get; set; }
        public int Quantity { get; set; }
        public EnvironmentalObject(Lootable details, int quantity)
        {
            Details = details;
            Quantity = quantity;
        }
    }
}
