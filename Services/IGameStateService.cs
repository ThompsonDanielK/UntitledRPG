using UntitledRPG.Models;

namespace UntitledRPG.Services
{
    public interface IGameStateService
    {
        bool AddCharacterToParty(string userId, int characterId);
        bool CreateGameState(string userId);
        GameState? GetGameState(string userId);
        bool RemoveCharacterFromParty(string userId, int characterId);
        bool UpdateGameState(GameState gameState);
    }
}