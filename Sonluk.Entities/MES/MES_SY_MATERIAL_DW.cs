using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_MATERIAL_DW
    {
        private string _WLH;

        public string WLH
        {
            get { return _WLH; }
            set { _WLH = value; }
        }
        private string _MEINH;

        public string MEINH
        {
            get { return _MEINH; }
            set { _MEINH = value; }
        }
        private int _UMREZ;

        public int UMREZ
        {
            get { return _UMREZ; }
            set { _UMREZ = value; }
        }
        private int _UMREN;

        public int UMREN
        {
            get { return _UMREN; }
            set { _UMREN = value; }
        }
        private int _LB;

        public int LB
        {
            get { return _LB; }
            set { _LB = value; }
        }
        private string _UNITSNAME;

        public string UNITSNAME
        {
            get { return _UNITSNAME; }
            set { _UNITSNAME = value; }
        }
        private string _WLMS;

        public string WLMS
        {
            get { return _WLMS; }
            set { _WLMS = value; }
        }
    }
}
