using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_LoginModel
    {
        string _USERNAME;

        public string USERNAME
        {
            get { return _USERNAME; }
            set { _USERNAME = value; }
        }
        string _STAFFID;

        public string STAFFID
        {
            get { return _STAFFID; }
            set { _STAFFID = value; }
        }
        string _OPENID;

        public string OPENID
        {
            get { return _OPENID; }
            set { _OPENID = value; }
        }
        string _WXDLCS;

        public string WXDLCS
        {
            get { return _WXDLCS; }
            set { _WXDLCS = value; }
        }
        
    }
}
