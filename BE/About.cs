using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class About
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Title1 { get; set; }
        public string? Title2 { get; set; }
        public string Content { get; set; }
        public string? Content2 { get; set; }
        public string İmage1 { get; set; }  
        public string? İmage2 { get; set; }
        public bool Status { get; set; }
        public string MapLocation { get; set; }
    }
}
