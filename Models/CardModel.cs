using MemoryGame.Model;

namespace MemoryGame.Models
{
    public class CardModel
    {
        public int CardId { get; set; }
        public bool IsHidden { get; set; }
        public bool IsMatched { get; set; }
        public PairModel? Pair { get; set; }
    
    }
}