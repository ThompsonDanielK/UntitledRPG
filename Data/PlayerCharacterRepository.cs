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

        //public List<PlayerCharacter> GetByUserId(string userId)
        //{
        //    return _context.PlayerCharacters.Where(character => character.UserId == userId).ToList();
        //}

        public int Add(PlayerCharacter character)
        {
            _context.PlayerCharacters.Add(character);
            return _context.SaveChanges();
        }

        //public void Update(PlayerCharacter character)
        //{
        //    _context.PlayerCharacters.Update(character);
        //    _context.SaveChanges();
        //}

        //public void Delete(int id)
        //{
        //    var character = _context.PlayerCharacters.Find(id);
        //    if (character != null)
        //    {
        //        _context.PlayerCharacters.Remove(character);
        //        _context.SaveChanges();
        //    }
        //}
    }
}
