using Microsoft.AspNetCore.Mvc;

namespace Seguradora.Apresentacao.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
