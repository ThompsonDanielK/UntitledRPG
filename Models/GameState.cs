using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UntitledRPG.Models
{
    [Index(nameof(UserId), IsUnique = true)]
    public class GameState
    {
        [Key]
        public int GameStateId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        [MaxLength(4)]
        [ForeignKey(nameof(PlayerCharacter))]
        public List<PlayerCharacter> ActiveParty { get; set; }
    }
}
