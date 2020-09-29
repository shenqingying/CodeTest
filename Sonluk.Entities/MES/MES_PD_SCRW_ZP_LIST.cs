using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_PD_SCRW_ZP_LIST
    {
        private int _SCRWID;

        public int SCRWID
        {
            get { return _SCRWID; }
            set { _SCRWID = value; }
        }

        private int _GDID;

        public int GDID
        {
            get { return _GDID; }
            set { _GDID = value; }
        }

        private string _RWBH;

        public string RWBH
        {
            get { return _RWBH; }
            set { _RWBH = value; }
        }
    }
}
