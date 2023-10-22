using Microsoft.EntityFrameworkCore;
using UntitledRPG.Database;
using UntitledRPG.Models;

namespace UntitledRPG.Data
{
    public class GameStateRepository : IGameStateRepository
    {
        private readonly ApplicationDbContext _context;

        public GameStateRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(GameState gameState)
        {
            _context.GameStates.Add(gameState);
            return _context.SaveChanges() == 1;
        }

        public GameState? GetByUserId(string userId)
        {
            return _context.GameStates.Where(gamestate => gamestate.UserId == userId).Include(gs => gs.ActiveParty).FirstOrDefault();
        }

        public bool Update(GameState gameState)
        {
            _context.GameStates.Update(gameState);
           
            return _context.SaveChanges() >= 1;
        }
    }
}
