using MemoryGame.Models;
using MemoryGame.Repositories;

namespace MemoryGame.Services
{
    public class PlayerService
    {
        private readonly IPlayerRepository _repo;

        public PlayerService(IPlayerRepository repo)
        {
            _repo = repo;
        }

        public async Task AddPlayerAsync(string name)
        {
            var player = new PlayerModel
            {
                DisplayName = name
            };
            await _repo.AddAsync(player);
        }

        public async Task<IEnumerable<PlayerModel>> GetAllPlayersAsync()
        {
            return await _repo.GetAllAsync();
        }

    }
}
