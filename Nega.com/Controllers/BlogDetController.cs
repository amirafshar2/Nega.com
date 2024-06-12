using BE;
using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Net.Mime;
using System.Web.Helpers;

namespace Negacom.Controllers
{


    public class BlogDetController : Controller
    {
        private readonly UserManager<User> _userManager;
        BlogManager _blogbll = new BlogManager(new EFBlogRepository());
        CommentManager _commentbll = new CommentManager(new EFCommentRepository());
        public BlogDetController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var val = _blogbll.ReadBlogsWhiteRelById(id);
            var user = await _userManager.GetUserAsync(HttpContext.User);
            TempData["userid"] = user.Id;
            return View(val);
        }

        [HttpPost]
        public void CreateComment(Comment c)
        {
            var user = Convert.ToInt32(TempData["userid"]);
            if (user != 0)
            {
                c.userid = user;
                c.Status = true;
                c.Date = DateTime.Now;
                _commentbll.Add(c);
               
            }
            else
            {
               View("~/Areas/Admin/Views/Login/Index.cshtml");
            }
        }

        [HttpGet]
        public IActionResult GetBlogComments(int blogId)
        {
            var comments = _commentbll.GetCommentWithRelation(blogId);
            return Json(comments);
        }
    }
    }
