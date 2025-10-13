using MemoryGame.Repositories;

namespace MemoryGame.Services
{
    public class PairService
    {
        private readonly PairRepository _pairRepository;

        public PairService(PairRepository pairRepository)
        {
            _pairRepository = pairRepository;
        }
    }
}