using BE;
using Microsoft.AspNetCore.Http;
using System;

namespace Negacom.Areas.Admin.Models
{
    public class PortfolioMOdel
    {
        public int id { get; set; }
        public string Title { get; set; }
        public String Brand { get; set; }
        public IFormFile Picture { get; set; }
        public string Link { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }
        public int categoryid { get; set; }
    }
}
