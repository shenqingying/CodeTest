using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_OA_KATSCL
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
        string _MC;

        public string MC
        {
            get { return _MC; }
            set { _MC = value; }
        }
        string _CRMID;

        public string CRMID
        {
            get { return _CRMID; }
            set { _CRMID = value; }
        }
        string _MDSL;

        public string MDSL
        {
            get { return _MDSL; }
            set { _MDSL = value; }
        }
        string _LJSQJE;

        public string LJSQJE
        {
            get { return _LJSQJE; }
            set { _LJSQJE = value; }
        }
        string _YHXJE;

        public string YHXJE
        {
            get { return _YHXJE; }
            set { _YHXJE = value; }
        }



        List<CRM_OA_KATSCLMX> _KATSCLMX;

        public List<CRM_OA_KATSCLMX> KATSCLMX
        {
            get { return _KATSCLMX; }
            set { _KATSCLMX = value; }
        }

        public class CRM_OA_KATSCLMX
        {
            string _MC;

            public string MC
            {
                get { return _MC; }
                set { _MC = value; }
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
            string _FYJE;

            public string FYJE
            {
                get { return _FYJE; }
                set { _FYJE = value; }
            }
            string _RCYJXS;

            public string RCYJXS
            {
                get { return _RCYJXS; }
                set { _RCYJXS = value; }
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

        }




        List<CRM_OA_KATSCL_OPINION> _OPINION;

        public List<CRM_OA_KATSCL_OPINION> OPINION
        {
            get { return _OPINION; }
            set { _OPINION = value; }
        }

        public class CRM_OA_KATSCL_OPINION
        {
            string _MS;

            public string MS
            {
                get { return _MS; }
                set { _MS = value; }
            }
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




        List<CRM_OA_KATSCL_IMG> _IMG;

        public List<CRM_OA_KATSCL_IMG> IMG
        {
            get { return _IMG; }
            set { _IMG = value; }
        }
        public class CRM_OA_KATSCL_IMG
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
