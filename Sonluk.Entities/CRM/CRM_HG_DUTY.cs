using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_HG_DUTY
    {
        int _DUTYID;

        public int DUTYID
        {
            get { return _DUTYID; }
            set { _DUTYID = value; }
        }
        string _DUTYNAME;

        public string DUTYNAME
        {
            get { return _DUTYNAME; }
            set { _DUTYNAME = value; }
        }
        string _DUTYMEMO;

        public string DUTYMEMO
        {
            get { return _DUTYMEMO; }
            set { _DUTYMEMO = value; }
        }
        string _DUTYBASE;

        public string DUTYBASE
        {
            get { return _DUTYBASE; }
            set { _DUTYBASE = value; }
        }
        int _ISACTIVE;

        public int ISACTIVE
        {
            get { return _ISACTIVE; }
            set { _ISACTIVE = value; }
        }

    }
}
