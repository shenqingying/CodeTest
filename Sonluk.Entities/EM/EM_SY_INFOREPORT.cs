using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.EM
{
    public  class EM_SY_INFOREPORT
    {
        private int _ID;  //逻辑ID

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private int _PLATFORMID;  //调用平台

        public int PLATFORMID
        {
            get { return _PLATFORMID; }
            set { _PLATFORMID = value; }
        }
        private string _PLATFORMMS;  //调用平台描述

        public string PLATFORMMS
        {
            get { return _PLATFORMMS; }
            set { _PLATFORMMS = value; }
        }
        private string _JLTIME;  //调用时间

        public string JLTIME
        {
            get { return _JLTIME; }
            set { _JLTIME = value; }
        }
        private int _STAFFID;  //调用人

        public int STAFFID
        {
            get { return _STAFFID; }
            set { _STAFFID = value; }
        }
        private string _STAFFNAME;  //调用人描述

        public string STAFFNAME
        {
            get { return _STAFFNAME; }
            set { _STAFFNAME = value; }
        }
        private int _TM;  //调用条码

        public int TM
        {
            get { return _TM; }
            set { _TM = value; }
        }
        private int _TMTYPE;  //条码类型

        public int TMTYPE
        {
            get { return _TMTYPE; }
            set { _TMTYPE = value; }
        }
        private string _MANUALMS;  //条码对应描述

        public string MANUALMS
        {
            get { return _MANUALMS; }
            set { _MANUALMS = value; }
        }
        private string _TMTYPEMS;  //条码类型描述

        public string TMTYPEMS
        {
            get { return _TMTYPEMS; }
            set { _TMTYPEMS = value; }
        }

    }
}
