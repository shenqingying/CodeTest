using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.EM
{
    public class EM_SY_STAFF_EMTYPE
    {
        private int _EMTYPEID;  //指导书类别ID

        public int EMTYPEID
        {
            get { return _EMTYPEID; }
            set { _EMTYPEID = value; }
        }
        private int _STAFFID;  //人员ID

        public int STAFFID
        {
            get { return _STAFFID; }
            set { _STAFFID = value; }
        }

    }
}
