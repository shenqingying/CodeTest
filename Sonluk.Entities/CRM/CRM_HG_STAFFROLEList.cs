using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_HG_STAFFROLEList
    {
        int _STAFFID;

        public int STAFFID
        {
            get { return _STAFFID; }
            set { _STAFFID = value; }
        }
        int _ROLEID;

        public int ROLEID
        {
            get { return _ROLEID; }
            set { _ROLEID = value; }
        }
        
        string _ROLEIDDES;

        public string ROLEIDDES
        {
            get { return _ROLEIDDES; }
            set { _ROLEIDDES = value; }
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
    }
}
