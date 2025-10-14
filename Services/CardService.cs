using MemoryGame.Models;
using MemoryGame.Repositories;

namespace MemoryGame.Services
{
    public class CardService
    {

        private readonly CardRepository _repo;

        public CardService(CardRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<CardModel>> GetAllCardsAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<CardModel?> GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

    }
}