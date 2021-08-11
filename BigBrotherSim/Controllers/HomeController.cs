using BigBrotherSim.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BigBrotherSim.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IGameMethods game;
        private readonly IPlayerRepository repo;

        public HomeController(ILogger<HomeController> logger, IGameMethods game, IPlayerRepository repo)
        {
            this.logger = logger;
            this.game = game;
            this.repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        { 
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult newHoh()
        {
            game.newHoh();
            GamePieces.selectedPlayer = repo.GetPlayer(GamePieces.currentHoh);
            return RedirectToAction("Index");
        }
        public IActionResult InitialNoms()
        {
            game.initialNoms();
            return RedirectToAction("Index");
        }
        public IActionResult PovPlayers()
        {
            game.povPlayers();
            return RedirectToAction("Index");
        }
        public IActionResult PovWinner()
        {
            game.povWinner();
            return RedirectToAction("Index");
        }
        public IActionResult PovCeremony()
        {
            game.povCeremony();
            return RedirectToAction("Index");
        }

        public IActionResult EvictionNight()
        {
            return RedirectToAction("Index");
        }
    }
}
