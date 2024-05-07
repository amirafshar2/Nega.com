using Microsoft.AspNetCore.Http;
using System;

namespace Nega.com.Areas.Admin.Models
{
   
    
    public class PackageModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public IFormFile Picture { get; set; }
        public string? Content2 { get; set; }
        public string? Content3 { get; set; }
        public string? Content4 { get; set; }
        public string? Content5 { get; set; }
        public string? Content6 { get; set; }
        public string? Content7 { get; set; }
        public string? Content8 { get; set; }
        public string? Content9 { get; set; }
        public string? Content10 { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
