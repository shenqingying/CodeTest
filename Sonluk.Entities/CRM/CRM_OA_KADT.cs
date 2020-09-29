using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_OA_KADT
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
        string _HDFASM;

        public string HDFASM
        {
            get { return _HDFASM; }
            set { _HDFASM = value; }
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
        string _FAHUO;

        public string FAHUO
        {
            get { return _FAHUO; }
            set { _FAHUO = value; }
        }
        string _DQ;

        public string DQ
        {
            get { return _DQ; }
            set { _DQ = value; }
        }
        string _CXJB;

        public string CXJB
        {
            get { return _CXJB; }
            set { _CXJB = value; }
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






        List<CRM_OA_KADTCP> _KADTCP;

        public List<CRM_OA_KADTCP> KADTCP
        {
            get { return _KADTCP; }
            set { _KADTCP = value; }
        }

        public class CRM_OA_KADTCP
        {
            string _SAPCP;

            public string SAPCP
            {
                get { return _SAPCP; }
                set { _SAPCP = value; }
            }
            string _CPMC;

            public string CPMC
            {
                get { return _CPMC; }
                set { _CPMC = value; }
            }
            string _ZCGJ;

            public string ZCGJ
            {
                get { return _ZCGJ; }
                set { _ZCGJ = value; }
            }
            string _CXGJ;

            public string CXGJ
            {
                get { return _CXGJ; }
                set { _CXGJ = value; }
            }
            string _ZCSJ;

            public string ZCSJ
            {
                get { return _ZCSJ; }
                set { _ZCSJ = value; }
            }
            string _CXSJ;

            public string CXSJ
            {
                get { return _CXSJ; }
                set { _CXSJ = value; }
            }
            string _BHSL;

            public string BHSL
            {
                get { return _BHSL; }
                set { _BHSL = value; }
            }
            string _BEIZ;

            public string BEIZ
            {
                get { return _BEIZ; }
                set { _BEIZ = value; }
            }

        }




        List<CRM_OA_KADTMX> _KADTMX;

        public List<CRM_OA_KADTMX> KADTMX
        {
            get { return _KADTMX; }
            set { _KADTMX = value; }
        }

        public class CRM_OA_KADTMX
        {
            string _FYLX;

            public string FYLX
            {
                get { return _FYLX; }
                set { _FYLX = value; }
            }
            string _CXLX;

            public string CXLX
            {
                get { return _CXLX; }
                set { _CXLX = value; }
            }
            string _FYJE;

            public string FYJE
            {
                get { return _FYJE; }
                set { _FYJE = value; }
            }
            string _CJHDMDSL;

            public string CJHDMDSL
            {
                get { return _CJHDMDSL; }
                set { _CJHDMDSL = value; }
            }
            string _PROMISE;

            public string PROMISE
            {
                get { return _PROMISE; }
                set { _PROMISE = value; }
            }

        }





        List<CRM_OA_KADT_OPINION> _OPINION;

        public List<CRM_OA_KADT_OPINION> OPINION
        {
            get { return _OPINION; }
            set { _OPINION = value; }
        }

        public class CRM_OA_KADT_OPINION
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


        List<CRM_OA_KADT_IMG> _IMG;

        public List<CRM_OA_KADT_IMG> IMG
        {
            get { return _IMG; }
            set { _IMG = value; }
        }
        public class CRM_OA_KADT_IMG
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
