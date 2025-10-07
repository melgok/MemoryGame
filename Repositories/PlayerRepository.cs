using MemoryGame.Data;
using MemoryGame.Entities;
using MemoryGame.Models;
using Microsoft.EntityFrameworkCore;

namespace MemoryGame.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly AppDbContext _database;

        public PlayerRepository(AppDbContext context)
        {
            _database = context;
        }

        public async Task<IEnumerable<PlayerModel>> GetAllAsync()
        {
            return await _database.Players
                .Select(player => new PlayerModel
                {
                    PlayerId = player.PlayerId,
                    DisplayName = player.DisplayName
                })
                .ToListAsync();
        }

        public async Task<PlayerModel?> GetByIdAsync(int id)
        {
            var entity = await _database.Players.FindAsync(id);
            if (entity == null) return null;

            return new PlayerModel
            {
                PlayerId = entity.PlayerId,
                DisplayName = entity.DisplayName,
            };
        }

        public async Task AddAsync(PlayerModel player)
        {
            var entity = new PlayerEntity
            {
                DisplayName = player.DisplayName,
            };

            _database.Players.Add(entity);
            await _database.SaveChangesAsync();
            player.PlayerId = entity.PlayerId; // Uppdatera ID efter sparning
        }

        public async Task UpdateAsync(PlayerModel player)
        {
            var entity = await _database.Players.FindAsync(player.PlayerId);
            if (entity == null) return;

            entity.DisplayName = player.DisplayName;
            await _database.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _database.Players.FindAsync(id);
            if (entity == null) return;

            _database.Players.Remove(entity);
            await _database.SaveChangesAsync();
        }
    }
}