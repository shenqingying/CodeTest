using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_HG_STAFFDICT
    {
        int _STAFFID;

        public int STAFFID
        {
            get { return _STAFFID; }
            set { _STAFFID = value; }
        }
        int _DICID;

        public int DICID
        {
            get { return _DICID; }
            set { _DICID = value; }
        }
        int _TYPEID;

        public int TYPEID
        {
            get { return _TYPEID; }
            set { _TYPEID = value; }
        }
        int _FID;

        public int FID
        {
            get { return _FID; }
            set { _FID = value; }
        }
        string _STAFFNAME;

        public string STAFFNAME
        {
            get { return _STAFFNAME; }
            set { _STAFFNAME = value; }
        }
        string _STAFFNO;

        public string STAFFNO
        {
            get { return _STAFFNO; }
            set { _STAFFNO = value; }
        }
        string _DICNAME;

        public string DICNAME
        {
            get { return _DICNAME; }
            set { _DICNAME = value; }
        }
        string _TYPENAME;

        public string TYPENAME
        {
            get { return _TYPENAME; }
            set { _TYPENAME = value; }
        }



    }
}
