using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.FIVES
{
    public class FIVES_SY_STAFF_DEP
    {
        private int _STAFFID;  //人员ID

        public int STAFFID
        {
            get { return _STAFFID; }
            set { _STAFFID = value; }
        }
        private int _DEPID;  //部门ID

        public int DEPID
        {
            get { return _DEPID; }
            set { _DEPID = value; }
        }
        private int _XJSTATUS;  //巡检状态

        public int XJSTATUS
        {
            get { return _XJSTATUS; }
            set { _XJSTATUS = value; }
        }
        private int _CJSTATUS;  //抽检状态

        public int CJSTATUS
        {
            get { return _CJSTATUS; }
            set { _CJSTATUS = value; }
        }
        private int _DJSTATUS;

        public int DJSTATUS
        {
            get { return _DJSTATUS; }
            set { _DJSTATUS = value; }
        }
        private int _TZSTATUS;

        public int TZSTATUS
        {
            get { return _TZSTATUS; }
            set { _TZSTATUS = value; }
        }

    }
}
