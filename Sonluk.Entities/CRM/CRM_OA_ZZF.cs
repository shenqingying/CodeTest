using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_OA_ZZF
    {

        string _ZZLX;

        public string ZZLX
        {
            get { return _ZZLX; }
            set { _ZZLX = value; }
        }
        string _KHXZ;

        public string KHXZ
        {
            get { return _KHXZ; }
            set { _KHXZ = value; }
        }
        string _KHLX;

        public string KHLX
        {
            get { return _KHLX; }
            set { _KHLX = value; }
        }
        string _PKHMC;

        public string PKHMC
        {
            get { return _PKHMC; }
            set { _PKHMC = value; }
        }
        string _KHMC;

        public string KHMC
        {
            get { return _KHMC; }
            set { _KHMC = value; }
        }
        string _ADDRESS;

        public string ADDRESS
        {
            get { return _ADDRESS; }
            set { _ADDRESS = value; }
        }
        string _LXR;

        public string LXR
        {
            get { return _LXR; }
            set { _LXR = value; }
        }
        string _LXDH;

        public string LXDH
        {
            get { return _LXDH; }
            set { _LXDH = value; }
        }
        string _QKSM;

        public string QKSM
        {
            get { return _QKSM; }
            set { _QKSM = value; }
        }
        string _WZPG;

        public string WZPG
        {
            get { return _WZPG; }
            set { _WZPG = value; }
        }
        string _SALE_BEFORE;

        public string SALE_BEFORE
        {
            get { return _SALE_BEFORE; }
            set { _SALE_BEFORE = value; }
        }
        string _SALE_AFTER;

        public string SALE_AFTER
        {
            get { return _SALE_AFTER; }
            set { _SALE_AFTER = value; }
        }
        string _CXY;

        public string CXY
        {
            get { return _CXY; }
            set { _CXY = value; }
        }
        string _CXYFY;

        public string CXYFY
        {
            get { return _CXYFY; }
            set { _CXYFY = value; }
        }
        string _HAVEDISPLAYCOST;

        public string HAVEDISPLAYCOST
        {
            get { return _HAVEDISPLAYCOST; }
            set { _HAVEDISPLAYCOST = value; }
        }
        string _DISPLAYCOST;

        public string DISPLAYCOST
        {
            get { return _DISPLAYCOST; }
            set { _DISPLAYCOST = value; }
        }
        string _POPULATION;

        public string POPULATION
        {
            get { return _POPULATION; }
            set { _POPULATION = value; }
        }
        string _DISCOUNT;

        public string DISCOUNT
        {
            get { return _DISCOUNT; }
            set { _DISCOUNT = value; }
        }
        string _ADVER_COUNT;

        public string ADVER_COUNT
        {
            get { return _ADVER_COUNT; }
            set { _ADVER_COUNT = value; }
        }
        string _ZZFXJ;

        public string ZZFXJ
        {
            get { return _ZZFXJ; }
            set { _ZZFXJ = value; }
        }
        string _ZLF;

        public string ZLF
        {
            get { return _ZLF; }
            set { _ZLF = value; }
        }
        string _BEGINDATE;

        public string BEGINDATE
        {
            get { return _BEGINDATE; }
            set { _BEGINDATE = value; }
        }
        string _ENDDATE;

        public string ENDDATE
        {
            get { return _ENDDATE; }
            set { _ENDDATE = value; }
        }
        string _SQJE;

        public string SQJE
        {
            get { return _SQJE; }
            set { _SQJE = value; }
        }
        string _GGGSMC;

        public string GGGSMC
        {
            get { return _GGGSMC; }
            set { _GGGSMC = value; }
        }





        List<CRM_OA_ZZF_MX> _ZZF_MX;

        public List<CRM_OA_ZZF_MX> ZZF_MX
        {
            get { return _ZZF_MX; }
            set { _ZZF_MX = value; }
        }




        public class CRM_OA_ZZF_MX
        {
            string _ITEM;

            public string ITEM
            {
                get { return _ITEM; }
                set { _ITEM = value; }
            }
            string _MJ;

            public string MJ
            {
                get { return _MJ; }
                set { _MJ = value; }
            }
            string _PRICE;

            public string PRICE
            {
                get { return _PRICE; }
                set { _PRICE = value; }
            }
            string _XJ;

            public string XJ
            {
                get { return _XJ; }
                set { _XJ = value; }
            }
            string _BEIZ;

            public string BEIZ
            {
                get { return _BEIZ; }
                set { _BEIZ = value; }
            }

        }




        List<CRM_OA_ZZF_OPINION> _OPINION;

        public List<CRM_OA_ZZF_OPINION> OPINION
        {
            get { return _OPINION; }
            set { _OPINION = value; }
        }

        public class CRM_OA_ZZF_OPINION
        {
            string _OPINION;

            public string OPINION
            {
                get { return _OPINION; }
                set { _OPINION = value; }
            }
            string _HFNR;

            public string HFNR
            {
                get { return _HFNR; }
                set { _HFNR = value; }
            }

        }




        List<CRM_OA_ZZF_IMG> _IMG;

        public List<CRM_OA_ZZF_IMG> IMG
        {
            get { return _IMG; }
            set { _IMG = value; }
        }
        public class CRM_OA_ZZF_IMG
        {
            string _IMGML;

            public string IMGML
            {
                get { return _IMGML; }
                set { _IMGML = value; }
            }
            string _IMGMS;

            public string IMGMS
            {
                get { return _IMGMS; }
                set { _IMGMS = value; }
            }
        }





    }
}
