using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;

namespace Negacom.Areas.Admin.Models
{
    public class UserModel
    {
        public  string Name { get; set; }
        public  int Id { get; set; }
        public string Family { get; set; }
        public string Email { get; set; }
        public string  password{ get; set; }
        public string  Confirmpassword{ get; set; }
        public IFormFile Picture { get; set; }
        public string picstring { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public bool Status { get; set; }
        public string StatusİnCompany { get; set; }
        public string About { get; set; }
        public string Facebook { get; set; }
        public string İnstagram { get; set; }
        public string Telegram { get; set; }
        public string UserName { get; set; }

        
    }
}
