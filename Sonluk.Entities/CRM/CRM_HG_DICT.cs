using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_HG_DICT
    {
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
        string _DICNAME;

        public string DICNAME
        {
            get { return _DICNAME; }
            set { _DICNAME = value; }
        }
        string _PP;

        public string PP
        {
            get { return _PP; }
            set { _PP = value; }
        }
        string _DICMEMO;

        public string DICMEMO
        {
            get { return _DICMEMO; }
            set { _DICMEMO = value; }
        }
        bool _ISACTIVE;

        public bool ISACTIVE
        {
            get { return _ISACTIVE; }
            set { _ISACTIVE = value; }
        }
        int _FID;

        public int FID
        {
            get { return _FID; }
            set { _FID = value; }
        }

    }
}
