using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKamp.WebUI.ViewComponents.AdminLayoutViewComponent
{
    public class _HeadAdminLayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
