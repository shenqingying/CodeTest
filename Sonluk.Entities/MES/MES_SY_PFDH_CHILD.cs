using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_PFDH_CHILD
    {
        private string _GC;

        public string GC
        {
            get { return _GC; }
            set { _GC = value; }
        }

        private string _PFDH;

        public string PFDH
        {
            get { return _PFDH; }
            set { _PFDH = value; }
        }

        private int _PFLB;

        public int PFLB
        {
            get { return _PFLB; }
            set { _PFLB = value; }
        }

        private string _WLH;

        public string WLH
        {
            get { return _WLH; }
            set { _WLH = value; }
        }

        private string _WLMS;

        public string WLMS
        {
            get { return _WLMS; }
            set { _WLMS = value; }
        }
        private string _REMARK;

        public string REMARK
        {
            get { return _REMARK; }
            set { _REMARK = value; }
        }
    }
}
