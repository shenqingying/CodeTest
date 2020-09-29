using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_HG_RIGHTGROUP
    {
        int _RGROUPID;

        public int RGROUPID
        {
            get { return _RGROUPID; }
            set { _RGROUPID = value; }
        }
        string _RGROUPNAME;

        public string RGROUPNAME
        {
            get { return _RGROUPNAME; }
            set { _RGROUPNAME = value; }
        }
        int _PRGROUPID;

        public int PRGROUPID
        {
            get { return _PRGROUPID; }
            set { _PRGROUPID = value; }
        }
        int _PRIGHTNO;

        public int PRIGHTNO
        {
            get { return _PRIGHTNO; }
            set { _PRIGHTNO = value; }
        }
        string _RGROUPMEMO;

        public string RGROUPMEMO
        {
            get { return _RGROUPMEMO; }
            set { _RGROUPMEMO = value; }
        }
        int _ISACTIVE;

        public int ISACTIVE
        {
            get { return _ISACTIVE; }
            set { _ISACTIVE = value; }
        }
        string _IMAGELJ;

        public string IMAGELJ
        {
            get { return _IMAGELJ; }
            set { _IMAGELJ = value; }
        }

    }
}
