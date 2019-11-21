namespace Engine
{
    public class QuestCompleteItem
    {
        public Item Details { get; set; }
        public int Quantity { get; set; }

        public QuestCompleteItem(Item details, int quantity)
        {
            Details = details;
            Quantity = quantity;
        }
    }
}
