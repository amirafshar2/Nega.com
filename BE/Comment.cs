using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Comment
    {
        public int id { get; set; }
        public string UserName { get; set; }        
        public string Emil { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }        
        public bool Status { get; set; }      
        
    }
}
