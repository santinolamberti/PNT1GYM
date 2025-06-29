using GymFinal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GymFinal.Controllers
{
    public class FacturacionController : Controller
    {
        private readonly GimnasioContext _context;

        public FacturacionController()
        {
            _context = new GimnasioContext();
        }

        public IActionResult Index(int? sedeId)
        {
            var sedes = _context.Sedes.ToList();
            ViewBag.Sedes = sedes;

            var query = _context.Socios
                .Include(s => s.Plan)
                .Include(s => s.Sede)
                .AsQueryable();

            if (sedeId.HasValue)
            {
                query = query.Where(s => s.IdSede == sedeId.Value);
            }

            var facturacion = query
                .Where(s => s.Plan != null && s.Sede != null)
                .GroupBy(s => s.Sede.Nombre)
                .Select(g => new Facturacion
                {
                    NombreSede = g.Key,
                    Total = g.Sum(s => s.Plan.Precio)
                }).ToList();

            return View(facturacion);
        }
    }
}
