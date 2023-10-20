using System.ComponentModel.DataAnnotations;

namespace UntitledRPG.DTOs
{
    public class CharacterCreation
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Race { get; set; }
        [Required]
        public string Class { get; set; }
        [Required]
        public int Strength { get; set; }
        [Required]
        public int Dexterity { get; set; }
        [Required]
        public int Constitution { get; set; }
        [Required]
        public int Intelligence { get; set; }
        [Required]
        public int Wisdom { get; set; }
        [Required]
        public int Charisma { get; set; }
    }
}
