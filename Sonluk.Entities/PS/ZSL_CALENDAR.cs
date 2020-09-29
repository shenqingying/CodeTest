using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.PS
{
    public class ZSL_CALENDAR
    {
        string _CDATE;

        public string CDATE
        {
            get { return _CDATE; }
            set { _CDATE = value; }
        }
        string _WEEKNO;

        public string WEEKNO
        {
            get { return _WEEKNO; }
            set { _WEEKNO = value; }
        }
        string _ISHOILDAY;

        public string ISHOILDAY
        {
            get { return _ISHOILDAY; }
            set { _ISHOILDAY = value; }
        }
        string _ISWORKDAY;

        public string ISWORKDAY
        {
            get { return _ISWORKDAY; }
            set { _ISWORKDAY = value; }
        }



    }
}
