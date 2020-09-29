using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
   public class CRM_WX_OPENID
    {

        



        int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        int _STAFFID;

        public int STAFFID
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
