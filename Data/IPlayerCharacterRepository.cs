using UntitledRPG.Models;

namespace UntitledRPG.Data
{
    public interface IPlayerCharacterRepository
    {
        int Add(PlayerCharacter character);
        //void Delete(int id);
        List<PlayerCharacter> GetByUserId(string userId);
        //void Update(PlayerCharacter character);
    }
}