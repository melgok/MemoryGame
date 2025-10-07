using MemoryGame.Models;

namespace MemoryGame.Repositories
{
    public interface IPlayerRepository
    {
        Task<IEnumerable<PlayerModel>> GetAllAsync();
        Task<PlayerModel?> GetByIdAsync(int id);
        Task AddAsync(PlayerModel player);
        Task UpdateAsync(PlayerModel player);
        Task DeleteAsync(int id);
    }
}