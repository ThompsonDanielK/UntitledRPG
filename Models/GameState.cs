namespace UntitledRPG.Models
{
    public class GameState
    {
        public int Id { get; set; }
        public List<PlayerCharacter> PlayerCharacters { get; set; }
        public BattleManager BattleManager { get; set; }
    }
}
