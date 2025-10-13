namespace MemoryGame.Models
{
    public class GameModel
    {
        public int GameId { get; set; }
        public int? CurrentPlayerId { get; set; }
        public int? WinnerPlayerId { get; set; }

    }
}