using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.PS
{
    public class PS_ComponentInventory
    {
        private string _VERIF;
        private string _LGNUM;
        private string _LGTYP;
        private string _LGBER;
        private string _LGPLA;
        private string _LPTYP;

        public string LPTYP
        {
            get { return _LPTYP; }
            set { _LPTYP = value; }
        }

        public string LGBER
        {
            get { return _LGBER; }
            set { _LGBER = value; }
        }

        public string LGTYP
        {
            get { return _LGTYP; }
            set { _LGTYP = value; }
        }

        public string LGNUM
        {
            get { return _LGNUM; }
            set { _LGNUM = value; }
        }


        public string VERIF
        {
            get { return _VERIF; }
            set { _VERIF = value; }
        }


        public string LGPLA
        {
            get { return _LGPLA; }
            set { _LGPLA = value; }
        }

    }
}
