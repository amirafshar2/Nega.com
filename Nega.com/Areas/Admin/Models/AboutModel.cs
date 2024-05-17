using Microsoft.AspNetCore.Http;

namespace Negacom.Areas.Admin.Models
{
 
    
    
    
    
    
    public class AboutModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Title1 { get; set; }
        public string? Title2 { get; set; }
        public string Content { get; set; }
        public string? Content2 { get; set; }
        public IFormFile? İmage1 { get; set; }
        public IFormFile? İmage2 { get; set; }
        public bool Status { get; set; }
        public string MapLocation { get; set; }
    }
}
