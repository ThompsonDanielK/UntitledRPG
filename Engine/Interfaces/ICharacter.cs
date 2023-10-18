using UntitledRPG.Models;

namespace UntitledRPG.Engine.Interfaces
{
    public interface ICharacter
    {
        int Charisma { get; set; }
        string Class { get; set; }
        int Constitution { get; set; }
        int CurrentHealth { get; set; }
        int Dexterity { get; set; }
        int ExperiencePoints { get; set; }
        int Gold { get; set; }
        int Initiative { get; }
        int Intelligence { get; set; }
        Inventory Inventory { get; set; }
        int Level { get; set; }
        int MaxHealth { get; set; }
        string Name { get; set; }
        string Race { get; set; }
        int Strength { get; set; }
        int Wisdom { get; set; }

        void Attack(Character target);
        void CastSpell(string spellName, Character target);
        int GetAbilityModifier(int abilityScore);
        void Heal(int healingAmount);
        bool IsDefeated();
        void LevelUp();
        int RollInitiative();
        void TakeDamage(int damage);
    }
}