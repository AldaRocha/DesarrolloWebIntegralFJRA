using Microsoft.AspNetCore.Mvc;

namespace Intro_ASPNetMVC.Controllers
{
    public class ProveedoresController : Controller
    {
        public IActionResult ListadoProveedores()
        {
            ViewBag.Proveedores = "Intel, Nvidia, AMD, MSI, Kingston, Samsung";
            ViewBag.Hola = "Hola Ferrraaaaan";
            return View();
        }
    }
}
