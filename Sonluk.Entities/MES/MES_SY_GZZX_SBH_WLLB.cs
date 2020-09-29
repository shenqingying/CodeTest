using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_GZZX_SBH_WLLB
    {
        private string _SBBH;

        public string SBBH
        {
            get { return _SBBH; }
            set { _SBBH = value; }
        }

        private int _WLLBID;

        public int WLLBID
        {
            get { return _WLLBID; }
            set { _WLLBID = value; }
        }


        private string _WLLBNAME;

        public string WLLBNAME
        {
            get { return _WLLBNAME; }
            set { _WLLBNAME = value; }
        }

        private bool _LAY_CHECKED;

        public bool LAY_CHECKED
        {
            get { return _LAY_CHECKED; }
            set { _LAY_CHECKED = value; }
        }
    }
}
