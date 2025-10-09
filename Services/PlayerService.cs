using MemoryGame.Models;
using MemoryGame.Repositories;

namespace MemoryGame.Services
{
    public class PlayerService
    {
        private readonly PlayerRepository _repo;

        public PlayerService(PlayerRepository repo)
        {
            _repo = repo;
        }

        public async Task AddPlayerAsync(PlayerModel player)
        {
            await _repo.AddAsync(player);
        }

        public async Task<IEnumerable<PlayerModel>> GetAllPlayersAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<PlayerModel?> GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task UpdatePlayerAsync(PlayerModel player)
        {
            await _repo.UpdateAsync(player);
        }

        public async Task DeletePlayerAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }

    }
}
