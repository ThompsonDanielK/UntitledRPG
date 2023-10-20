using UntitledRPG.Services;

namespace UntitledRPG.Models
{
    public class Character : ICharacter
    {
        public string Name { get; set; }
        public string Race { get; set; }
        public string Class { get; set; }
        public int Level { get; set; }
        public int ExperiencePoints { get; set; }
        public int Gold { get; set; }
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        public int Initiative { get; private set; }

        public Character()
        {
        }
        public Character(string name, string race, string characterClass, int level, int experiencePoints, int gold,
                            int strength, int dexterity, int constitution,
                            int intelligence, int wisdom, int charisma)
        {
            Name = name;
            Race = race;
            Class = characterClass;
            Level = level;
            ExperiencePoints = experiencePoints;
            Gold = gold;
            Strength = strength;
            Dexterity = dexterity;
            Constitution = constitution;
            Intelligence = intelligence;
            Wisdom = wisdom;
            Charisma = charisma;
        }

        public void Attack(Character target)
        {
            // Implement attack logic here
            Console.WriteLine($"{Name} attacks {target.Name}!");
            // Add logic for damage calculation and other combat mechanics
        }

        public void CastSpell(string spellName, Character target)
        {
            // Implement spell casting logic here
            Console.WriteLine($"{Name} casts {spellName} on {target.Name}!");
            // Add logic for spell effects, damage calculation, etc.
        }

        public void TakeDamage(int damage)
        {
            // Implement damage-taking logic here
            Console.WriteLine($"{Name} takes {damage} damage!");
            // Reduce character's health or apply other damage-related effects
        }

        public void Heal(int healingAmount)
        {
            // Implement healing logic here
            Console.WriteLine($"{Name} is healed for {healingAmount} points!");
            // Increase character's health or apply other healing-related effects
        }

        public void LevelUp()
        {
            // Implement level up logic here
            Level++;
            Console.WriteLine($"{Name} leveled up to level {Level}!");
            // Apply any stat bonuses or other effects upon leveling up
        }

        public bool IsDefeated()
        {
            return CurrentHealth <= 0;
        }

        public int GetAbilityModifier(int abilityScore)
        {
            return (abilityScore - 10) / 2;
        }

        //public int RollInitiative()
        //{
        //    int dexModifier = GetAbilityModifier(Dexterity);
        //    int iniativeRoll = _dice.Roll(20) + dexModifier;
        //    Initiative = iniativeRoll;

        //    Console.WriteLine($"{Name} rolled {iniativeRoll} for initiative!");
        //    return iniativeRoll;
        //}
    }
}
