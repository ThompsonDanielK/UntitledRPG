using UntitledRPG.Data;
using UntitledRPG.DTOs;

namespace UntitledRPG.Services
{
    public interface IPlayerCharacterService
    {
        bool CreateCharacter(CharacterCreation characterSeed, string userId);
        bool IsStandardArray(int[] abilityScores);
    }
}
