using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.FIVES
{
    public class FIVES_SY_PRINCIPALCATEGROY
    {
        private int _SID;  //岗位ID

        public int SID
        {
            get { return _SID; }
            set { _SID = value; }
        }
        private int _CATEGROYID;  //检查点分类ID

        public int CATEGROYID
        {
            get { return _CATEGROYID; }
            set { _CATEGROYID = value; }
        }

    }
}
