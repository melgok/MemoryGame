using MemoryGame.Services;
using Microsoft.AspNetCore.Mvc;
using MemoryGame.Models;

namespace MemoryGame.Controllers
{
    public class GameController : Controller
    {

        private readonly GameService _service;

        public GameController(GameService service)
        {
            _service = service;
        }

        public IActionResult StartGame()
        {
            GameModel gameModel1 = new();
            
            


            
            
            return View();
        }

    }

    
}
