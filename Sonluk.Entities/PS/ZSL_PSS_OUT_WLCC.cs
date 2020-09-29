using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.PS
{
    public class ZSL_PSS_OUT_WLCC
    {
        private string _AUFNR;
        private string _KTEXT;
        private string _ZMATNR;
        private string _MAKTX;
        private string _ZMENGE;
        private string _ZMEINS;
        private string _POSID;
        private string _POST1;
        private string _WERKS;
        private string _VERNR;
        private string _VERNA;
        private string _PSPID;
        private string _POST1_OJ;

        public string POST1_OJ
        {
            get { return _POST1_OJ; }
            set { _POST1_OJ = value; }
        }

        public string PSPID
        {
            get { return _PSPID; }
            set { _PSPID = value; }
        }

        public string VERNA
        {
            get { return _VERNA; }
            set { _VERNA = value; }
        }

        public string VERNR
        {
            get { return _VERNR; }
            set { _VERNR = value; }
        }

        public string KTEXT
        {
            get { return _KTEXT; }
            set { _KTEXT = value; }
        }
        public string AUFNR
        {
            get { return _AUFNR; }
            set { _AUFNR = value; }
        }
        public string WERKS
        {
            get { return _WERKS; }
            set { _WERKS = value; }
        }

        public string POST1
        {
            get { return _POST1; }
            set { _POST1 = value; }
        }

        public string POSID
        {
            get { return _POSID; }
            set { _POSID = value; }
        }

        public string ZMEINS
        {
            get { return _ZMEINS; }
            set { _ZMEINS = value; }
        }


        public string MAKTX
        {
            get { return _MAKTX; }
            set { _MAKTX = value; }
        }

        public string ZMATNR
        {
            get { return _ZMATNR; }
            set { _ZMATNR = value; }
        }

        public string ZMENGE
        {
            get { return _ZMENGE; }
            set { _ZMENGE = value; }
        }

    }
}
