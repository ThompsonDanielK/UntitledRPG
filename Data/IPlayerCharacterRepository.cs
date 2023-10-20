using UntitledRPG.Models;

namespace UntitledRPG.Data
{
    public interface IPlayerCharacterRepository
    {
        int Add(PlayerCharacter character);
        int Delete(int id);
        List<PlayerCharacter> GetByUserId(string userId);
        PlayerCharacter? GetById(int id);
        void Update(PlayerCharacter character);
    }
}