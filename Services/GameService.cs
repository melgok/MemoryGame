using System.Collections.Generic;
using System.Threading.Tasks;
using MemoryGame.Entities;

public class GameService
{
    private readonly GameRepository _gameRepository;

    public GameService(GameRepository gameRepository)
    {
        _gameRepository = gameRepository;
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

    public async Task UpdateGameAsync(GameEntity updatedGame)
    {
        await _gameRepository.UpdateAsync(updatedGame);
    }

}
