using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.EM
{
    public class EM_SY_EMTYPE_LAY_LIST
    {
        int _STAFFID;

        public int STAFFID
        {
            get { return _STAFFID; }
            set { _STAFFID = value; }
        }
        int _EMTYPEID;

        public int EMTYPEID
        {
            get { return _EMTYPEID; }
            set { _EMTYPEID = value; }
        }
        bool _LAY_CHECKED;

        public bool LAY_CHECKED
        {
            get { return _LAY_CHECKED; }
            set { _LAY_CHECKED = value; }
        }
        string _MXNAME;

        public string MXNAME
        {
            get { return _MXNAME; }
            set { _MXNAME = value; }
        }
    }
}
