using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.FIVES
{
    public class FIVES_SY_CHECKDETAILS
    {
        private int _DETAILID;  //检查明细ID

        public int DETAILID
        {
            get { return _DETAILID; }
            set { _DETAILID = value; }
        }
        private int _CATEGROYID;  //检查分类ID

        public int CATEGROYID
        {
            get { return _CATEGROYID; }
            set { _CATEGROYID = value; }
        }
        private string _DETAILMS;  //检查明细描述

        public string DETAILMS
        {
            get { return _DETAILMS; }
            set { _DETAILMS = value; }
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
