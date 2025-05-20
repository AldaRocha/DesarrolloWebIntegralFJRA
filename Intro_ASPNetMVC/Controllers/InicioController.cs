using Microsoft.AspNetCore.Mvc;

namespace Intro_ASPNetMVC.Controllers
{
    public class InicioController : Controller
    {
        //  GET: Index
        public string Index()
        {
            return "Mi primer aplicación en ASP .NET Core MVC";
        }

        // GET: Buscar
        public ActionResult Buscar(string nombre)
        {
            return Content("El nombre del cliente a buscar es: " + nombre);
        }


        // GET: Redirecciona
        public ActionResult Redirecciona()
        {
            return RedirectToAction("ListadoProveedores", "Proveedores");
        }
    }
}
