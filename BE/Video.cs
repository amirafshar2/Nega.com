using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Video
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string VideoLink { get; set; }
        public string picture { get; set; }
        public int View {  get; set; }  
        public bool Status { get; set; }
    }
}
