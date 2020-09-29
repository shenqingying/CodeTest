using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
   public class CRM_HG_ROLE
    {
        int _ROLEID;

        public int ROLEID
        {
            get { return _ROLEID; }
            set { _ROLEID = value; }
        }
        string _ROLENAME;

        public string ROLENAME
        {
            get { return _ROLENAME; }
            set { _ROLENAME = value; }
        }
        string _ROLEMEMO;

        public string ROLEMEMO
        {
            get { return _ROLEMEMO; }
            set { _ROLEMEMO = value; }
        }
        int _ISACTIVE;

        public int ISACTIVE
        {
            get { return _ISACTIVE; }
            set { _ISACTIVE = value; }
        }
    }
}
