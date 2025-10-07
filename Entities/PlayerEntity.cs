using System.ComponentModel.DataAnnotations;

namespace MemoryGame.Entities
{
    public class PlayerEntity
    {
        [Key]
        public int PlayerId { get; set; }
        [Required]
        public string DisplayName { get; set; }
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

    }
}