﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.FIVES
{
    public class FIVES_SY_PRINCIPALCATEGROYList
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
        string _SNAME;

        public string SNAME
        {
            get { return _SNAME; }
            set { _SNAME = value; }
        }
        string _CNAME;

        public string CNAME
        {
            get { return _CNAME; }
            set { _CNAME = value; }
        }
    }
}
