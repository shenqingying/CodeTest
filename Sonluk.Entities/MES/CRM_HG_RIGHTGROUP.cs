using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class CRM_HG_RIGHTGROUP
    {
        private int _RGROUPID;

        public int RGROUPID
        {
            get { return _RGROUPID; }
            set { _RGROUPID = value; }
        }

        private string _RGROUPNAME;

        public string RGROUPNAME
        {
            get { return _RGROUPNAME; }
            set { _RGROUPNAME = value; }
        }

        private int _PRGROUPID;

        public int PRGROUPID
        {
            get { return _PRGROUPID; }
            set { _PRGROUPID = value; }
        }

        private int _PRIGHTNO;

        public int PRIGHTNO
        {
            get { return _PRIGHTNO; }
            set { _PRIGHTNO = value; }
        }

        private string _RGROUPMEMO;

        public string RGROUPMEMO
        {
            get { return _RGROUPMEMO; }
            set { _RGROUPMEMO = value; }
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


        private List<CRM_HG_RIGHT> _CRM_HG_RIGHT;

        public List<CRM_HG_RIGHT> CRM_HG_RIGHT
        {
            get { return _CRM_HG_RIGHT; }
            set { _CRM_HG_RIGHT = value; }
        }
    }
}
