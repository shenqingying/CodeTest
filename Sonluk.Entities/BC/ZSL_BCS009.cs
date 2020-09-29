using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.BC
{
    public class ZSL_BCS009
    {
        private string _KUNNR;

        public string KUNNR
        {
            get { return _KUNNR; }
            set { _KUNNR = value; }
        }

        private string _NAME1;

        public string NAME1
        {
            get { return _NAME1; }
            set { _NAME1 = value; }
        }

        private string _BEZEI;

        public string BEZEI
        {
            get { return _BEZEI; }
            set { _BEZEI = value; }
        }

        private string _ORT01;

        public string ORT01
        {
            get { return _ORT01; }
            set { _ORT01 = value; }
        }
    }
}
