using UntitledRPG.DTOs;
using UntitledRPG.Models;

namespace UntitledRPG.Services
{
    public interface IPlayerCharacterService
    {
        bool CreateCharacter(CharacterCreationDTO characterSeed, string userId);
        bool IsStandardArray(int[] abilityScores);
        List<PlayerCharacter> GetByUserId(string userId);
    }
}
