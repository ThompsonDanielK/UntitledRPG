using UntitledRPG.Services;

namespace UntitledRPG.Engine.Utilities
{
    public class RollService : IRollService
    {
        private Random random;

        public RollService()
        {
            random = new Random();
        }

        public int Roll(int sides)
        {
            if (sides <= 0)
            {
                throw new ArgumentException("Number of sides must be greater than 0.");
            }

            return random.Next(1, sides + 1);
        }
    }
}
