using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.FIVES
{
    public class FIVES_SY_CHECKDETAILCATEGROY
    {
        private int _CATEGROYID;  //检查明细ID

        public int CATEGROYID
        {
            get { return _CATEGROYID; }
            set { _CATEGROYID = value; }
        }
        private string _CATEGROYMS;  //检查明细描述

        public string CATEGROYMS
        {
            get { return _CATEGROYMS; }
            set { _CATEGROYMS = value; }
        }
        private int _ACTION;  //状态

        public int ACTION
        {
            get { return _ACTION; }
            set { _ACTION = value; }
        }
        private bool _ISDELETE;  //是否删除

        public bool ISDELETE
        {
            get { return _ISDELETE; }
            set { _ISDELETE = value; }
        }

    }
}
