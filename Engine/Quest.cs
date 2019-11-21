using System.Collections.Generic;

namespace Engine
{
    /// <summary>
    /// Class for creating Quests.
    /// Quests have an ID, Name, Description, and values for reward XP, 
    /// possible reward gold and/or item.
    /// </summary>
    public class Quest
    {
        /// <summary>
        /// Quest ID.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Quest Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Quest Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Amount of XP the quest rewards.
        /// </summary>
        public int RewardExperiencePoints { get; set; }

        /// <summary>
        /// Amount of Gold the quest rewards.
        /// </summary>
        public int RewardGold { get; set; }

        /// <summary>
        /// Item that the quest rewards.
        /// </summary>
        public Item RewardItem { get; set; }

        /// <summary>
        /// List of possible items neccessary to complete the quest.
        /// </summary>
        public List<QuestCompleteItem> QuestCompleteItems { get; set; }

        /// <summary>
        /// Constructor method for creating quests
        /// </summary>
        /// <param name="id"> Quest ID. </param>
        /// <param name="name"> Quest name. </param>
        /// <param name="description"> Quest description. </param>
        /// <param name="rewardGold"> Quest reward gold. </param>
        /// <param name="rewardExperiencePoints"> Quest reward XP. </param>
        public Quest(int id, string name, string description, int rewardGold, int rewardExperiencePoints, Item rewardItem)
        {
            ID = id;
            Name = name;
            Description = description;
            RewardExperiencePoints = rewardExperiencePoints;
            RewardGold = rewardGold;
            RewardItem = rewardItem;
            QuestCompleteItems = new List<QuestCompleteItem>();
        }

        /// <summary>
        /// Method to add items required to complete the quest.
        /// </summary>
        /// <param name="questCompleteItem"> Item neccessary to complete quest. </param>
        public void addCompleteItem(QuestCompleteItem questCompleteItem)
        {
            QuestCompleteItems.Add(questCompleteItem);
        }


    }
}
