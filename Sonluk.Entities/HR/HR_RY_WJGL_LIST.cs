using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.HR
{
    public class HR_RY_WJGL_LIST
    {
        private int _WJID;

        public int WJID
        {
            get { return _WJID; }
            set { _WJID = value; }
        }
        private int _RYID;

        public int RYID
        {
            get { return _RYID; }
            set { _RYID = value; }
        }
        private string _FSDATE;

        public string FSDATE
        {
            get { return _FSDATE; }
            set { _FSDATE = value; }
        }
        private string _SM;

        public string SM
        {
            get { return _SM; }
            set { _SM = value; }
        }
        private int _CJR;

        public int CJR
        {
            get { return _CJR; }
            set { _CJR = value; }
        }
        private string _CJRNAME;

        public string CJRNAME
        {
            get { return _CJRNAME; }
            set { _CJRNAME = value; }
        }
        private string _CJTIME;

        public string CJTIME
        {
            get { return _CJTIME; }
            set { _CJTIME = value; }
        }
        private int _XGR;

        public int XGR
        {
            get { return _XGR; }
            set { _XGR = value; }
        }
        private string _XGRNAME;

        public string XGRNAME
        {
            get { return _XGRNAME; }
            set { _XGRNAME = value; }
        }
        private string _XGRTIME;

        public string XGRTIME
        {
            get { return _XGRTIME; }
            set { _XGRTIME = value; }
        }
    }
}
