using System.Collections.Generic;

namespace Engine
{
    /// <summary>
    /// Class for creating the Player character.
    /// Extends LivingCreature.cs.
    /// </summary>
    public class Player : LivingCreature
    {
        /// <summary>
        /// Amount of Gold in Player's Inventory
        /// </summary>
        public int Gold { get; set; }

        /// <summary>
        /// Amount of XP that the Player has.
        /// </summary>
        public int ExperiencePoints { get; private set; }

        /// <summary>
        /// Player's current level.
        /// </summary>
        public int Level
        {
            get { return ((ExperiencePoints / 100) + 1); }
        }

        /// <summary>
        /// List representing Player's inventory. 
        /// Contains InventoryItems.
        /// </summary>
        public List<InventoryItem> Inventory { get; set; }

        /// <summary>
        /// List representing Player's Quest Log.
        /// Contains Quests.
        /// </summary>
        public List<Quest> Quests { get; set; }

        /// <summary>
        /// Player's current location.
        /// </summary>
        public Location CurrentLocation { get; set; }

        /// <summary>
        /// Constructor method for creating the Player object.
        /// This method is only called at the start of a new game.
        /// </summary>
        /// <param name="currentHitPoints"> Player's current health. </param>
        /// <param name="maximumHitPoints"> Player's maximum health. </param>
        /// <param name="gold"> Player' gold. </param>
        /// <param name="experiencePoints"> Player's experience points. </param>
        public Player(int currentHitPoints, int maximumHitPoints, int gold, int experiencePoints) : base(currentHitPoints, maximumHitPoints)
        {
            Gold = gold;
            ExperiencePoints = experiencePoints;
            Inventory = new List<InventoryItem>();
            Quests = new List<Quest>();
        }

        /// <summary>
        /// Method to check if the player has the item required to enter item-locked locations.
        /// </summary>
        /// <param name="location"> Location to check required item for. </param>
        /// <returns></returns>
        public bool HasRequiredItemToEnterThisLocation(Location location)
        {
            if (location.ItemRequiredEntry == null)
            {
                return true;
            }

            foreach (InventoryItem ii in Inventory)
            {
                if (ii.Details.ID == location.ItemRequiredEntry.ID)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Method to check if the player is at the location neccessary to complete the quest.
        /// </summary>
        /// <param name="quest"> Quest to check. </param>
        /// <returns></returns>
        public bool AtQuestDestinationToCompleteQuest(Quest quest)
        {
            foreach (Quest playerQuest in Quests)
            {
                if (playerQuest.ID == 1)
                {
                    if (CurrentLocation.ID == 2)
                    {
                        return true;
                    }

                }

            }
            return false;
        }

        /// <summary>
        /// Method to check if the player has a specific quest.
        /// </summary>
        /// <param name="quest"> Quest to check. </param>
        /// <returns></returns>
        public bool HasThisQuest(Quest quest)
        {
            foreach (Quest playerQuest in Quests)
            {
                if (playerQuest.ID == quest.ID)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Method to check if the player has completed a specific quest.
        /// </summary>
        /// <param name="quest"> Quest to check. </param>
        /// <returns></returns>
        public bool CompletedThisQuest(Quest quest)
        {
            foreach (Quest playerQuest in Quests)
            {
                if (playerQuest.ID == quest.ID)
                {
                    
                }
            }

            return false;
        }

        /// <summary>
        /// Method to check if the player has all the items to complete a specific quest.
        /// </summary>
        /// <param name="quest"> Quest to check. </param>
        /// <returns></returns>
        public bool HasAllQuestCompleteItems(Quest quest)
        {
            foreach (QuestCompleteItem qci in quest.QuestCompleteItems)
            {
                bool foundItemInPlayersInventory = false;

                foreach (InventoryItem ii in Inventory)
                {
                    if (ii.Details.ID == qci.Details.ID)
                    {
                        foundItemInPlayersInventory = true;

                        if (ii.Quantity < qci.Quantity)
                        {
                            return false;
                        }
                        break;
                    }
                }

                if (!foundItemInPlayersInventory)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Method to remove items to complete quests from the player's inventory.
        /// </summary>
        /// <param name="quest"> Quest to remove items for. </param>
        public void RemoveQuestCompleteItems(Quest quest)
        {
            foreach (QuestCompleteItem qci in quest.QuestCompleteItems)
            {
                foreach (InventoryItem ii in Inventory)
                {
                    if (ii.Details.ID == qci.Details.ID)
                    {
                        ii.Quantity -= qci.Quantity;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Method to add an item to the player's inventory.
        /// </summary>
        /// <param name="itemToAdd"> Item to add. </param>
        public void AddItemToInventory(Item itemToAdd)
        {
            foreach (InventoryItem ii in Inventory)
            {
                if (ii.Details.ID == itemToAdd.ID)
                {
                    ii.Quantity++;
                    return;
                }
            }
            Inventory.Add(new InventoryItem(itemToAdd, 1));
        }

        /// <summary>
        /// Marks the quest as complete in the player's journal.
        /// </summary>
        /// <param name="quest"></param>
        public void MarkQuestCompleted(Quest quest)
        {
            foreach (Quest pq in Quests)
            {
                if (pq.ID == quest.ID)
                {
                    pq.setComplete();
                }
            }
        }

        /// <summary>
        /// Method to add experience points to the player.
        /// </summary>
        /// <param name="experienceToAdd"> Amount of XP to add to player. </param>
        public void AddExperiencePoints(int experienceToAdd)
        {
            ExperiencePoints += experienceToAdd;
            MaximumHitPoints = (Level + 2);
        }
    }
}
