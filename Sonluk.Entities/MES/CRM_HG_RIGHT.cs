using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class CRM_HG_RIGHT
    {
        private int _RIGHTID;

        public int RIGHTID
        {
            get { return _RIGHTID; }
            set { _RIGHTID = value; }
        }

        private int _RGROUPID;

        public int RGROUPID
        {
            get { return _RGROUPID; }
            set { _RGROUPID = value; }
        }

        private string _RIGHTNAME;

        public string RIGHTNAME
        {
            get { return _RIGHTNAME; }
            set { _RIGHTNAME = value; }
        }

        private int _RIGHTNO;

        public int RIGHTNO
        {
            get { return _RIGHTNO; }
            set { _RIGHTNO = value; }
        }

        private string _RIGHTADD;

        public string RIGHTADD
        {
            get { return _RIGHTADD; }
            set { _RIGHTADD = value; }
        }

        private string _RIGHTMEMO;

        public string RIGHTMEMO
        {
            get { return _RIGHTMEMO; }
            set { _RIGHTMEMO = value; }
        }

        private int _ISACTIVE;

        public int ISACTIVE
        {
            get { return _ISACTIVE; }
            set { _ISACTIVE = value; }
        }

        private string _IMAGELJ;

        public string IMAGELJ
        {
            get { return _IMAGELJ; }
            set { _IMAGELJ = value; }
        }
    }
}
