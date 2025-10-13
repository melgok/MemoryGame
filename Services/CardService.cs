using MemoryGame.Repositories;

namespace MemoryGame.Services
{
    public class CardService
    {
        private readonly CardRepository _cardRepository;

        public CardService(CardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }
    }
}