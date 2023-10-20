using UntitledRPG.Services;

namespace UntitledRPG.Models
{
    public class Enemy : Character
    {
        public Enemy(string name, string race, string characterClass, int level, int experiencePoints, int gold, int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma) : base(name, race, characterClass, level, experiencePoints, gold, strength, dexterity, constitution, intelligence, wisdom, charisma)
        {
        }
    }
}
