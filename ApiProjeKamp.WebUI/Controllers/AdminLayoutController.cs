using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKamp.WebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
