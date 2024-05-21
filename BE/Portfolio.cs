using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Portfolio
    {
        public int id { get; set; }
        public string Title { get; set; }
        public String Brand { get; set; }
        public string Picture { get; set; }
        public string Link { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }
        public int PortfolioCateoryid { get; set; }
        public PortfolioCateory Portfoliocategory { get; set; }
    }
}
