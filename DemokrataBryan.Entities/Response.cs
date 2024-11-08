using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemokrataBryan.Entities
{
    public class Response
    {
        public bool success { get; set; }
        public bool error { get; set; }
        public string message { get; set; }
        public dynamic result { get; set; }
    }
}
