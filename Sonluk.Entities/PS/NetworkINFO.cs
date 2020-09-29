using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.PS
{
    public class NetworkINFO
    {
        private string _Aufnr;
        private string _Ktext;
        private string _Posid;
        private string _Post1;
        private string _Zmatnr;
        private string _Maktx;
        private double _Zmenge;
        private string _Zmeins;
        private string _Gstrp;

        public string Gstrp
        {
            get { return _Gstrp; }
            set { _Gstrp = value; }
        }
        private string _Gltrp;

        public string Gltrp
        {
            get { return _Gltrp; }
            set { _Gltrp = value; }
        }

        public string Aufnr
        {
            get { return _Aufnr; }
            set { _Aufnr = value; }
        }

        public string Ktext
        {
            get { return _Ktext; }
            set { _Ktext = value; }
        }

        public string Posid
        {
            get { return _Posid; }
            set { _Posid = value; }
        }

        public string Post1
        {
            get { return _Post1; }
            set { _Post1 = value; }
        }

        public string Zmatnr
        {
            get { return _Zmatnr; }
            set { _Zmatnr = value; }
        }

        public string Maktx
        {
            get { return _Maktx; }
            set { _Maktx = value; }
        }

        public double Zmenge
        {
            get { return _Zmenge; }
            set { _Zmenge = value; }
        }

        public string Zmeins
        {
            get { return _Zmeins; }
            set { _Zmeins = value; }
        }
    }
}
