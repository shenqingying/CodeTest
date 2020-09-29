using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.FIVES
{
    public class FIVES_SY_POINTCATEGROY_DETAIL
    {
        private int _CATEGROYID;  //检查点分类ID

        public int CATEGROYID
        {
            get { return _CATEGROYID; }
            set { _CATEGROYID = value; }
        }
        private int _DETAILID;  //检查明细ID

        public int DETAILID
        {
            get { return _DETAILID; }
            set { _DETAILID = value; }
        }

    }
}
