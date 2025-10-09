using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MemoryGame.Entities
{
    public class ScoreEntity
    {
        public int PlayerId { get; set; }
        public int GameId { get; set; }
        public int Points { get; set; }

        public PlayerEntity Player { get; set; } = null!;
        public GameEntity Game { get; set; } = null!;
    }

}