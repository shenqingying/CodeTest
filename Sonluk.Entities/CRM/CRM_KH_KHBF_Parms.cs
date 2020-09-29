using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_KH_KHBF_Parms
    {
        int _BFID;

        public int BFID
        {
            get { return _BFID; }
            set { _BFID = value; }
        }
        string _MC;

        public string MC
        {
            get { return _MC; }
            set { _MC = value; }
        }
        int _KHLX;

        public int KHLX
        {
            get { return _KHLX; }
            set { _KHLX = value; }
        }
        string _CRMID;

        public string CRMID
        {
            get { return _CRMID; }
            set { _CRMID = value; }
        }
        string _SAPSN;

        public string SAPSN
        {
            get { return _SAPSN; }
            set { _SAPSN = value; }
        }
        int _GID;

        public int GID
        {
            get { return _GID; }
            set { _GID = value; }
        }
        int _TYPE;

        public int TYPE
        {
            get { return _TYPE; }
            set { _TYPE = value; }
        }

    }
}
