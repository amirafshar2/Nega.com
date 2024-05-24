using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class UserRolee :IdentityRole<int>
    {
        
        public string  Name { get; set; }
        public bool Status { get; set; }
    }
}
