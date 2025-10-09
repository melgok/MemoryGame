using Microsoft.AspNetCore.Mvc;
using MemoryGame.Services;
using MemoryGame.Models;

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

        [HttpGet]
        public IActionResult AddPlayer()
        {
            PlayerModel player = new PlayerModel();

            return View(player);
        }

        [HttpPost]
        public async Task<IActionResult> AddPlayer(PlayerModel player)
        {
            await _service.AddPlayerAsync(player);
            return RedirectToAction("GetAllPlayers");
        }

        [HttpGet]
        public async Task<IActionResult> EditPlayer(int id)
        {
            var player = await _service.GetByIdAsync(id);
            return View(player);
        }

        [HttpPost]
        public async Task<IActionResult> EditPlayer(PlayerModel player)
        {
            await _service.UpdatePlayerAsync(player);
            return RedirectToAction("GetAllPlayers");
        }

        [HttpGet]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            await _service.DeletePlayerAsync(id);
            return RedirectToAction("GetAllPlayers");
        }   

    }
}
