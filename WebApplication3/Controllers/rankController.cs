using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class rankController : Controller
    {
        private readonly ApplicationDbContext _context;

        public rankController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult IndexRanks()
        {
            IEnumerable<rank> Rank = _context.Ranks;
            return View(Rank);


        }

        public IActionResult CreateRank()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateRank(rank Rank)
        {
            if (ModelState.IsValid)
            {
                _context.Ranks.Add(Rank);
                _context.SaveChanges();

                TempData["message"] = "The user was created correctly";
                return RedirectToAction("IndexRanks");
            }
            return View();
        }

        public IActionResult EditRank(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var Rank = _context.users.Find(Id);
            if (Rank == null)
            {
                return NotFound();
            }
            return View(Rank);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditRank(rank Rank)
        {
            if (ModelState.IsValid)
            {
                _context.Ranks.Update(Rank);
                _context.SaveChanges();

                TempData["message"] = "The user was updated correctly";
                return RedirectToAction("IndexRanks");
            }
            return View();
        }

        public IActionResult deleteRank(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var Rank = _context.users.Find(Id);
            if (Rank == null)
            {
                return NotFound();
            }
            return View(Rank);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? Id_ranks)
        {
            var Rank = _context.Ranks.Find(Id_ranks);
            if (Rank == null)
            {
                return NotFound();
            }
            _context.Ranks.Remove(Rank);
            _context.SaveChanges();
            return RedirectToAction("IndexRanks");
        }
    }
}
