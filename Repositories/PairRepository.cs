using MemoryGame.Data;
using MemoryGame.Entities;
using Microsoft.EntityFrameworkCore;

namespace MemoryGame.Repositories
{
    public class PairRepository
    {
        private readonly AppDbContext _context;

        public PairRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<PairEntity>> GetAllAsync()
        {
            return await _context.Pairs
                .Include(pair => pair.Cards)
                .ToListAsync();
        }

        public async Task CreatePairAsync()
        {
           if (await _context.Pairs.AnyAsync())
            return;

            string appleBase64 = Convert.ToBase64String(File.ReadAllBytes("SeedImages/apple.png"));
            /* string bananaBase64 = Convert.ToBase64String(File.ReadAllBytes("SeedImages/banana.png"));
            string catBase64 = Convert.ToBase64String(File.ReadAllBytes("SeedImages/cat.png")); */

        var pairs = new List<PairEntity>
        {
            new PairEntity
            {
                Image = appleBase64,
                Cards = new List<CardEntity>
                {
                    new CardEntity { IsHidden = true, IsMatched = false },
                    new CardEntity { IsHidden = true, IsMatched = false }
                }
            },
            /* new PairEntity
            {
                Image = bananaBase64,
                Cards = new List<CardEntity>
                {
                    new CardEntity { IsHidden = true, IsMatched = false },
                    new CardEntity { IsHidden = true, IsMatched = false }
                }
            },
            new PairEntity
            {
                Image = catBase64,
                Cards = new List<CardEntity>
                {
                    new CardEntity { IsHidden = true, IsMatched = false },
                    new CardEntity { IsHidden = true, IsMatched = false }
                }
            } */
        };

        await _context.Pairs.AddRangeAsync(pairs);
        await _context.SaveChangesAsync();
        }
    }
}