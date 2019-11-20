using Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    /// <summary>
    /// Super class for all objects that create living non player
    /// and player objects.
    /// </summary>
    public class LivingCreature
    {
        /// <summary>
        /// Current health points of the creature.
        /// </summary>
        public int CurrentHitPoints { get; set; }

        /// <summary>
        /// Maximum health points of the creature.
        /// </summary>
        public int MaximumHitPoints { get; set; }

        /// <summary>
        /// Constructor method for creating new living creatures.
        /// </summary>
        /// <param name="currentHitPoints"> current health points. </param>
        /// <param name="maximumHitPoints"> maximum health points. </param>
        public LivingCreature(int currentHitPoints, int maximumHitPoints)
        {
            CurrentHitPoints = currentHitPoints;
            MaximumHitPoints = maximumHitPoints;
        }
    }
}
