using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_HG_DEPT
    {
        int _DEPID;

        public int DEPID
        {
            get { return _DEPID; }
            set { _DEPID = value; }
        }
        string _DEPNAME;

        public string DEPNAME
        {
            get { return _DEPNAME; }
            set { _DEPNAME = value; }
        }
        int _PDEPID;

        public int PDEPID
        {
            get { return _PDEPID; }
            set { _PDEPID = value; }
        }
        string _DLEVEL;

        public string DLEVEL
        {
            get { return _DLEVEL; }
            set { _DLEVEL = value; }
        }
        string _DEPADDRESS;

        public string DEPADDRESS
        {
            get { return _DEPADDRESS; }
            set { _DEPADDRESS = value; }
        }
        string _DEPMEMO;

        public string DEPMEMO
        {
            get { return _DEPMEMO; }
            set { _DEPMEMO = value; }
        }
        int _ISACTIVE;

        public int ISACTIVE
        {
            get { return _ISACTIVE; }
            set { _ISACTIVE = value; }
        }
        string _BEIZ;

        public string BEIZ
        {
            get { return _BEIZ; }
            set { _BEIZ = value; }
        }

    }
}
