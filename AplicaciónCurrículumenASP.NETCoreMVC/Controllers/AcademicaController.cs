using Microsoft.AspNetCore.Mvc;

namespace AplicaciónCurrículumenASP.NETCoreMVC.Controllers
{
    public class AcademicaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
