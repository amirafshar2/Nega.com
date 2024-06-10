using Microsoft.AspNetCore.Mvc;

namespace Negacom.ViewComponents.Comment
{
    public class CommentAdd:ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
