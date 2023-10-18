using UntitledRPG.Engine.Interfaces;

namespace UntitledRPG.Models
{
    public class PlayerCharacter : Character
    {
        public PlayerCharacter(string name, string race, string characterClass, int level,
                      int experiencePoints, int gold, Inventory inventory,
                      int strength, int dexterity, int constitution,
                      int intelligence, int wisdom, int charisma, IDice dice)
            : base(name, race, characterClass, level, experiencePoints, gold, inventory,
                  strength, dexterity, constitution, intelligence, wisdom, charisma, dice)
        {
        }

        public void GainExperience(int experiencePoints)
        {
            ExperiencePoints += experiencePoints;
            Console.WriteLine($"Gained {experiencePoints} experience points! Current XP: {ExperiencePoints}");
            // Implement logic for leveling up, if necessary
        }

        public void EarnGold(int goldAmount)
        {
            Gold += goldAmount;
            Console.WriteLine($"Earned {goldAmount} gold! Current Gold: {Gold}");
        }

        public void SpendGold(int goldAmount)
        {
            if (Gold >= goldAmount)
            {
                Gold -= goldAmount;
                Console.WriteLine($"Spent {goldAmount} gold! Current Gold: {Gold}");
            }
            else
            {
                Console.WriteLine("Not enough gold to make the purchase.");
            }
        }

        // Additional methods specific to the player's actions can be added here
    }

}
