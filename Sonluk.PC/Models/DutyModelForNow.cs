using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.PC.Models
{
    public class DutyModelForNow
    {

        private int _dutyid;

        public int DUTYID
        {
            get { return _dutyid; }
            set { _dutyid = value; }
        }

        private string _dutyname;

        public string DUTYNAME
        {
            get { return _dutyname; }
            set { _dutyname = value; }
        }

        private string _dutymemo;

        public string DUTYMEMO
        {
            get { return _dutymemo; }
            set { _dutymemo = value; }
        }

        private string _dutybase;

        public string DUTYBASE
        {
            get { return _dutybase; }
            set { _dutybase = value; }
        }

        private int _isactive;

        public int ISACTIVE
        {
            get { return _isactive; }
            set { _isactive = value; }
        }




    }
}