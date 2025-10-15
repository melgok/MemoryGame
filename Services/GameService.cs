using MemoryGame.Entities;
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

        public GameService(GameRepository gameRepository, PairRepository pairRepository, CardService cardService)
        {
            _gameRepository = gameRepository;
            _pairRepository = pairRepository;
            _cardService = cardService;
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

    }

}