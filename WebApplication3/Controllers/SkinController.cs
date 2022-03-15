using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class SkinController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SkinController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult IndexSkin()
        {
            IEnumerable<Skins> skins = _context.Skins;
            return View(skins);


        }

        public IActionResult CreateSkin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateSkin(Skins skins)
        {
            if (ModelState.IsValid)
            {
                _context.Skins.Add(skins);
                _context.SaveChanges();

                TempData["message"] = "The user was created correctly";
                return RedirectToAction("IndexSkin");
            }
            return View();
        }

        public IActionResult EditSkins(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var skins = _context.users.Find(Id);
            if (skins == null)
            {
                return NotFound();
            }
            return View(skins);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditSkins(Skins skins)
        {
            if (ModelState.IsValid)
            {
                _context.Skins.Update(skins);
                _context.SaveChanges();

                TempData["message"] = "The user was updated correctly";
                return RedirectToAction("IndexSkin");
            }
            return View();
        }

        public IActionResult DeleteSkins(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var skins = _context.users.Find(Id);
            if (skins == null)
            {
                return NotFound();
            }
            return View(skins);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? Id_skin)
        {
            var skins = _context.users.Find(Id_skin);
            if (skins == null)
            {
                return NotFound();
            }
           // _context.Skins.Remove(skins);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
