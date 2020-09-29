using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.FIVES
{
    public class FIVES_SY_CHECKPOINT_POINTCATEGROY
    {
        private int _POINTID;  //检查点ID

        public int POINTID
        {
            get { return _POINTID; }
            set { _POINTID = value; }
        }
        private int _CATEGROYID;  //检查点分类ID

        public int CATEGROYID
        {
            get { return _CATEGROYID; }
            set { _CATEGROYID = value; }
        }

    }
}
