using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_BF_REPORTSUMMARY
    {
        string _CRMID;

        public string CRMID
        {
            get { return _CRMID; }
            set { _CRMID = value; }
        }
        string _KHMC;

        public string KHMC
        {
            get { return _KHMC; }
            set { _KHMC = value; }
        }
        int _BFCS;

        public int BFCS
        {
            get { return _BFCS; }
            set { _BFCS = value; }
        }
        int _BFKH;

        public int BFKH
        {
            get { return _BFKH; }
            set { _BFKH = value; }
        }
    }
}
