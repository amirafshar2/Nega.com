using Microsoft.AspNetCore.Mvc;

namespace Negacom.Areas.Admin.ViewComponents.Notification
{
    public class GetNotification :ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
