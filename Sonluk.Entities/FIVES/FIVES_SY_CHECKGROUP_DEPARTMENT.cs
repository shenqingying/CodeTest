using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.FIVES
{
    public class FIVES_SY_CHECKGROUP_DEPARTMENT
    {
        private int _GID;  //权限分组ID

        public int GID
        {
            get { return _GID; }
            set { _GID = value; }
        }
        private int _DID;  //部门ID

        public int DID
        {
            get { return _DID; }
            set { _DID = value; }
        }

    }
}
