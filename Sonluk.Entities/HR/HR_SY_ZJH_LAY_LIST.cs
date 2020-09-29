using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.HR
{
    public class HR_SY_ZJH_LAY_LIST
    {
        private int _ZJHID;

        public int ZJHID
        {
            get { return _ZJHID; }
            set { _ZJHID = value; }
        }
        private int _LYID;

        public int LYID
        {
            get { return _LYID; }
            set { _LYID = value; }
        }
        private bool _LAY_CHECKED;

        public bool LAY_CHECKED
        {
            get { return _LAY_CHECKED; }
            set { _LAY_CHECKED = value; }
        }
        private string _GS;

        public string GS
        {
            get { return _GS; }
            set { _GS = value; }
        }
        private string _LYNAME;

        public string LYNAME
        {
            get { return _LYNAME; }
            set { _LYNAME = value; }
        }
        private int _STAFFID;

        public int STAFFID
        {
            get { return _STAFFID; }
            set { _STAFFID = value; }
        }
        private string _ZNAME;

        public string ZNAME
        {
            get { return _ZNAME; }
            set { _ZNAME = value; }
        }
        private string _GSNAME;

        public string GSNAME
        {
            get { return _GSNAME; }
            set { _GSNAME = value; }
        }
        private int _ISMR;

        public int ISMR
        {
            get { return _ISMR; }
            set { _ISMR = value; }
        }
    }
}
