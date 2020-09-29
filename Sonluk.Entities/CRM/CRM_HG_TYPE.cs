using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_HG_TYPE
    {
        int _TYPEID;

        public int TYPEID
        {
            get { return _TYPEID; }
            set { _TYPEID = value; }
        }
        string _TYPENAME;

        public string TYPENAME
        {
            get { return _TYPENAME; }
            set { _TYPENAME = value; }
        }
        string _TYPEMEMO;

        public string TYPEMEMO
        {
            get { return _TYPEMEMO; }
            set { _TYPEMEMO = value; }
        }
        bool _ISACTIVE;

        public bool ISACTIVE
        {
            get { return _ISACTIVE; }
            set { _ISACTIVE = value; }
        }

    }
}
