using MemoryGame.Services;
using Microsoft.AspNetCore.Mvc;
using MemoryGame.Models;

namespace MemoryGame.Controllers
{
    public class GameController : Controller
    {

        private readonly GameService _gameService;
        private readonly CardService _cardService;

        public GameController(GameService gameService, CardService cardService)
        {
            _gameService = gameService;
            _cardService = cardService;
        }

        public async Task<IActionResult> StartGame()
        {
            GameModel gameModel = new();

            await _gameService.StartGameAsync();

            var cards = await _cardService.GetAllCardsAsync();
            
            return View(cards);
        }

    }

    
}
