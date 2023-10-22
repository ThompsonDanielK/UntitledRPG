using UntitledRPG.Models;

namespace UntitledRPG.Data
{
    public interface IGameStateRepository
    {
        bool Add(GameState gameState);
        GameState? GetByUserId(string userId);
        bool Update(GameState gameState);
    }
}