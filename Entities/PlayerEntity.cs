using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MemoryGame.Entities
{
    public class PlayerEntity
    {
        public int PlayerId { get; set; }
        public string DisplayName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public List<ScoreEntity> Scores { get; set; } = new List<ScoreEntity>();
        public List<GameEntity> CurrentGames { get; set; } = new List<GameEntity>();
        public List<GameEntity> WonGames { get; set; } = new List<GameEntity>();

    }
}