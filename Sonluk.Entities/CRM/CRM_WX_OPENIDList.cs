using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_WX_OPENIDList : CRM_WX_OPENID
    {
        int _DEPID;

        public int DEPID
        {
            get { return _DEPID; }
            set { _DEPID = value; }
        }
        string _DEPIDDES;

        public string DEPIDDES
        {
            get { return _DEPIDDES; }
            set { _DEPIDDES = value; }
        }
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


    }
}
