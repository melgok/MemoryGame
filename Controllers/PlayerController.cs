using Microsoft.AspNetCore.Mvc;
using MemoryGame.Services;

namespace MemoryGame.Controllers
{
    public class PlayerController : Controller
    {
        private readonly PlayerService _service;

        public PlayerController(PlayerService service)
        {
            _service = service;
        }

        public async Task<IActionResult> GetAllPlayers()
        {
            var players = await _service.GetAllPlayersAsync();
            return View(players);
        }
    }
}
