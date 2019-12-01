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
        /// Quest Name. This is showed in the Quest log.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Quest Description. This is showed in the rich text box upon
        /// picking up the quest.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Amount of XP the quest rewards.
        /// Quest Reward Experience Points. This is a mandatory property.
        /// </summary>
        public int RewardExperiencePoints { get; set; }

        /// <summary>
        /// Boolean value representing whether quest is completed.
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// Amount of Gold the quest rewards.
        /// Quest Reward Gold. This is an optional property.
        /// </summary>
        public int RewardGold { get; set; }

        /// <summary>
        /// Item that the quest rewards.
        /// Quest Reward Item. This is a optional property.
        /// </summary>
        public Item RewardItem { get; set; }

        /// <summary>
        /// List of possible items neccessary to complete the quest.
        /// List representing the possible items neccessary to complete the
        /// quest.
        /// </summary>
        public List<QuestCompleteItem> QuestCompleteItems { get; set; }

        /// <summary>
        /// Constructor method for creating quests
        /// <param name="id"> Quest ID. </param>
        /// <param name="name"> Quest name. </param>
        /// <param name="description"> Quest description. </param>
        /// <param name="rewardGold"> Quest reward gold. </param>
        /// <param name="rewardExperiencePoints"> Quest reward XP. </param>
        /// <param name="rewardItem"> Quest Reward Item. </param>
        /// </summary>
        public Quest(int id, string name, string description, int rewardGold,
            int rewardExperiencePoints, Item rewardItem)
        {
            ID = id;
            Name = name;
            Description = description;
            RewardExperiencePoints = rewardExperiencePoints;
            RewardGold = rewardGold;
            RewardItem = rewardItem;
            Status = false;
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

        /// <summary>
        /// Set this quest as complete.
        /// </summary>
        public void setComplete()
        {
            this.Status = true;
        }


    }
}
