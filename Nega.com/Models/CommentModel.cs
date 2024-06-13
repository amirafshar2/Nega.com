using BE;
using System.Collections.Generic;
using System;

namespace Negacom.Models
{
    
    
    
    public class CommentModel
    {
        public int id { get; set; }

        public string Emil { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public int BlogId { get; set; }
       
        public int userid { get; set; }
       public string username { get; set; }
        public string userpic { get; set; } 
       
    }
}
