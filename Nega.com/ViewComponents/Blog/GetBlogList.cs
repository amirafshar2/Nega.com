using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Negacom.ViewComponents.Blog
{
	public class GetBlogList : ViewComponent
	{
		BlogManager _blogbll = new BlogManager(new EFBlogRepository());
		public IViewComponentResult Invoke()
		{
			var q = _blogbll.GetAll();
			q.Reverse();
			q.Take(10);
			return View(q);
		}
	}
}
