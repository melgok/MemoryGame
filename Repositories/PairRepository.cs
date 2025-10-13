using MemoryGame.Data;

namespace MemoryGame.Repositories
{
    public class PairRepository
    {
        private readonly AppDbContext _context;

        public PairRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}