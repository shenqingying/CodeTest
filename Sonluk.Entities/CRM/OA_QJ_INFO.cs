using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class OA_QJ_INFO
    {
        string _ID;

        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        string _FINISHEDFLAG;

        public string FINISHEDFLAG
        {
            get { return _FINISHEDFLAG; }
            set { _FINISHEDFLAG = value; }
        }
    }
}
