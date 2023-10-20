namespace UntitledRPG.Models
{
    public class BattleManager
    {
        private List<ICharacter> turnOrder;
        private ICharacter currentCharacter;

        public BattleManager(List<PlayerCharacter> playerCharacters, List<Enemy> enemies)
        {
            // Combine the player characters and enemies into a single list
            List<ICharacter> characters = new List<ICharacter>(playerCharacters);
            characters.AddRange(enemies);

            List<ICharacter> charactersWithInitiative = CreateTurnOrder(characters);

            // Initialize the turn order queue
            turnOrder = new List<ICharacter>(charactersWithInitiative);
        }

        public void StartCombat()
        {
            //while (turnOrder.Count > 1)
            //{
            //    ICharacter currentCharacter = turnOrder.Dequeue();
            //    ICharacter target = turnOrder.Peek(); 

            //    Console.WriteLine($"It's {currentCharacter.Name}'s turn!");
            //    TakeTurn(currentCharacter, target);

            //    if (target.IsDefeated())
            //    {
            //        Console.WriteLine($"{target.Name} has been defeated!");
            //        turnOrder.Dequeue(); 
            //    }

            //    turnOrder.Enqueue(currentCharacter);
            //}

            //Console.WriteLine($"{turnOrder.Peek().Name} wins the battle!");
        }

        private void TakeTurn(ICharacter attacker, ICharacter target)
        {
            // Logic for the attacker's turn, such as attacking the target
            // You can use existing methods like attacker.Attack(target) or introduce new logic here
            // Example:
            // attacker.Attack(target);
            // target.TakeDamage(damage);
        }

        private List<ICharacter> CreateTurnOrder(List<ICharacter> characters)
        {
            // Roll for initiative for each character
            foreach (ICharacter character in characters)
            {
                //character.RollInitiative();
            }

            // Sort the characters by their initiative rolls
            characters.Sort((x, y) => y.Initiative.CompareTo(x.Initiative));
            return characters;
        }
    }
}
