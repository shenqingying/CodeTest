using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_HD_NKAMDTT
    {
        int _NKAMDID;

        public int NKAMDID
        {
            get { return _NKAMDID; }
            set { _NKAMDID = value; }
        }
        int _SQRID;

        public int SQRID
        {
            get { return _SQRID; }
            set { _SQRID = value; }
        }
        string _SQRQ;

        public string SQRQ
        {
            get { return _SQRQ; }
            set { _SQRQ = value; }
        }
        int _ISACTIVE;

        public int ISACTIVE
        {
            get { return _ISACTIVE; }
            set { _ISACTIVE = value; }
        }

    }
}
