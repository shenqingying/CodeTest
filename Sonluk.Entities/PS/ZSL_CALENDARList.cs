using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.PS
{
    public class ZSL_CALENDARList
    {
        List<ZSL_WORKDAY> _ZSL_WORKDAY;

        public List<ZSL_WORKDAY> ZSL_WORKDAY
        {
            get { return _ZSL_WORKDAY; }
            set { _ZSL_WORKDAY = value; }
        }
        List<ZSL_CALENDAR> _ZSL_CALENDAR;

        public List<ZSL_CALENDAR> ZSL_CALENDAR
        {
            get { return _ZSL_CALENDAR; }
            set { _ZSL_CALENDAR = value; }
        }
        PS_MSG _T_MSG;

        public PS_MSG T_MSG
        {
            get { return _T_MSG; }
            set { _T_MSG = value; }
        }
    }
}
