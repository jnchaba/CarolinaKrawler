namespace Engine
{
    /// <summary>
    /// Class for creating Weapon objects.
    /// Weapons extend from the Item class.
    /// </summary>
    public class Weapon : Item 
    {
        /// <summary>
        /// Integer value representing the minimum damage that the weapon
        /// can deal.
        /// </summary>
        public int MinmumDamage { get; set; }

        /// <summary>
        /// Integer value representing the maximum damage that the weapon
        /// can deal.
        /// </summary>
        public int MaximumDamage { get; set; }

        /// <summary>
        /// Constructor method for creating weapons.
        /// </summary>
        /// <param name="id"> Weapon ID. </param>
        /// <param name="name"> Weapion Name. </param>
        /// <param name="namePlural"> Weapon Name (plural form). </param>
        /// <param name="size"> Weapon Size.</param>
        /// <param name="minimumDamage"> Weapon minimum damage. </param>
        /// <param name="maximumDamage"> Weapon maximum damage. </param>
        /// <param name="dropPercentage"> Weapon drop percentage. </param>
        public Weapon(int id, string name, string namePlural, int size,
            int minimumDamage, int maximumDamage, int dropPercentage) :
            base(id, name, namePlural, size, dropPercentage)
        {
            MinmumDamage = minimumDamage;
            MaximumDamage = maximumDamage;
        }
    }
}
