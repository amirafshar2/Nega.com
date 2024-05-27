using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class CustomerComment
    {
        public int id { get; set; }
        public string NameSurName { get; set; }
        public string Brand { get; set; }
        public string Picture { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
