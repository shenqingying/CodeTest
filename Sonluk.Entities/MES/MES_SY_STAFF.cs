using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_STAFF
    {
        private int _STAFFID;

        public int STAFFID
        {
            get { return _STAFFID; }
            set { _STAFFID = value; }
        }

        private int _DEPID;

        public int DEPID
        {
            get { return _DEPID; }
            set { _DEPID = value; }
        }

        private string _DEPNAME;

        public string DEPNAME
        {
            get { return _DEPNAME; }
            set { _DEPNAME = value; }
        }

        private string _STAFFNAME;

        public string STAFFNAME
        {
            get { return _STAFFNAME; }
            set { _STAFFNAME = value; }
        }

        private string _STAFFNO;

        public string STAFFNO
        {
            get { return _STAFFNO; }
            set { _STAFFNO = value; }
        }

        private string _STAFFUSER;

        public string STAFFUSER
        {
            get { return _STAFFUSER; }
            set { _STAFFUSER = value; }
        }

        private string _STAFFPW;

        public string STAFFPW
        {
            get { return _STAFFPW; }
            set { _STAFFPW = value; }
        }

        private int _STAFFSEX;

        public int STAFFSEX
        {
            get { return _STAFFSEX; }
            set { _STAFFSEX = value; }
        }

        private string _STAFFMOBILE;

        public string STAFFMOBILE
        {
            get { return _STAFFMOBILE; }
            set { _STAFFMOBILE = value; }
        }

        private string _STAFFTEL;

        public string STAFFTEL
        {
            get { return _STAFFTEL; }
            set { _STAFFTEL = value; }
        }

        private string _JLRQ;

        public string JLRQ
        {
            get { return _JLRQ; }
            set { _JLRQ = value; }
        }

        private bool _SISLOCK;

        public bool SISLOCK
        {
            get { return _SISLOCK; }
            set { _SISLOCK = value; }
        }

        private bool _SCANCEL;

        public bool SCANCEL
        {
            get { return _SCANCEL; }
            set { _SCANCEL = value; }
        }
    }
}
