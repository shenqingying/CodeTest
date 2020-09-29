using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.EM
{
    public class EM_SY_SBBHMANUAL
    {
        private string _SBBH;  //设备编号

        public string SBBH
        {
            get { return _SBBH; }
            set { _SBBH = value; }
        }
        private int _MANUALID;  //电子文档ID

        public int MANUALID
        {
            get { return _MANUALID; }
            set { _MANUALID = value; }
        }
        private int _XH;  //序号

        public int XH
        {
            get { return _XH; }
            set { _XH = value; }
        }
        string _SBBHMS;

        public string SBBHMS
        {
            get { return _SBBHMS; }
            set { _SBBHMS = value; }
        }
        string _MANUALMS;

        public string MANUALMS
        {
            get { return _MANUALMS; }
            set { _MANUALMS = value; }
        }

    }
}
