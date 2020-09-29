using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_ROLE_ASSEMBLE_JS_LAY
    {
        private bool _LAY_CHECKED;

        public bool LAY_CHECKED
        {
            get { return _LAY_CHECKED; }
            set { _LAY_CHECKED = value; }
        }

        private int _ROLEID;

        public int ROLEID
        {
            get { return _ROLEID; }
            set { _ROLEID = value; }
        }

        private string _ROLENAME;

        public string ROLENAME
        {
            get { return _ROLENAME; }
            set { _ROLENAME = value; }
        }

        private int _STAFFID;

        public int STAFFID
        {
            get { return _STAFFID; }
            set { _STAFFID = value; }
        }

        private string _ROLEMEMO;

        public string ROLEMEMO
        {
            get { return _ROLEMEMO; }
            set { _ROLEMEMO = value; }
        }
    }
}
