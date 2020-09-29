using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.HR
{
    public class HR_XZGL_TAX_TAXSLMX
    {
        private int _GSSLMXID;

        public int GSSLMXID
        {
            get { return _GSSLMXID; }
            set { _GSSLMXID = value; }
        }
        private int _SWLBID;

        public int SWLBID
        {
            get { return _SWLBID; }
            set { _SWLBID = value; }
        }
        private decimal _TAXKSJE;

        public decimal TAXKSJE
        {
            get { return _TAXKSJE; }
            set { _TAXKSJE = value; }
        }
        private decimal _TAXJSJE;

        public decimal TAXJSJE
        {
            get { return _TAXJSJE; }
            set { _TAXJSJE = value; }
        }
        private decimal _TAXSL;

        public decimal TAXSL
        {
            get { return _TAXSL; }
            set { _TAXSL = value; }
        }
        private decimal _TAXSKS;

        public decimal TAXSKS
        {
            get { return _TAXSKS; }
            set { _TAXSKS = value; }
        }
    }
}
