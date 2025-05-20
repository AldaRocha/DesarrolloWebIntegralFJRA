using Intro_ASPNetMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Intro_ASPNetMVC.Controllers
{
    public class ClientesController : Controller
    {
        public static List<Cliente> listaClientes = new List<Cliente>
        {
            new Cliente
            {
                ID = 1,
                Nombre = "Ferraaaan",
                FechaAlta = DateTime.Parse(DateTime.Today.ToString()),
                Correo = "ferrantiburon@barcampeonlliga2024_2025.com"
            },
            new Cliente
            {
                ID = 2,
                Nombre = "Pedri",
                FechaAlta = DateTime.Parse(DateTime.Today.ToString()),
                Correo = "pedripotter@barcampeonlliga2024_2025.com"
            }
        };

        public IActionResult Index()
        {
            return View();
        }

        // GET: ListadoClientes
        public IActionResult ListadoClientes()
        {
            return View(listaClientes);
        }
    }
}
