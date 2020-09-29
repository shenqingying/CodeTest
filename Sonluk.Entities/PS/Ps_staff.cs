using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.PS
{
    public class Ps_staff
    {
        private string _Inits;

        public string Inits
        {
            get { return _Inits; }
            set { _Inits = value; }
        }
        private string _Pernr;

        public string Pernr
        {
            get { return _Pernr; }
            set { _Pernr = value; }
        }
        private string _Rufnm;

        public string Rufnm
        {
            get { return _Rufnm; }
            set { _Rufnm = value; }
        }
    }
}
