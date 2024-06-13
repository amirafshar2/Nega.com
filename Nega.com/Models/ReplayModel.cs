using BE;
using System;
using System.Collections.Generic;

namespace Negacom.Models








{ 
    public class ReplayModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CommentId { get; set; }
        public int? ParentReplyId { get; set; }
      
        public List<Reply> Replies { get; set; } = new List<Reply>();
        public int userid { get; set; }
        public string Username { get; set; }
        public string userpic { get; set; }
    }
}
