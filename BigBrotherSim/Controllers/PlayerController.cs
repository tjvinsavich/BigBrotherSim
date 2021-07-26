using BigBrotherSim.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigBrotherSim.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayerRepository repo;

        public PlayerController(IPlayerRepository repo)
        {
            this.repo = repo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var players = repo.GetAllPlayers();

            return View(players);
        }

        public IActionResult ViewPlayer(int id)
        {
            var player = repo.GetPlayer(id);

            return View(player);
        }

        public IActionResult UpdatePlayer(int id)
        {
            Player play = repo.GetPlayer(id);

            if (play == null)
            {
                return View("PlayerNotFound");
            }

            return View(play);
        }

        public IActionResult UpdatePlayerToDatabase(Player player)
        {
            repo.UpdatePlayer(player);

            return RedirectToAction("ViewPlayer", new { id = player.id });
        }
        public IActionResult InsertPlayer()
        {
            var player = new Player();

            return View(player);
        }
        public IActionResult InsertPlayerToDatabase(Player player)
        {
            repo.InsertPlayer(player);

            return RedirectToAction("Index");
        }

        public IActionResult DeletePlayer(Player player)
        {
            repo.DeletePlayer(player);

            return RedirectToAction("Index");
        }





    }
}
