using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.HR
{
    public class HR_DA_DADM
    {
        private int _DADMID;

        public int DADMID
        {
            get { return _DADMID; }
            set { _DADMID = value; }
        }
        private string _DADM;

        public string DADM
        {
            get { return _DADM; }
            set { _DADM = value; }
        }
        private int _DALB;

        public int DALB
        {
            get { return _DALB; }
            set { _DALB = value; }
        }
        private string _DALBNAME;

        public string DALBNAME
        {
            get { return _DALBNAME; }
            set { _DALBNAME = value; }
        }
        private string _DADMNAME;

        public string DADMNAME
        {
            get { return _DADMNAME; }
            set { _DADMNAME = value; }
        }
        private int _ISDELETE;

        public int ISDELETE
        {
            get { return _ISDELETE; }
            set { _ISDELETE = value; }
        }
    }
}
