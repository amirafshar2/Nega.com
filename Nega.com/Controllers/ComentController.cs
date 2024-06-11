using BE;
using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Negacom.Controllers
{
    public class ComentController : Controller
    {
        CommentManager _commentbll = new CommentManager(new EFCommentRepository());
        private readonly UserManager<User> _userManager;

        public ComentController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(Comment c)
        {
            if (c.Content == null)
            {
                ModelState.AddModelError("", "Content cannot be left blank");
                return Json(new { success = false, message = "Content cannot be left blank" });
            }
            else
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    // Kullanıcı oturum açmamış, oturum açma sayfasına yönlendir.
                    return Json(new { success = false });
                }
                else
                {
                    c.userid = user.Id;
                    c.Status = true;
                    c.Date = DateTime.Now;
                    c.Emil = user.Email;
                    _commentbll.Add(c);
                    return Json(new { success = true });
                }
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
