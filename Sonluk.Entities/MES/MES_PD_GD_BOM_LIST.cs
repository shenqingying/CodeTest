using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_PD_GD_BOM_LIST
    {
        private string _GDDH;

        public string GDDH
        {
            get { return _GDDH; }
            set { _GDDH = value; }
        }
        private string _GC;

        public string GC
        {
            get { return _GC; }
            set { _GC = value; }
        }
        private string _WLH;

        public string WLH
        {
            get { return _WLH; }
            set { _WLH = value; }
        }
        private decimal _SL;

        public decimal SL
        {
            get { return _SL; }
            set { _SL = value; }
        }
        private string _WLMS;

        public string WLMS
        {
            get { return _WLMS; }
            set { _WLMS = value; }
        }
        private string _WLGROUP;

        public string WLGROUP
        {
            get { return _WLGROUP; }
            set { _WLGROUP = value; }
        }
        private int _WLLB;

        public int WLLB
        {
            get { return _WLLB; }
            set { _WLLB = value; }
        }
        private string _WLLBNAME;

        public string WLLBNAME
        {
            get { return _WLLBNAME; }
            set { _WLLBNAME = value; }
        }
        private int _ISTRACE;

        public int ISTRACE
        {
            get { return _ISTRACE; }
            set { _ISTRACE = value; }
        }
    }
}
