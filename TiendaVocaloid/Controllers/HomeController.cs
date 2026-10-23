using Microsoft.AspNetCore.Mvc;

namespace TiendaVocaloid.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Producto");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
