using System.Collections.Generic;

namespace Engine
{
    /// <summary>
<<<<<<< HEAD
    /// Class for creating Quests.
    /// Quests have an ID, Name, Description, and values for reward XP, 
    /// possible reward gold and/or item.
=======
    /// Class for Quest objects.
    /// Quests have an ID, Name, Description, Reward XP, Reward Gold, and
    /// Reward Items.
>>>>>>> 68c2bfe... Updated Comments
    /// </summary>
    public class Quest
    {
        /// <summary>
        /// Quest ID.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
<<<<<<< HEAD
        /// Quest Name.
=======
        /// Quest Name. This is showed in the Quest log.
>>>>>>> 68c2bfe... Updated Comments
        /// </summary>
        public string Name { get; set; }

        /// <summary>
<<<<<<< HEAD
        /// Quest Description.
=======
        /// Quest Description. This is showed in the rich text box upon
        /// picking up the quest.
>>>>>>> 68c2bfe... Updated Comments
        /// </summary>
        public string Description { get; set; }

        /// <summary>
<<<<<<< HEAD
        /// Amount of XP the quest rewards.
=======
        /// Quest Reward Experience Points. This is a mandatory property.
>>>>>>> 68c2bfe... Updated Comments
        /// </summary>
        public int RewardExperiencePoints { get; set; }

        /// <summary>
<<<<<<< HEAD
        /// Boolean value representing whether quest is completed.
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// Amount of Gold the quest rewards.
=======
        /// Quest Reward Gold. This is an optional property.
>>>>>>> 68c2bfe... Updated Comments
        /// </summary>
        public int RewardGold { get; set; }

        /// <summary>
<<<<<<< HEAD
        /// Item that the quest rewards.
=======
        /// Quest Reward Item. This is a optional property.
>>>>>>> 68c2bfe... Updated Comments
        /// </summary>
        public Item RewardItem { get; set; }

        /// <summary>
<<<<<<< HEAD
        /// List of possible items neccessary to complete the quest.
=======
        /// List representing the possible items neccessary to complete the
        /// quest.
>>>>>>> 68c2bfe... Updated Comments
        /// </summary>
        public List<QuestCompleteItem> QuestCompleteItems { get; set; }

        /// <summary>
<<<<<<< HEAD
        /// Constructor method for creating quests
        /// </summary>
        /// <param name="id"> Quest ID. </param>
        /// <param name="name"> Quest name. </param>
        /// <param name="description"> Quest description. </param>
        /// <param name="rewardGold"> Quest reward gold. </param>
        /// <param name="rewardExperiencePoints"> Quest reward XP. </param>
        public Quest(int id, string name, string description, int rewardGold, int rewardExperiencePoints, Item rewardItem)
=======
        /// Constructor 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="rewardGold"></param>
        /// <param name="rewardExperiencePoints"></param>
        public Quest(int id, string name, string description, int rewardGold,
            int rewardExperiencePoints)
>>>>>>> 68c2bfe... Updated Comments
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
