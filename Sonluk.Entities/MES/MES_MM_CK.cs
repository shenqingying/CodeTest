using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_MM_CK
    {
        private string _CKDM;

        public string CKDM
        {
            get { return _CKDM; }
            set { _CKDM = value; }
        }

        private string _CKMS;

        public string CKMS
        {
            get { return _CKMS; }
            set { _CKMS = value; }
        }

        private int _ISACTION;

        public int ISACTION
        {
            get { return _ISACTION; }
            set { _ISACTION = value; }
        }

        private string _GC;

        public string GC
        {
            get { return _GC; }
            set { _GC = value; }
        }


        private int _STAFFID;

        public int STAFFID
        {
            get { return _STAFFID; }
            set { _STAFFID = value; }
        }
        private string _ROLENAME;

        public string ROLENAME
        {
            get { return _ROLENAME; }
            set { _ROLENAME = value; }
        }
    }
}
