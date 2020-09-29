using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_OA_TSCL
    {
        string _HTYEAR;

        public string HTYEAR
        {
            get { return _HTYEAR; }
            set { _HTYEAR = value; }
        }
        string _YWY;

        public string YWY
        {
            get { return _YWY; }
            set { _YWY = value; }
        }
        string _JXSNAME;

        public string JXSNAME
        {
            get { return _JXSNAME; }
            set { _JXSNAME = value; }
        }
        string _JXSSAPSN;

        public string JXSSAPSN
        {
            get { return _JXSSAPSN; }
            set { _JXSSAPSN = value; }
        }
        string _LKANAME;

        public string LKANAME
        {
            get { return _LKANAME; }
            set { _LKANAME = value; }
        }
        string _LKACRMID;

        public string LKACRMID
        {
            get { return _LKACRMID; }
            set { _LKACRMID = value; }
        }
        string _MDSL;

        public string MDSL
        {
            get { return _MDSL; }
            set { _MDSL = value; }
        }
        string _YSPFY;

        public string YSPFY
        {
            get { return _YSPFY; }
            set { _YSPFY = value; }
        }
        string _LJSPFY;

        public string LJSPFY
        {
            get { return _LJSPFY; }
            set { _LJSPFY = value; }
        }
        string _YHXFY;

        public string YHXFY
        {
            get { return _YHXFY; }
            set { _YHXFY = value; }
        }
        string _FYLX;

        public string FYLX
        {
            get { return _FYLX; }
            set { _FYLX = value; }
        }
        string _BELONGKA;

        public string BELONGKA
        {
            get { return _BELONGKA; }
            set { _BELONGKA = value; }
        }



        List<CRM_OA_TSCL_MX> _TSCL_MX;

        public List<CRM_OA_TSCL_MX> TSCL_MX
        {
            get { return _TSCL_MX; }
            set { _TSCL_MX = value; }
        }

        List<CRM_OA_XJ> _XJ;

        public List<CRM_OA_XJ> XJ
        {
            get { return _XJ; }
            set { _XJ = value; }
        }


        public class CRM_OA_TSCL_MX
        {
            string _MDSL;

            public string MDSL
            {
                get { return _MDSL; }
                set { _MDSL = value; }
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

            
            string _SQFY;

            public string SQFY
            {
                get { return _SQFY; }
                set { _SQFY = value; }
            }
            string _YJXS;

            public string YJXS
            {
                get { return _YJXS; }
                set { _YJXS = value; }
            }
            string _YJFB;

            public string YJFB
            {
                get { return _YJFB; }
                set { _YJFB = value; }
            }
            string _BEIZ;

            public string BEIZ
            {
                get { return _BEIZ; }
                set { _BEIZ = value; }
            }

            string _RCYJXS;

            public string RCYJXS
            {
                get { return _RCYJXS; }
                set { _RCYJXS = value; }
            }

        }



        public class CRM_OA_XJ
        {
            string _XJ1;

            public string XJ1
            {
                get { return _XJ1; }
                set { _XJ1 = value; }
            }
            string _XJ2;

            public string XJ2
            {
                get { return _XJ2; }
                set { _XJ2 = value; }
            }
            string _XJ3;

            public string XJ3
            {
                get { return _XJ3; }
                set { _XJ3 = value; }
            }
            string _XJ4;

            public string XJ4
            {
                get { return _XJ4; }
                set { _XJ4 = value; }
            }
            string _XJ5;

            public string XJ5
            {
                get { return _XJ5; }
                set { _XJ5 = value; }
            }
            string _XJ6;

            public string XJ6
            {
                get { return _XJ6; }
                set { _XJ6 = value; }
            }

        }



        List<CRM_OA_TSCL_IMG> _IMG;

        public List<CRM_OA_TSCL_IMG> IMG
        {
            get { return _IMG; }
            set { _IMG = value; }
        }
        public class CRM_OA_TSCL_IMG
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




        List<CRM_OA_TSCL_OPINION> _OPINION;

        public List<CRM_OA_TSCL_OPINION> OPINION
        {
            get { return _OPINION; }
            set { _OPINION = value; }
        }

        public class CRM_OA_TSCL_OPINION
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










    }
}
