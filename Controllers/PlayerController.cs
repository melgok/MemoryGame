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
    }
}
