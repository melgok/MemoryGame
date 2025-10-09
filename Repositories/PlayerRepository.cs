using MemoryGame.Data;
using MemoryGame.Entities;
using MemoryGame.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace MemoryGame.Repositories
{
    public class PlayerRepository 
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
                    DisplayName = player.DisplayName,
                    Username = player.Username,
                    Password = player.Password
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
                Username = entity.Username,
                Password = entity.Password

            };
        }

        public async Task AddAsync(PlayerModel player)
        {
            var entity = new PlayerEntity
            {
                DisplayName = player.DisplayName,
                Username = player.Username,
                Password = player.Password
            };

            _database.Players.Add(entity);
            await _database.SaveChangesAsync();
            player.PlayerId = entity.PlayerId; 
        }

        public async Task UpdateAsync(PlayerModel player)
        {
            var entity = await _database.Players.FindAsync(player.PlayerId);
            if (entity == null) return;

            entity.DisplayName = player.DisplayName;
           /*  entity.Username = player.Username;
            entity.Password = player.Password; */
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