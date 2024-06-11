using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Reply
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CommentId { get; set; }
        public Comment Comment { get; set; }

        public int? ParentReplyId { get; set; }
        public Reply ParentReply { get; set; }
        public List<Reply> Replies { get; set; } = new List<Reply>();
        public int userid { get; set; }
        public User User { get; set; }
    }
}
