using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_OA_MDBS
    {
        string _LCTYPE;

        public string LCTYPE
        {
            get { return _LCTYPE; }
            set { _LCTYPE = value; }
        }
        string _XTTYPE;

        public string XTTYPE
        {
            get { return _XTTYPE; }
            set { _XTTYPE = value; }
        }
        string _TITLE;

        public string TITLE
        {
            get { return _TITLE; }
            set { _TITLE = value; }
        }
        string _MONTH;

        public string MONTH
        {
            get { return _MONTH; }
            set { _MONTH = value; }
        }


        List<CRM_OA_MDBSMX> _MDBSMX;

        public List<CRM_OA_MDBSMX> MDBSMX
        {
            get { return _MDBSMX; }
            set { _MDBSMX = value; }
        }

        public class CRM_OA_MDBSMX
        {
            string _MC;

            public string MC
            {
                get { return _MC; }
                set { _MC = value; }
            }
            string _MDMC;

            public string MDMC
            {
                get { return _MDMC; }
                set { _MDMC = value; }
            }
            string _DISPLAY;

            public string DISPLAY
            {
                get { return _DISPLAY; }
                set { _DISPLAY = value; }
            }
            string _FB;

            public string FB
            {
                get { return _FB; }
                set { _FB = value; }
            }
            string _PAYWAY;

            public string PAYWAY
            {
                get { return _PAYWAY; }
                set { _PAYWAY = value; }
            }
            string _HX_SJXS;

            public string HX_SJXS
            {
                get { return _HX_SJXS; }
                set { _HX_SJXS = value; }
            }
            string _SJFY;

            public string SJFY
            {
                get { return _SJFY; }
                set { _SJFY = value; }
            }
            string _HX_FB;

            public string HX_FB
            {
                get { return _HX_FB; }
                set { _HX_FB = value; }
            }
            string _BEIZ;

            public string BEIZ
            {
                get { return _BEIZ; }
                set { _BEIZ = value; }
            }
            string _YJFY;

            public string YJFY
            {
                get { return _YJFY; }
                set { _YJFY = value; }
            }
            string _BEGINDATE;

            public string BEGINDATE
            {
                get { return _BEGINDATE; }
                set { _BEGINDATE = value; }
            }
            string _CS;

            public string CS
            {
                get { return _CS; }
                set { _CS = value; }
            }
            string _POSITION;

            public string POSITION
            {
                get { return _POSITION; }
                set { _POSITION = value; }
            }
            string _SF;

            public string SF
            {
                get { return _SF; }
                set { _SF = value; }
            }
            string _ENDDATE;

            public string ENDDATE
            {
                get { return _ENDDATE; }
                set { _ENDDATE = value; }
            }
            string _HX_JE;

            public string HX_JE
            {
                get { return _HX_JE; }
                set { _HX_JE = value; }
            }
            string _HXRQ;

            public string HXRQ
            {
                get { return _HXRQ; }
                set { _HXRQ = value; }
            }
            string _CXY;

            public string CXY
            {
                get { return _CXY; }
                set { _CXY = value; }
            }
            string _XXDD;

            public string XXDD
            {
                get { return _XXDD; }
                set { _XXDD = value; }
            }
            string _YJXS;

            public string YJXS
            {
                get { return _YJXS; }
                set { _YJXS = value; }
            }
            string _QSYJXS;

            public string QSYJXS
            {
                get { return _QSYJXS; }
                set { _QSYJXS = value; }
            }
            string _BEIZ2;

            public string BEIZ2
            {
                get { return _BEIZ2; }
                set { _BEIZ2 = value; }
            }
        }



        List<CRM_OA_MDBS_OPINION> _OPINION;

        public List<CRM_OA_MDBS_OPINION> OPINION
        {
            get { return _OPINION; }
            set { _OPINION = value; }
        }

        public class CRM_OA_MDBS_OPINION
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
            string _MS;

            public string MS
            {
                get { return _MS; }
                set { _MS = value; }
            }

        }




        List<CRM_OA_MDBS_IMG> _IMG;

        public List<CRM_OA_MDBS_IMG> IMG
        {
            get { return _IMG; }
            set { _IMG = value; }
        }
        public class CRM_OA_MDBS_IMG
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
