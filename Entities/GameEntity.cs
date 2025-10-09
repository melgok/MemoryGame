using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MemoryGame.Entities
{

    public class GameEntity
    {
        public int GameId { get; set; }
        public int? CurrentPlayerId { get; set; }
        public int? WinnerPlayerId { get; set; }

        public List<ScoreEntity> Scores { get; set; } = new List<ScoreEntity>();
        public PlayerEntity? CurrentPlayer { get; set; }
        public PlayerEntity? WinnerPlayer { get; set; }
    }

}