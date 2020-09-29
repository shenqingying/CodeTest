using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_TYPE
    {
        private int _TYPEID;

        public int TYPEID
        {
            get { return _TYPEID; }
            set { _TYPEID = value; }
        }


        private string _TYPENAME;

        public string TYPENAME
        {
            get { return _TYPENAME; }
            set { _TYPENAME = value; }
        }


        private string _TYPEMS;

        public string TYPEMS
        {
            get { return _TYPEMS; }
            set { _TYPEMS = value; }
        }

        private bool _ISDELETE;

        public bool ISDELETE
        {
            get { return _ISDELETE; }
            set { _ISDELETE = value; }
        }

        private bool _ISYXWH;

        public bool ISYXWH
        {
            get { return _ISYXWH; }
            set { _ISYXWH = value; }
        }
    }
}
