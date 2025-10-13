using MemoryGame.Data;
using MemoryGame.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MemoryGame.Repositories
{
    public class GameRepository
    {
        private readonly AppDbContext _context;

        public GameRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<GameEntity?> GetByIdAsync(int id)
        {
            return await _context.Games
                .Include(games => games.Scores)
                .Include(games => games.CurrentPlayer)
                .Include(games => games.WinnerPlayer)
                .FirstOrDefaultAsync(games => games.GameId == id);
        }

        public async Task<List<GameEntity>> GetAllAsync()
        {
            return await _context.Games
                .Include(games => games.Scores)
                .ToListAsync();
        }

        public async Task AddAsync(GameEntity game)
        {
            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(GameEntity game)
        {
            _context.Games.Update(game);
            await _context.SaveChangesAsync();
        }

    }
}