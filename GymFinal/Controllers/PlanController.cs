using Microsoft.AspNetCore.Mvc; // Para ASP.NET Core MVC

namespace GymFinal.Controllers // Asegúrate de que el namespace sea el de tu proyecto
{
    public class PlanController : Controller
    {
        // GET: Plan
        public IActionResult Index() // IActionResult para ASP.NET Core MVC
        {
            return View();
        }

        public IActionResult Crear()
        {
            return View();
        }

        public IActionResult Modificar()
        {
            return View();
        }

        public IActionResult Eliminar()
        {
            return View();
        }
    }
}