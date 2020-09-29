﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.FIVES
{
    public class FIVES_SY_CHECKGROUP_STAFFList
    {
        private int _STAFFID;  //人员ID

        public int STAFFID
        {
            get { return _STAFFID; }
            set { _STAFFID = value; }
        }
        private int _GID;  //分组ID

        public int GID
        {
            get { return _GID; }
            set { _GID = value; }
        }
        private int _ACTION;  //是否激活

        public int ACTION
        {
            get { return _ACTION; }
            set { _ACTION = value; }
        }

        private string _STAFFNAME;

        public string STAFFNAME
        {
            get { return _STAFFNAME; }
            set { _STAFFNAME = value; }
        }
        private string _GNAME;

        public string GNAME
        {
            get { return _GNAME; }
            set { _GNAME = value; }
        }
    }
}
