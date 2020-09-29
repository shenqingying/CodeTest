using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_KQ_QQList
    {
        string _STAFFNAME;

        public string STAFFNAME
        {
            get { return _STAFFNAME; }
            set { _STAFFNAME = value; }
        }
        int _STAFFID;

        public int STAFFID
        {
            get { return _STAFFID; }
            set { _STAFFID = value; }
        }
        int _SBQD;

        public int SBQD
        {
            get { return _SBQD; }
            set { _SBQD = value; }
        }
        int _XBQD;

        public int XBQD
        {
            get { return _XBQD; }
            set { _XBQD = value; }
        }
        string _RQ;

        public string RQ
        {
            get { return _RQ; }
            set { _RQ = value; }
        }
    }
}
