using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.PS
{
    public class ZSL_GXFHTABLE
    {
        List<ZSL_GXCN> _ZSL_GXCN;

        public List<ZSL_GXCN> ZSL_GXCN
        {
            get { return _ZSL_GXCN; }
            set { _ZSL_GXCN = value; }
        }
        List<ZSL_ACTIVITY> _ZSL_ACTIVITY;

        public List<ZSL_ACTIVITY> ZSL_ACTIVITY
        {
            get { return _ZSL_ACTIVITY; }
            set { _ZSL_ACTIVITY = value; }
        }


        List<ZSL_ACTIVITY_T> _ZSL_ACTIVITY_T;

        public List<ZSL_ACTIVITY_T> ZSL_ACTIVITY_T
        {
            get { return _ZSL_ACTIVITY_T; }
            set { _ZSL_ACTIVITY_T = value; }
        }


        List<ZSL_GXCN_DAY> _ZSL_GXCN_DAY;

        public List<ZSL_GXCN_DAY> ZSL_GXCN_DAY
        {
            get { return _ZSL_GXCN_DAY; }
            set { _ZSL_GXCN_DAY = value; }
        }


        List<ZSL_GXCN_WEEK> _ZSL_GXCN_WEEK;

        public List<ZSL_GXCN_WEEK> ZSL_GXCN_WEEK
        {
            get { return _ZSL_GXCN_WEEK; }
            set { _ZSL_GXCN_WEEK = value; }
        }




        List<ZSL_GXCN_MONTH> _ZSL_GXCN_MONTH;

        public List<ZSL_GXCN_MONTH> ZSL_GXCN_MONTH
        {
            get { return _ZSL_GXCN_MONTH; }
            set { _ZSL_GXCN_MONTH = value; }
        }


        PS_MSG _PS_MSG;

        public PS_MSG PS_MSG
        {
            get { return _PS_MSG; }
            set { _PS_MSG = value; }
        }
        string _E_DAY;

        public string E_DAY
        {
            get { return _E_DAY; }
            set { _E_DAY = value; }
        }
        string _E_DAY1;

        public string E_DAY1
        {
            get { return _E_DAY1; }
            set { _E_DAY1 = value; }
        }
    }
}
