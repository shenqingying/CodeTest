using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_EXCEPTION
    {
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _EXCEPTIONINFO;

        public string EXCEPTIONINFO
        {
            get { return _EXCEPTIONINFO; }
            set { _EXCEPTIONINFO = value; }
        }

        private string _EXCEPTIONTIME;

        public string EXCEPTIONTIME
        {
            get { return _EXCEPTIONTIME; }
            set { _EXCEPTIONTIME = value; }
        }

        private string _EXCEPTIONMK;

        public string EXCEPTIONMK
        {
            get { return _EXCEPTIONMK; }
            set { _EXCEPTIONMK = value; }
        }
    }
}
