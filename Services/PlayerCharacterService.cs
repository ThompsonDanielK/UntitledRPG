using UntitledRPG.Data;
using UntitledRPG.DTOs;
using UntitledRPG.Models;

namespace UntitledRPG.Services
{
    public class PlayerCharacterService : IPlayerCharacterService
    {
        private IPlayerCharacterRepository _characterRepository;

        public PlayerCharacterService(IRollService dice, IPlayerCharacterRepository playerCharacterRepository)
        {
            _characterRepository = playerCharacterRepository;
        }

        public bool CreateCharacter(CharacterCreationDTO characterSeed, string userId)
        {
            int[] abilityScores =
            {
                characterSeed.Strength,
                characterSeed.Dexterity,
                characterSeed.Constitution,
                characterSeed.Intelligence,
                characterSeed.Wisdom,
                characterSeed.Charisma
            };

            if (!IsStandardArray(abilityScores))
            {
                return false;
            }

            var character = new PlayerCharacter
            (
                characterSeed.Name,
                characterSeed.Race,
                characterSeed.Class,
                1, // Character level,
                0, // Experience points
                100, // Gold
                characterSeed.Strength,
                characterSeed.Dexterity,
                characterSeed.Constitution,
                characterSeed.Intelligence,
                characterSeed.Wisdom,
                characterSeed.Charisma,
                userId
            );

            int numberOfCreatedEntries = _characterRepository.Add(character);

            return numberOfCreatedEntries == 1;
        }

        public bool DeleteCharacter(int characterId)
        {
            int rowsAffected = _characterRepository.Delete(characterId);
            return rowsAffected == 1;
        }

        public List<PlayerCharacter> GetByUserId(string userId)
        {
            return _characterRepository.GetByUserId(userId);
        }

        public PlayerCharacter? GetById(int characterId)
        {
            return _characterRepository.GetById(characterId);
        }

        private bool IsStandardArray(int[] abilityScores)
        {
            var standardArray = new int[] { 15, 14, 13, 12, 10, 8 };

            return standardArray.All(number => abilityScores.Contains(number));
        }
    }
}
