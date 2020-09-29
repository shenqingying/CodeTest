using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_MATERIAL_BZCOUNT
    {
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

        private string _WLNAME;

        public string WLNAME
        {
            get { return _WLNAME; }
            set { _WLNAME = value; }
        }


        private string _GZZXBH;

        public string GZZXBH
        {
            get { return _GZZXBH; }
            set { _GZZXBH = value; }
        }

        private string _GZZXNAME;

        public string GZZXNAME
        {
            get { return _GZZXNAME; }
            set { _GZZXNAME = value; }
        }

        private int _BZCOUNT;

        public int BZCOUNT
        {
            get { return _BZCOUNT; }
            set { _BZCOUNT = value; }
        }

        private int _BZBS;

        public int BZBS
        {
            get { return _BZBS; }
            set { _BZBS = value; }
        }
        private int _LB;

        public int LB
        {
            get { return _LB; }
            set { _LB = value; }
        }
        private int _STAFFID;

        public int STAFFID
        {
            get { return _STAFFID; }
            set { _STAFFID = value; }
        }
    }
}
