using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.EM
{
    public class EM_SY_PB
    {
        private int _PBID;  //PBID

        public int PBID
        {
            get { return _PBID; }
            set { _PBID = value; }
        }
        private string _PBMS;  //平板设备描述

        public string PBMS
        {
            get { return _PBMS; }
            set { _PBMS = value; }
        }
        private string _PBBH;  //平板设备编号

        public string PBBH
        {
            get { return _PBBH; }
            set { _PBBH = value; }
        }
        private int _ISDELETE;  //ISDELETE

        public int ISDELETE
        {
            get { return _ISDELETE; }
            set { _ISDELETE = value; }
        }

       
        private string _BZ;  //BZ

        public string BZ
        {
            get { return _BZ; }
            set { _BZ = value; }
        }

    }
}
