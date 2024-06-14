using System;

namespace Negacom.Controllers
{
    internal class CommentViewModel
    {
        public int Id { get; set; }
        public string Emil { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public int BlogId { get; set; }
        public int userid { get; set; }
        public string UserName { get; set; }
        public string UserPic { get; set; }
        public object Replies { get; set; }

    }
}