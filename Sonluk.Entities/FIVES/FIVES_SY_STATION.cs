using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.FIVES
{
    public class FIVES_SY_STATION
    {
        private int _SID;  //负责人ID

        public int SID
        {
            get { return _SID; }
            set { _SID = value; }
        }
        private string _MS;  //负责人描述

        public string MS
        {
            get { return _MS; }
            set { _MS = value; }
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
