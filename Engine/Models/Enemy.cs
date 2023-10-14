using UntitledRPG.Engine.Interfaces;

namespace UntitledRPG.Engine.Models
{
    public class Enemy : Character
    {
        public Enemy(string name, string race, string characterClass, int level, int experiencePoints, int gold, Inventory inventory, int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma, IDice dice) : base(name, race, characterClass, level, experiencePoints, gold, inventory, strength, dexterity, constitution, intelligence, wisdom, charisma, dice)
        {
        }
    }
}
