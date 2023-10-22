using UntitledRPG.Data;
using UntitledRPG.Models;

namespace UntitledRPG.Services
{
    public class GameStateService : IGameStateService
    {
        private readonly IGameStateRepository _gameStateRepository;
        private readonly IPlayerCharacterRepository _playerCharacterRepository;

        public GameStateService(IGameStateRepository gameStateRepository, IPlayerCharacterRepository playerCharacterRepository)
        {
            _gameStateRepository = gameStateRepository;
            _playerCharacterRepository = playerCharacterRepository;
        }

        public bool CreateGameState(string userId)
        {
            GameState gameState = new GameState
            {
                UserId = userId,
                ActiveParty = new List<PlayerCharacter>()
            };

            return _gameStateRepository.Add(gameState);
        }

        public GameState? GetGameState(string userId)
        {
            return _gameStateRepository.GetByUserId(userId);
        }

        public bool UpdateGameState(GameState gameState)
        {
            var result = _gameStateRepository.Update(gameState);
            return result;
        }

        public bool AddCharacterToParty(string userId, int characterId)
        {
            GameState? gameState = GetGameState(userId);

            if (gameState == null)
            {
                return false;
            }

            PlayerCharacter? character = _playerCharacterRepository.GetById(characterId);

            if (character == null)
            {
                return false;
            }

            if (gameState?.ActiveParty != null && gameState.ActiveParty.Count >= 4)
            {
                return false;
            }

            if (gameState.ActiveParty == null)
            {
                gameState.ActiveParty = new List<PlayerCharacter> { character };
            }
            else
            {
                gameState.ActiveParty.Add(character);
            }

            return UpdateGameState(gameState);
        }

        public bool RemoveCharacterFromParty(string userId, int characterId)
        {
            GameState? gameState = GetGameState(userId);

            if (gameState == null)
            {
                return false;
            }

            PlayerCharacter? character = gameState.ActiveParty.FirstOrDefault(pc => pc.PlayerCharacterId == characterId);

            if (character == null)
            {
                return false;
            }

            gameState.ActiveParty.Remove(character);

            return UpdateGameState(gameState);
        }
    }
}
