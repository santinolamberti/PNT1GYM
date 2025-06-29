using Microsoft.AspNetCore.Mvc;
using GymFinal.Models;
using System.Linq;

namespace GymFinal.Controllers
{
    public class PlanController : Controller
    {
        private readonly GimnasioContext _context;

        public PlanController()
        {
            _context = new GimnasioContext();
        }

        // GET: /Plan
        public IActionResult Index()
        {
            var planes = _context.Planes.ToList();
            return View(planes);
        }

        // GET: /Plan/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Plan/Create
        [HttpPost]
        public IActionResult Create(Plan plan)
        {
            if (ModelState.IsValid)
            {
                _context.Planes.Add(plan);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(plan);
        }

        // GET: /Plan/Edit/5
        public IActionResult Edit(int id)
        {
            var plan = _context.Planes.Find(id);
            if (plan == null)
                return NotFound();

            return View(plan);
        }

        // POST: /Plan/Edit
        [HttpPost]
        public IActionResult Edit(Plan plan)
        {
            if (ModelState.IsValid)
            {
                _context.Planes.Update(plan);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(plan);
        }

        // GET: /Plan/Delete/5
        public IActionResult Delete(int id)
        {
            var plan = _context.Planes.Find(id);
            if (plan != null)
            {
                _context.Planes.Remove(plan);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
