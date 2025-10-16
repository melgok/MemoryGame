using MemoryGame.Entities;
using MemoryGame.Model;
using MemoryGame.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MemoryGame.Services
{
    public class GameService
    {
        private readonly GameRepository _gameRepository;
        private readonly PairRepository _pairRepository;
        private readonly CardRepository _cardRepository;
        private readonly CardService _cardService;
        

        public GameService(GameRepository gameRepository, PairRepository pairRepository, CardService cardService, CardRepository cardRepository)
        {
            _gameRepository = gameRepository;
            _pairRepository = pairRepository;
            _cardService = cardService;
            _cardRepository = cardRepository;
        }

        public async Task<GameEntity?> GetGameAsync(int id)
        {
            return await _gameRepository.GetByIdAsync(id);
        }

        public async Task<List<GameEntity>> GetAllGamesAsync()
        {
            return await _gameRepository.GetAllAsync();
        }

        public async Task CreateGameAsync(GameEntity newGame)
        {
            await _gameRepository.AddAsync(newGame);
        }

        public async Task StartGameAsync()
        {
            await InitializeGame();



        }
       

        public async Task UpdateGameAsync(GameEntity updatedGame)
        {
            await _gameRepository.UpdateAsync(updatedGame);
        }


        public async Task InitializeGame()
        {
            await _pairRepository.SeedPairsAsync();
            await _cardService.ResetCards();
        }


        public async Task PlayTurn(int cardId)
        {
            // Hämta kortet
            var card = await _cardRepository.GetByIdAsync(cardId);
            if (card == null || !card.IsHidden)
                return; // ogiltigt klick

            // Vänd kortet
            card.IsHidden = false;
            await _cardRepository.UpdateCard(card);

            //// Hämta alla kort i spelet
            var cards = await _cardRepository.GetAllAsync();

            // Kolla hur många som är synliga men ej matchade
            var visibleCards = cards.Where(c => !c.IsHidden && !c.IsMatched).ToList();

            if (visibleCards.Count == 2)
            {
                var first = visibleCards[0];
                var second = visibleCards[1];

                // Är det ett par?
                if (first.Pair == second.Pair)
                {
                    first.IsMatched = true;
                    second.IsMatched = true;
                    await _cardRepository.UpdateCard(first);
                    await _cardRepository.UpdateCard(second);
                }
                else
                {
                    //// Vänta lite innan korten vänds tillbaka (kan hanteras i frontend)
                    //first.IsHidden = true;
                    //second.IsHidden = true;
                    //await _cardRepository.UpdateCard(first);
                    //await _cardRepository.UpdateCard(second);
                }

                

            }
        }
    }

}