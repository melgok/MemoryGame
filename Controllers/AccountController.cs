using Microsoft.AspNetCore.Mvc;
using MemoryGame.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

public class AccountController : Controller
{
    private readonly PlayerService _service;

    public AccountController(PlayerService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Login()
    {
        var players = await _service.GetAllPlayersAsync();
        ViewBag.PlayerList = new SelectList(players, "PlayerId", "DisplayName");
        return View(players);
    }

    [HttpPost]
    public async Task<IActionResult> Login(int Player1Id, string Player1Username, string Player1Password, int Player2Id, string Player2Username, string Player2Password)
    {
        HttpContext.Session.SetString("Player1", "Tindra");
        HttpContext.Session.SetString("Player2", "Melissa");
        return RedirectToAction("ConfirmLogin");
        // TODO: TA BORT!

        var players = await _service.GetAllPlayersAsync();
        ViewBag.PlayerList = new SelectList(players, "PlayerId", "DisplayName");

        if (Player1Id == Player2Id)
        {
            ViewBag.Error = "Spelarna måste vara olika.";
            return View(players);
        }

        var player1 = players.FirstOrDefault(player => player.PlayerId == Player1Id && player.Username == Player1Username && player.Password == Player1Password);
        var player2 = players.FirstOrDefault(player => player.PlayerId == Player2Id && player.Username == Player2Username && player.Password == Player2Password);
        if (player1 == null || player2 == null)
        {
            ViewBag.Error = "Ogiltigt användarnamn eller lösenord.";
            return View(players);
        }
        HttpContext.Session.SetString("Player1", player1.DisplayName);
        HttpContext.Session.SetString("Player2", player2.DisplayName);
        return RedirectToAction("ConfirmLogin");

    }
    public IActionResult ConfirmLogin()
    {
        ViewBag.Player1 = HttpContext.Session.GetString("Player1");
        ViewBag.Player2 = HttpContext.Session.GetString("Player2");
        return View();
    }

}