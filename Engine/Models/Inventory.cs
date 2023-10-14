namespace UntitledRPG.Engine.Models
{
    public class Inventory
    {
        private List<Item> items;

        public Inventory()
        {
            items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            items.Add(item);
            Console.WriteLine($"Added {item.Name} to the inventory.");
        }

        public void RemoveItem(Item item)
        {
            items.Remove(item);
            Console.WriteLine($"Removed {item.Name} from the inventory.");
        }

        public void DisplayInventory()
        {
            Console.WriteLine("Inventory:");
            foreach (var item in items)
            {
                Console.WriteLine($"- {item.Name}: {item.Description}");
            }
        }
    }
}
