using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKamp.WebUI.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
