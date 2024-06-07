using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace Negacom.Controllers
{
	public class PackageDetaleController : Controller
	{
		PackageManager _packagebll = new PackageManager(new EFpackageRepository());
		[HttpGet]
		public IActionResult Index(int id)
		{
			var val = _packagebll.GetById(id);
			return View(val);
		}
	}
}
