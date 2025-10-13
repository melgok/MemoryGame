using MemoryGame.Data;

namespace MemoryGame.Repositories
{
    public class CardRepository
    {
        private readonly AppDbContext _context;

        public CardRepository(AppDbContext context)
        {
            _context = context;
        }

    }
}