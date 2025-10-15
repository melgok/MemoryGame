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

        public async Task SeedPairsAsync()
        {
            if (await _context.Pairs.AnyAsync())
                return;

            var imageFolder = Path.Combine(Directory.GetCurrentDirectory(), "SeedImages");

            if (!Directory.Exists(imageFolder))
                throw new DirectoryNotFoundException($"SeedImages-folder saknas: {imageFolder}");

            var imageFiles = Directory.GetFiles(imageFolder, "*.png");

            var pairs = new List<PairEntity>();

            foreach (var file in imageFiles)
            {
                var base64 = Convert.ToBase64String(File.ReadAllBytes(file));

                var pair = new PairEntity
                {
                    Image = base64,
                    Cards =
                    [
                        new CardEntity { IsHidden = true, IsMatched = false },
                        new CardEntity { IsHidden = true, IsMatched = false }
                    ]
                };

                pairs.Add(pair);
            }

            await _context.Pairs.AddRangeAsync(pairs);
            await _context.SaveChangesAsync();
        }
    }
}