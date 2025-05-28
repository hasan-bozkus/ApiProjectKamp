using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKamp.WebUI.ViewComponents.AdminLayoutViewComponent
{
    public class _NavbarAdminLayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
