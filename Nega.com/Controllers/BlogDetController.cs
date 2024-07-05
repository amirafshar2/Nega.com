using BE;
using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Net.Mime;
using System.Web.Helpers;
using Negacom.Models;
using System.Linq.Expressions;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Negacom.Areas.Admin.Models;

namespace Negacom.Controllers
{


    public class BlogDetController : Controller
    {
        private readonly UserManager<User> _userManager;
        BlogManager _blogbll = new BlogManager(new EFBlogRepository());
        CommentManager _commentbll = new CommentManager(new EFCommentRepository());
        ReplayManager _Replaybll = new ReplayManager(new EFReplayRepository());
        public BlogDetController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var val = _blogbll.ReadBlogsWhiteRelById(id);
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user != null)
            {
                HttpContext.Session.SetInt32("userid", user.Id);

            }
            return View(val);
        }

        [HttpPost]
        public IActionResult CreateComment([FromBody] CommentModel c)
        {
            var userId = HttpContext.Session.GetInt32("userid");
            if (userId != null)
            {
                Comment cc = new Comment
                {
                    userid = Convert.ToInt32(userId),
                    Status = true,
                    Date = DateTime.Now,
                    Content = c.Content,
                    BlogId = c.BlogId
                };
                _commentbll.Add(cc);
                return Ok(new { success = true, message = "Comment added successfully" });
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpGet]
        public IActionResult GetBlogComments(int blogId)
        {

            List<CommentModel> cmm = new List<CommentModel>();
            try
            {
                var comments = _commentbll.GetCommentWithRelation(blogId); // Örneğin, ilgili blogun yorumlarını almak için uygun bir metot kullanın
                foreach (var item in comments)
                {
                    CommentModel cm = new CommentModel();
                    cm.userid = item.userid;
                    cm.id = item.id;
                    cm.Emil = item.Emil;
                    cm.Date = item.Date;
                    cm.Content = item.Content;
                    cm.username = item.user.Name;
                    cm.userpic = item.user.Picture;
                    cm.BlogId = item.BlogId;
                    cm.Status = item.Status;
                    cmm.Add(cm);
                }
                return Json(cmm); // Verileri JSON formatında döndürün
            }
            catch (Exception)
            {
                // Hata durumunu loglayabilirsiniz
                return StatusCode(500, "Internal server error"); // İstekte bir hata oluşursa 500 hatası döndürün
            }
        }
        [HttpGet]
        public IActionResult GetCommentReplay(int id)
        {
            List<ReplayModel> replayModels = new List<ReplayModel>();
            try
            {
                var CommentRole = _Replaybll.Replay_bay_comment_id(id);
                foreach (var item in CommentRole)
                {
                    ReplayModel r = new ReplayModel()
                    {
                        Id = item.Id,
                        Content = item.Content,
                        CreatedAt = item.CreatedAt,
                        CommentId = item.CommentId,
                        ParentReplyId = item.ParentReplyId,
                        userid = item.userid,
                        Username = item.User.Name,
                        userpic = item.User.Picture
                    };
                    replayModels.Add(r);
                }
                return Json(replayModels);
            }
            catch (Exception)
            {

                return StatusCode(500, "Internal server error");
            }

        }

        [HttpPost]
        public IActionResult CreateReplay([FromBody] ReplayModel replayData)
        {
            bool control = true;
            try
            {
                var userId = HttpContext.Session.GetInt32("userid");
                if (userId != null)
                {
                    // Yorumun benzersizliğini kontrol etme
                    Reply re = new Reply()
                    {
                        Content = replayData.Content,
                        CommentId = replayData.CommentId,
                        userid = (int)userId,
                        CreatedAt = DateTime.Now
                    };
                    var existingReplay = _Replaybll.GetAll()
                        .FirstOrDefault(r => r.userid == userId
                                             && r.CommentId == replayData.CommentId
                                             && r.Content == replayData.Content
                                             && (DateTime.Now - r.CreatedAt).TotalSeconds < 60);

                    if (existingReplay != null)
                    {
                        return BadRequest("You have already posted this replay recently.");
                    }
                    else
                    {
                        if (control)
                        {

                            _Replaybll.Add(re);
                            control = false;
                            return Ok(new { success = true, message = "Replay added successfully" });
                        }
                        else
                        {
                            return BadRequest("You have already posted this replay recently.");
                        }
                    }

                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
            control = true;
        }


    }
}
