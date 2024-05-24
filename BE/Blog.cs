using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Blog
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string? Title2 { get; set; }
        public string Content { get; set; }
        public string? Content2 { get; set; }
        public string? Content3 { get; set; }
        public string? Content4 { get; set; }
        public string? TompNailİmage { get; set; }
        public string? İmage { get; set; }
        public string? İmage1 { get; set; }
        public string? İmage2 { get; set; }
        public string? İmage3 { get; set; }
        public string? İmage4 { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }
      
        public List<Comment> comments { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
