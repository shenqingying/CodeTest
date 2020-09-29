using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.PS
{
    public class ZSL_PSS_OUT_LJXJ
    {
        private string _POSID;
        private string _POST1;
        private string _WERKS;
        private string _MATNR;
        private string _MAKTX;
        private string _ACOUNT;
        private string _WPCOUNT;

        public string WPCOUNT
        {
            get { return _WPCOUNT; }
            set { _WPCOUNT = value; }
        }
        private string _MEINS;
        private string _RSNUM;
        private string _RSPOS;
        private string _SOBKZ;



        public string POSID
        {
            get { return _POSID; }
            set { _POSID = value; }
        }

        public string POST1
        {
            get { return _POST1; }
            set { _POST1 = value; }
        }

        public string WERKS
        {
            get { return _WERKS; }
            set { _WERKS = value; }
        }

        public string MATNR
        {
            get { return _MATNR; }
            set { _MATNR = value; }
        }

        public string MAKTX
        {
            get { return _MAKTX; }
            set { _MAKTX = value; }
        }

        public string ACOUNT
        {
            get { return _ACOUNT; }
            set { _ACOUNT = value; }
        }

        public string MEINS
        {
            get { return _MEINS; }
            set { _MEINS = value; }
        }

        public string RSNUM
        {
            get { return _RSNUM; }
            set { _RSNUM = value; }
        }

        public string RSPOS
        {
            get { return _RSPOS; }
            set { _RSPOS = value; }
        }

        public string SOBKZ
        {
            get { return _SOBKZ; }
            set { _SOBKZ = value; }
        }
    }
}
