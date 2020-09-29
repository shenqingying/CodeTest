using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_MACHINEINFO_BBXX
    {
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private string _MNUMBER;

        public string MNUMBER
        {
            get { return _MNUMBER; }
            set { _MNUMBER = value; }
        }
        private string _WKINFO;

        public string WKINFO
        {
            get { return _WKINFO; }
            set { _WKINFO = value; }
        }

        private bool _ISDELETE;

        public bool ISDELETE
        {
            get { return _ISDELETE; }
            set { _ISDELETE = value; }
        }

        private string _GC;

        public string GC
        {
            get { return _GC; }
            set { _GC = value; }
        }

        private string _REMARK;

        public string REMARK
        {
            get { return _REMARK; }
            set { _REMARK = value; }
        }
        private int _PBID;

        public int PBID
        {
            get { return _PBID; }
            set { _PBID = value; }
        }
        private string _SYID;

        public string SYID
        {
            get { return _SYID; }
            set { _SYID = value; }
        }
        private string _NEWBB;

        public string NEWBB
        {
            get { return _NEWBB; }
            set { _NEWBB = value; }
        }
        private string _LASTNEWBB;

        public string LASTNEWBB
        {
            get { return _LASTNEWBB; }
            set { _LASTNEWBB = value; }
        }
    }
}
