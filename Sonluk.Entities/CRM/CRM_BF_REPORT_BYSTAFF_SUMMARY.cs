using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_BF_REPORT_BYSTAFF_SUMMARY
    {
        int _BFLX;

        public int BFLX
        {
            get { return _BFLX; }
            set { _BFLX = value; }
        }
        string _BFLXDES;

        public string BFLXDES
        {
            get { return _BFLXDES; }
            set { _BFLXDES = value; }
        }
        int _FINISHCOUNTS;

        public int FINISHCOUNTS
        {
            get { return _FINISHCOUNTS; }
            set { _FINISHCOUNTS = value; }
        }


    }
}
