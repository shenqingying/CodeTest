using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_PD_GD_SYNC
    {
        private int _LB;

        public int LB
        {
            get { return _LB; }
            set { _LB = value; }
        }

        private string _WERKS;

        public string WERKS
        {
            get { return _WERKS; }
            set { _WERKS = value; }
        }
        private string _ARBPL;

        public string ARBPL
        {
            get { return _ARBPL; }
            set { _ARBPL = value; }
        }
        private string _WLDL;

        public string WLDL
        {
            get { return _WLDL; }
            set { _WLDL = value; }
        }
        private string _AUFNR;

        public string AUFNR
        {
            get { return _AUFNR; }
            set { _AUFNR = value; }
        }
        private string _LOW;

        public string LOW
        {
            get { return _LOW; }
            set { _LOW = value; }
        }
        private string _HIGH;

        public string HIGH
        {
            get { return _HIGH; }
            set { _HIGH = value; }
        }
        private string _MATNR;

        public string MATNR
        {
            get { return _MATNR; }
            set { _MATNR = value; }
        }
    }
}
