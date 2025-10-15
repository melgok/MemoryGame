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

        public GameService(GameRepository gameRepository, PairRepository pairRepository)
        {
            _gameRepository = gameRepository;
            _pairRepository = pairRepository;
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
            await _pairRepository.SeedPairsAsync();
        }
       

        public async Task UpdateGameAsync(GameEntity updatedGame)
        {
            await _gameRepository.UpdateAsync(updatedGame);
        }

    }

}