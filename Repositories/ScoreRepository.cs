using MemoryGame.Data;
using MemoryGame.Entities;
using Microsoft.EntityFrameworkCore;

namespace MemoryGame.Repositories
{
    public class ScoreRepository
    {
        private readonly AppDbContext _context;

        public ScoreRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ScoreEntity?> GetByIdAsync(int playerId, int gameId)
        {
            return await _context.Scores
                .FirstOrDefaultAsync(score => score.PlayerId == playerId && score.GameId == gameId);
        }

        public async Task<List<ScoreEntity>> GetAllAsync()
        {
            return await _context.Scores.ToListAsync();
        }

        public async Task AddAsync(ScoreEntity score)
        {
            await _context.Scores.AddAsync(score);
            await _context.SaveChangesAsync();
        }

        internal async Task<ScoreEntity?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }



        public async Task UpdateAsync(ScoreEntity score)
        {
            _context.Scores.Update(score);
            await _context.SaveChangesAsync();
        }
        /*
            public async Task DeleteAsync(int playerId, int gameId)
            {
                var score = await GetByIdAsync(playerId, gameId);
                if (score != null)
                {
                    _context.Scores.Remove(score);
                    await _context.SaveChangesAsync();
                }
            } */
    }
}