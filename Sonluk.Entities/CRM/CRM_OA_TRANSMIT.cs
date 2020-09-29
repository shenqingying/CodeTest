using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_OA_TRANSMIT
    {
        int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        string _OAID;

        public string OAID
        {
            get { return _OAID; }
            set { _OAID = value; }
        }
        int _OACSBH;

        public int OACSBH
        {
            get { return _OACSBH; }
            set { _OACSBH = value; }
        }
        int _OACSLB;

        public int OACSLB
        {
            get { return _OACSLB; }
            set { _OACSLB = value; }
        }
        int _OAZT;

        public int OAZT
        {
            get { return _OAZT; }
            set { _OAZT = value; }
        }
        string _CJSJ;

        public string CJSJ
        {
            get { return _CJSJ; }
            set { _CJSJ = value; }
        }
        bool _ISDELETE;

        public bool ISDELETE
        {
            get { return _ISDELETE; }
            set { _ISDELETE = value; }
        }


    }
}
