using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_WX_SYS
    {
        int _WX_SYSID;

        public int WX_SYSID
        {
            get { return _WX_SYSID; }
            set { _WX_SYSID = value; }
        }
        string _WXAPPID;

        public string WXAPPID
        {
            get { return _WXAPPID; }
            set { _WXAPPID = value; }
        }
        string _ACCESS_TOKEN;

        public string ACCESS_TOKEN
        {
            get { return _ACCESS_TOKEN; }
            set { _ACCESS_TOKEN = value; }
        }
        string _TICKET;

        public string TICKET
        {
            get { return _TICKET; }
            set { _TICKET = value; }
        }
        string _JLTIME;

        public string JLTIME
        {
            get { return _JLTIME; }
            set { _JLTIME = value; }
        }
        int _EXPIRES_IN;

        public int EXPIRES_IN
        {
            get { return _EXPIRES_IN; }
            set { _EXPIRES_IN = value; }
        }

    }
}
