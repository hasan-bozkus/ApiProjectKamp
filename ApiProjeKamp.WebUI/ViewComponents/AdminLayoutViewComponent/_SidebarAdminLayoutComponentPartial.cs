using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKamp.WebUI.ViewComponents.AdminLayoutViewComponent
{
    public class _SidebarAdminLayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
