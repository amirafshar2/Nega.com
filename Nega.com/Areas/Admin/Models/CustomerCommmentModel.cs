using Microsoft.AspNetCore.Http;
using System;

namespace Negacom.Areas.Admin.Models
{
    public class CustomerCommmentModel
    {
        public int id { get; set; }
        public string NameSurName { get; set; }
        public string Brand { get; set; }
        public IFormFile Picture { get; set; }
        public string Picturestring { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
