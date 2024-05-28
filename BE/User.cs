using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class User :IdentityUser<int>
    {
        
        public string Name { get; set; }
        public string Family { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Picture { get; set; }
        public string IdNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string? Address { get; set; }
        public DateTime ReqesterDate{ get; set; }
        public bool Status { get; set; }
        public string? StatusİnCompany { get; set; }
        public string? About { get; set; }
        public string Facebook { get; set; }
        public string İnstagram { get; set; }
        public string Telegram { get; set; }
        public List<Blog> Blogs { get; set; }
        public int ContorimCod { get; set; }

    }
}
