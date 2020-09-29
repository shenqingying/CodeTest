using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.HR
{
    public class HR_SY_TYPE
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
        private int _ISDELETE;

        public int ISDELETE
        {
            get { return _ISDELETE; }
            set { _ISDELETE = value; }
        }
        private int _ISYXWH;

        public int ISYXWH
        {
            get { return _ISYXWH; }
            set { _ISYXWH = value; }
        }
        private int _ISALL;

        public int ISALL
        {
            get { return _ISALL; }
            set { _ISALL = value; }
        }
    }
}
