using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_BF_REPORT_BYSTAFF_SUMMARYTOTAL
    {
        int _STAFFID;

        public int STAFFID
        {
            get { return _STAFFID; }
            set { _STAFFID = value; }
        }
        string _STAFFNAME;

        public string STAFFNAME
        {
            get { return _STAFFNAME; }
            set { _STAFFNAME = value; }
        }
        string _STAFFNO;

        public string STAFFNO
        {
            get { return _STAFFNO; }
            set { _STAFFNO = value; }
        }
        string _DEPNAME;

        public string DEPNAME
        {
            get { return _DEPNAME; }
            set { _DEPNAME = value; }
        }
        int _TOTAL_COUNT;

        public int TOTAL_COUNT
        {
            get { return _TOTAL_COUNT; }
            set { _TOTAL_COUNT = value; }
        }



    }
}
