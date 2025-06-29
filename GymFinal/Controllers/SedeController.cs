using Microsoft.AspNetCore.Mvc;
using GymFinal.Models;
using System.Linq;

namespace GymFinal.Controllers
{
    public class SedeController : Controller
    {
        private readonly GimnasioContext _context;

        public SedeController()
        {
            _context = new GimnasioContext();
        }

        // GET: /Sede
        public IActionResult Index()
        {
            var sedes = _context.Sedes.ToList();
            return View(sedes);
        }

        // GET: /Sede/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Sede/Create
        [HttpPost]
        public IActionResult Create(Sede sede)
        {
            if (ModelState.IsValid)
            {
                _context.Sedes.Add(sede);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sede);
        }

        // GET: /Sede/Edit/5
        public IActionResult Edit(int id)
        {
            var sede = _context.Sedes.Find(id);
            if (sede == null) return NotFound();

            return View(sede);
        }

        // POST: /Sede/Edit
        [HttpPost]
        public IActionResult Edit(Sede sede)
        {
            if (ModelState.IsValid)
            {
                _context.Sedes.Update(sede);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sede);
        }

        // GET: /Sede/Delete/5
        public IActionResult Delete(int id)
        {
            var sede = _context.Sedes.Find(id);
            if (sede != null)
            {
                _context.Sedes.Remove(sede);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
