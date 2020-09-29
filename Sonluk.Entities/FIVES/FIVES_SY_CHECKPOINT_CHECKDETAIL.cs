using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.FIVES
{
    public class FIVES_SY_CHECKPOINT_CHECKDETAIL
    {
        private int _POINTID;  //检查点ID

        public int POINTID
        {
            get { return _POINTID; }
            set { _POINTID = value; }
        }
        private int _DETAILID;  //检查明细ID

        public int DETAILID
        {
            get { return _DETAILID; }
            set { _DETAILID = value; }
        }
     

    }
}
