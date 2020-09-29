using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_LANGUAGE_RETURNMX
    {
        private int _MSGID;

        public int MSGID
        {
            get { return _MSGID; }
            set { _MSGID = value; }
        }
        private int _SYLANGUAGEID;

        public int SYLANGUAGEID
        {
            get { return _SYLANGUAGEID; }
            set { _SYLANGUAGEID = value; }
        }
        private string _MSGMXTEXT;

        public string MSGMXTEXT
        {
            get { return _MSGMXTEXT; }
            set { _MSGMXTEXT = value; }
        }
        private int _CJRID;

        public int CJRID
        {
            get { return _CJRID; }
            set { _CJRID = value; }
        }
        private int _LB;

        public int LB
        {
            get { return _LB; }
            set { _LB = value; }
        }
        private string _MSGNAME;

        public string MSGNAME
        {
            get { return _MSGNAME; }
            set { _MSGNAME = value; }
        }
        private int _MSGMXID;

        public int MSGMXID
        {
            get { return _MSGMXID; }
            set { _MSGMXID = value; }
        }
        private int _XGRID;

        public int XGRID
        {
            get { return _XGRID; }
            set { _XGRID = value; }
        }
    }
}
