using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.PS
{
    public class ZSL_PSS_IN_LJXJ
    {
        private string _MENGE;
        private string _LGPLA;
        private string _VERME;

        public string VERME
        {
            get { return _VERME; }
            set { _VERME = value; }
        }

        public string LGPLA
        {
            get { return _LGPLA; }
            set { _LGPLA = value; }
        }

        public string MENGE
        {
            get { return _MENGE; }
            set { _MENGE = value; }
        }

    }
}
