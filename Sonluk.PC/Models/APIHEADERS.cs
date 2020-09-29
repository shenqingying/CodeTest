using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.PC.Models
{
    public class APIHEADERS
    {
        private string _KEY;
        private string _VALUES;

        public string KEY { get => _KEY; set => _KEY = value; }
        public string VALUES { get => _VALUES; set => _VALUES = value; }
    }
}