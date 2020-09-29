using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.WX
{
    public class WX_MSG_RETURN
    {
        string _errcode;

        public string errcode
        {
            get { return _errcode; }
            set { _errcode = value; }
        }
        string _errmsg;

        public string errmsg
        {
            get { return _errmsg; }
            set { _errmsg = value; }
        }
        string _msgid;

        public string msgid
        {
            get { return _msgid; }
            set { _msgid = value; }
        }
        string _invaliduser;

        public string invaliduser
        {
            get { return _invaliduser; }
            set { _invaliduser = value; }
        }





    }
}
