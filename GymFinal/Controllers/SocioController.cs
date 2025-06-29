using Microsoft.AspNetCore.Mvc;
using GymFinal.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GymFinal.Controllers
{
    public class SocioController : Controller
    {
        private readonly GimnasioContext _context;

        public SocioController()
        {
            _context = new GimnasioContext();
        }

        // GET: /Socio
        public IActionResult Index(int? sedeId)
        {
            var socios = _context.Socios
                .Include(s => s.Plan)
                .Include(s => s.Sede)
                .AsQueryable();

            if (sedeId.HasValue)
                socios = socios.Where(s => s.IdSede == sedeId.Value);

            ViewBag.Sedes = _context.Sedes.ToList();
            return View(socios.ToList());
        }

        // GET: /Socio/Create
        public IActionResult Create()
        {
            ViewBag.Planes = _context.Planes.ToList();
            ViewBag.Sedes = _context.Sedes.ToList();
            return View();
        }

        // POST: /Socio/Create
        [HttpPost]
        public IActionResult Create(Socio socio)
        {
            if (ModelState.IsValid)
            {
                _context.Socios.Add(socio);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Planes = _context.Planes.ToList();
            ViewBag.Sedes = _context.Sedes.ToList();
            return View(socio);
        }

        // GET: /Socio/Edit/5
        public IActionResult Edit(int id)
        {
            var socio = _context.Socios.Find(id);
            if (socio == null) return NotFound();

            ViewBag.Planes = _context.Planes.ToList();
            ViewBag.Sedes = _context.Sedes.ToList();
            return View(socio);
        }

        // POST: /Socio/Edit
        [HttpPost]
        public IActionResult Edit(Socio socio)
        {
            if (ModelState.IsValid)
            {
                _context.Socios.Update(socio);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Planes = _context.Planes.ToList();
            ViewBag.Sedes = _context.Sedes.ToList();
            return View(socio);
        }

        // GET: /Socio/Delete/5
        public IActionResult Delete(int id)
        {
            var socio = _context.Socios.Find(id);
            if (socio != null)
            {
                _context.Socios.Remove(socio);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
