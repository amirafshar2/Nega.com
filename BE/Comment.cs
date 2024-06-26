﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Comment
    {
        public int id { get; set; }
                
        public string Emil { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }        
        public bool Status { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
        public int userid { get; set; }
        public User? user { get; set; }
        public List<Reply> replies { get; set; }
    }
}
