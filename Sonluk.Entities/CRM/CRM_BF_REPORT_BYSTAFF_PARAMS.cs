using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_BF_REPORT_BYSTAFF_PARAMS
    {
        string _BEGINDATE;

        public string BEGINDATE
        {
            get { return _BEGINDATE; }
            set { _BEGINDATE = value; }
        }
        string _ENDDATE;

        public string ENDDATE
        {
            get { return _ENDDATE; }
            set { _ENDDATE = value; }
        }
        int _DEPID;

        public int DEPID
        {
            get { return _DEPID; }
            set { _DEPID = value; }
        }
        int _STAFFLX;

        public int STAFFLX
        {
            get { return _STAFFLX; }
            set { _STAFFLX = value; }
        }
        int _STAFFID;

        public int STAFFID
        {
            get { return _STAFFID; }
            set { _STAFFID = value; }
        }
        int _BFLX;

        public int BFLX
        {
            get { return _BFLX; }
            set { _BFLX = value; }
        }



    }
}
