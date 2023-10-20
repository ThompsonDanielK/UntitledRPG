using UntitledRPG.Database;
using UntitledRPG.Models;

namespace UntitledRPG.Data
{
    public class PlayerCharacterRepository : IPlayerCharacterRepository
    {
        private readonly ApplicationDbContext _context;

        public PlayerCharacterRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<PlayerCharacter> GetByUserId(string userId)
        {
            return _context.PlayerCharacters.Where(character => character.UserId == userId).ToList();
        }

        public PlayerCharacter? GetById(int id)
        {
            return _context.PlayerCharacters.Find(id);
        }

        public int Add(PlayerCharacter character)
        {
            _context.PlayerCharacters.Add(character);
            return _context.SaveChanges();
        }

        public void Update(PlayerCharacter character)
        {
            _context.PlayerCharacters.Update(character);
            _context.SaveChanges();
        }

        public int Delete(int id)
        {
            var character = _context.PlayerCharacters.Find(id);
            if (character != null)
            {
                _context.PlayerCharacters.Remove(character);
                return _context.SaveChanges();
            }
            return 0;
        }
    }
}
