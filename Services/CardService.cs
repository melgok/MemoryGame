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

        public async Task ResetCard(int id)
        {
            var card = await GetByIdAsync(id);

            if (card == null)
            {
                return;
            }

            card.IsMatched = false;
            card.IsHidden = true;

            await _repo.UpdateCard(card);
        }

        public async Task ResetCards()
        {
            var cards = await GetAllCardsAsync();

            foreach (var card in cards)
            {
                await ResetCard(card.CardId);
            }
        }

    }
}