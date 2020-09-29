using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_PD_SCRW_UPDATE_IN
    {
        private string _RWBH;

        public string RWBH
        {
            get { return _RWBH; }
            set { _RWBH = value; }
        }
        private int _ISLEAVE;

        public int ISLEAVE
        {
            get { return _ISLEAVE; }
            set { _ISLEAVE = value; }
        }
    }
}
