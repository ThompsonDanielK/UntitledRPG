namespace UntitledRPG.Models
{
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ItemType Type { get; set; }
        public int Value { get; set; } // Value can represent different things based on item type (damage, defense, healing amount, etc.)

        public Item(string name, string description, ItemType type, int value)
        {
            Name = name;
            Description = description;
            Type = type;
            Value = value;
        }
    }

    public enum ItemType
    {
        Weapon,
        Armor,
        Potion,
        // Add more item types as needed
    }

}
