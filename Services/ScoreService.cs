using MemoryGame.Entities;
using MemoryGame.Repositories;

namespace MemoryGame.Services
{
    public class ScoreService
    {
        private readonly ScoreRepository _scoreRepository;

        public ScoreService(ScoreRepository scoreRepository)
        {
            _scoreRepository = scoreRepository;
        }

        public async Task<ScoreEntity> AddScoreAsync(ScoreEntity score)
        {
            await _scoreRepository.AddAsync(score);
            return score;
        }

        public async Task<ScoreEntity?> GetScoreByIdAsync(int gameId, int id)
        {
            return await _scoreRepository.GetByIdAsync(gameId, id);
        }

        public async Task<List<ScoreEntity>> GetAllScoresAsync()
        {
            return await _scoreRepository.GetAllAsync();
        }

        public async Task UpdateScoreAsync(ScoreEntity updatedScore)
        {
            await _scoreRepository.UpdateAsync(updatedScore);
        }
    }
}