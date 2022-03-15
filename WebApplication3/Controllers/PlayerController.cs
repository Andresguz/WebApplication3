using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class PlayerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlayerController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult IndexPlayer()
        {
            IEnumerable<Players> players = _context.players;
            return View(players);


        }

        public IActionResult CreatePlayer()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePlayer(Players players)
        {
            if (ModelState.IsValid)
            {
                _context.players.Add(players);
              
                _context.SaveChanges();

                TempData["message"] = "The user was created correctly";
                return RedirectToAction("IndexPlayer");
            }
            return View();
        }

        public IActionResult EditPlayer(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var player = _context.players.Find(Id);
            if (player == null)
            {
                return NotFound();
            }
            return View(player);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditPlayer(Players player)
        {
            if (ModelState.IsValid)
            {
                _context.players.Update(player);
                _context.SaveChanges();

                TempData["message"] = "The user was updated correctly";
                return RedirectToAction("IndexPlayer");
            }
            return View();
        }

        public IActionResult DeletePlayer(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var players = _context.players.Find(Id);
            if (players == null)
            {
                return NotFound();
            }
            return View(players);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? Id_user)
        {
            var players = _context.players.Find(Id_user);
            if (players == null)
            {
                return NotFound();
            }
            _context.players.Remove(players);
            _context.SaveChanges();
            return RedirectToAction("IndexPlayer");
        }
    }
}
