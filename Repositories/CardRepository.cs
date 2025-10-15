using MemoryGame.Data;
using MemoryGame.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

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
                    IsHidden = card.IsHidden,
                    IsMatched = card.IsMatched,
                    Pair = new Model.PairModel
                    {
                        PairId = card.Pair.PairId,
                        Image = card.Pair.Image

                    },
                })
                .ToListAsync();
        }

        public async Task<CardModel?> GetByIdAsync(int id)
        {
            var entity = await _database.Cards.Include(c => c.Pair).FirstOrDefaultAsync(c => c.CardId == id);
            if (entity == null) return null;

            return new CardModel
            {
                CardId = entity.CardId,
                Pair = new Model.PairModel
                {
                    PairId = entity.Pair.PairId,
                    Image = entity.Pair.Image
                }
            };
        }

        public async Task UpdateCard(CardModel card)
        {
            var entity = await _database.Cards.FindAsync(card.CardId);
            if (entity == null) return;

            entity.IsHidden = card.IsHidden;
            entity.IsMatched = card.IsMatched;
            entity.PairId = card.Pair.PairId;

            await _database.SaveChangesAsync();
        }
    }
}