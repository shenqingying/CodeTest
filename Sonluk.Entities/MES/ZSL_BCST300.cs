using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class ZSL_BCST300
    {
        private string _WERKS;

        public string WERKS
        {
            get { return _WERKS; }
            set { _WERKS = value; }
        }

        private string _ARBPL;

        public string ARBPL
        {
            get { return _ARBPL; }
            set { _ARBPL = value; }
        }

        private string _KTEXT;

        public string KTEXT
        {
            get { return _KTEXT; }
            set { _KTEXT = value; }
        }
    }
}
