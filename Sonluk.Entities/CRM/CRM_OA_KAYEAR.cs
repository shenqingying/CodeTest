using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_OA_KAYEAR
    {
        string _MC;

        public string MC
        {
            get { return _MC; }
            set { _MC = value; }
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
        string _YEAR;

        public string YEAR
        {
            get { return _YEAR; }
            set { _YEAR = value; }
        }
        string _YEAR2;

        public string YEAR2
        {
            get { return _YEAR2; }
            set { _YEAR2 = value; }
        }
        string _ZQ;

        public string ZQ
        {
            get { return _ZQ; }
            set { _ZQ = value; }
        }
        string _ZQ2;

        public string ZQ2
        {
            get { return _ZQ2; }
            set { _ZQ2 = value; }
        }
        string _MDSL;

        public string MDSL
        {
            get { return _MDSL; }
            set { _MDSL = value; }
        }
        string _POS;

        public string POS
        {
            get { return _POS; }
            set { _POS = value; }
        }
        string _POS2;

        public string POS2
        {
            get { return _POS2; }
            set { _POS2 = value; }
        }
        string _JH;

        public string JH
        {
            get { return _JH; }
            set { _JH = value; }
        }
        string _JH2;

        public string JH2
        {
            get { return _JH2; }
            set { _JH2 = value; }
        }
        string _KP;

        public string KP
        {
            get { return _KP; }
            set { _KP = value; }
        }
        string _KP2;

        public string KP2
        {
            get { return _KP2; }
            set { _KP2 = value; }
        }
        string _MDSL2;

        public string MDSL2
        {
            get { return _MDSL2; }
            set { _MDSL2 = value; }
        }
        string _BEIZ1;

        public string BEIZ1
        {
            get { return _BEIZ1; }
            set { _BEIZ1 = value; }
        }
        string _BEIZ2;

        public string BEIZ2
        {
            get { return _BEIZ2; }
            set { _BEIZ2 = value; }
        }
        string _BEIZ3;

        public string BEIZ3
        {
            get { return _BEIZ3; }
            set { _BEIZ3 = value; }
        }
        string _BEIZ4;

        public string BEIZ4
        {
            get { return _BEIZ4; }
            set { _BEIZ4 = value; }
        }
        string _BEIZ5;

        public string BEIZ5
        {
            get { return _BEIZ5; }
            set { _BEIZ5 = value; }
        }



        List<CRM_OA_KAYEARMX> _KAYEARMX;

        public List<CRM_OA_KAYEARMX> KAYEARMX
        {
            get { return _KAYEARMX; }
            set { _KAYEARMX = value; }
        }

        public class CRM_OA_KAYEARMX
        {
            string _ITEM;

            public string ITEM
            {
                get { return _ITEM; }
                set { _ITEM = value; }
            }
            string _HTTK;

            public string HTTK
            {
                get { return _HTTK; }
                set { _HTTK = value; }
            }
            string _JE;

            public string JE
            {
                get { return _JE; }
                set { _JE = value; }
            }
            string _FYL;

            public string FYL
            {
                get { return _FYL; }
                set { _FYL = value; }
            }
            string _HTTK2;

            public string HTTK2
            {
                get { return _HTTK2; }
                set { _HTTK2 = value; }
            }
            string _JE2;

            public string JE2
            {
                get { return _JE2; }
                set { _JE2 = value; }
            }
            string _JE2XG;

            public string JE2XG
            {
                get { return _JE2XG; }
                set { _JE2XG = value; }
            }
            string _FYL2;

            public string FYL2
            {
                get { return _FYL2; }
                set { _FYL2 = value; }
            }
            string _BEIZ;

            public string BEIZ
            {
                get { return _BEIZ; }
                set { _BEIZ = value; }
            }

        }





        List<CRM_OA_KAYEAR_OPINION> _OPINION;

        public List<CRM_OA_KAYEAR_OPINION> OPINION
        {
            get { return _OPINION; }
            set { _OPINION = value; }
        }

        public class CRM_OA_KAYEAR_OPINION
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




        List<CRM_OA_KAYEAR_IMG> _IMG;

        public List<CRM_OA_KAYEAR_IMG> IMG
        {
            get { return _IMG; }
            set { _IMG = value; }
        }
        public class CRM_OA_KAYEAR_IMG
        {
            string _IMGML;

            public string IMGML
            {
                get { return _IMGML; }
                set { _IMGML = value; }
            }
        }




    }
}
