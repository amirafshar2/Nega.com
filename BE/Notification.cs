using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Notification
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
        public string Type { get; set; }
        public string Recipient { get; set; }
        public bool ReadStatus { get; set; }       
        public string Url { get; set; }
        public string Actions { get; set; }
    }
}
