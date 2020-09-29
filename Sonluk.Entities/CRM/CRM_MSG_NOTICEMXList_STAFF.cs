using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_MSG_NOTICEMXList_STAFF : CRM_MSG_NOTICEMX
    {
        string _STAFFNO;

        public string STAFFNO
        {
            get { return _STAFFNO; }
            set { _STAFFNO = value; }
        }
        string _STAFFNAME;

        public string STAFFNAME
        {
            get { return _STAFFNAME; }
            set { _STAFFNAME = value; }
        }
        int _STAFFLX;

        public int STAFFLX
        {
            get { return _STAFFLX; }
            set { _STAFFLX = value; }
        }
        int _DEPID;

        public int DEPID
        {
            get { return _DEPID; }
            set { _DEPID = value; }
        }
        string _USERLXDES;

        public string USERLXDES
        {
            get { return _USERLXDES; }
            set { _USERLXDES = value; }
        }
        string _STAFFLXDES;

        public string STAFFLXDES
        {
            get { return _STAFFLXDES; }
            set { _STAFFLXDES = value; }
        }
        string _DEPIDDES;

        public string DEPIDDES
        {
            get { return _DEPIDDES; }
            set { _DEPIDDES = value; }
        }




    }
}
