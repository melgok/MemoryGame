namespace MemoryGame.Entities
{
    public class CardEntity
    {
        public int CardId { get; set; }
        public bool IsHidden { get; set; }
        public bool IsMatched { get; set; }
        public int PairId { get; set; }
        
        public PairEntity? Pair { get; set; }
    }
}