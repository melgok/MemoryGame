using MemoryGame.Data;
using MemoryGame.Models;
using Microsoft.EntityFrameworkCore;

namespace MemoryGame.Repositories
{
    public class CardRepository
    {
        private readonly AppDbContext _database;

        public CardRepository(AppDbContext context)
        {
            _database = context;
        }

        public async Task<IEnumerable<CardModel>> GetAllAsync()
        {
            return await _database.Cards
                .Select(card => new CardModel
                {
                    CardId = card.CardId,
                    PairId = card.PairId
                })
                .ToListAsync();
        }

        public async Task<CardModel?> GetByIdAsync(int id)
        {
            var entity = await _database.Cards.FindAsync(id);
            if (entity == null) return null;

            return new CardModel
            {
                CardId = entity.CardId,
                PairId = entity.PairId
            };
        }
    }
}