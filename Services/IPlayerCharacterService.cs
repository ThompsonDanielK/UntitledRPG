using UntitledRPG.DTOs;
using UntitledRPG.Models;

namespace UntitledRPG.Services
{
    public interface IPlayerCharacterService
    {
        bool CreateCharacter(CharacterCreationDTO characterSeed, string userId);
        bool DeleteCharacter(int characterId);
        List<PlayerCharacter> GetByUserId(string userId);
        PlayerCharacter? GetById(int characterId);
    }
}
