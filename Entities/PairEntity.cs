namespace   MemoryGame.Entities
{
    public class PairEntity
    {
        public int PairId { get; set; }
        public string Image { get; set; }

        public List<CardEntity> Cards { get; set; } = new List<CardEntity>();
    }
}