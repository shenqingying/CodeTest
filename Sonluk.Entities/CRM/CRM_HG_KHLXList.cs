using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_HG_KHLXList
    {
        int _STAFFKHLXID;

        public int STAFFKHLXID
        {
            get { return _STAFFKHLXID; }
            set { _STAFFKHLXID = value; }
        }
        int _DICID;

        public int DICID
        {
            get { return _DICID; }
            set { _DICID = value; }
        }
        string _STAFFKHLXMC;

        public string STAFFKHLXMC
        {
            get { return _STAFFKHLXMC; }
            set { _STAFFKHLXMC = value; }
        }
        string _DICNAME;

        public string DICNAME
        {
            get { return _DICNAME; }
            set { _DICNAME = value; }
        }
    }
}
