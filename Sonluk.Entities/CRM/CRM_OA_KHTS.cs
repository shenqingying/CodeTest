using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_OA_KHTS
    {
        string _LCLX;

        public string LCLX
        {
            get { return _LCLX; }
            set { _LCLX = value; }
        }
        string _TSLY;

        public string TSLY
        {
            get { return _TSLY; }
            set { _TSLY = value; }
        }
        string _TSXX;

        public string TSXX
        {
            get { return _TSXX; }
            set { _TSXX = value; }
        }
        string _DAMAGE;

        public string DAMAGE
        {
            get { return _DAMAGE; }
            set { _DAMAGE = value; }
        }
        string _PRICE;

        public string PRICE
        {
            get { return _PRICE; }
            set { _PRICE = value; }
        }
        string _GG;

        public string GG
        {
            get { return _GG; }
            set { _GG = value; }
        }
        string _REASON;

        public string REASON
        {
            get { return _REASON; }
            set { _REASON = value; }
        }
        string _MC;

        public string MC
        {
            get { return _MC; }
            set { _MC = value; }
        }
        string _TEL;

        public string TEL
        {
            get { return _TEL; }
            set { _TEL = value; }
        }
        string _ADDRESS;

        public string ADDRESS
        {
            get { return _ADDRESS; }
            set { _ADDRESS = value; }
        }
        string _YWY;

        public string YWY
        {
            get { return _YWY; }
            set { _YWY = value; }
        }
        string _FGLD;

        public string FGLD
        {
            get { return _FGLD; }
            set { _FGLD = value; }
        }
        string _KHYQ;

        public string KHYQ
        {
            get { return _KHYQ; }
            set { _KHYQ = value; }
        }
        string _FCSJ;

        public string FCSJ
        {
            get { return _FCSJ; }
            set { _FCSJ = value; }
        }
        string _WLXX;

        public string WLXX
        {
            get { return _WLXX; }
            set { _WLXX = value; }
        }
        string _JS;

        public string JS
        {
            get { return _JS; }
            set { _JS = value; }
        }
        string _TSSFYX;

        public string TSSFYX
        {
            get { return _TSSFYX; }
            set { _TSSFYX = value; }
        }
        string _TSJG;

        public string TSJG
        {
            get { return _TSJG; }
            set { _TSJG = value; }
        }
        string _KDDH;

        public string KDDH
        {
            get { return _KDDH; }
            set { _KDDH = value; }
        }
        string _BEIZ;

        public string BEIZ
        {
            get { return _BEIZ; }
            set { _BEIZ = value; }
        }
        string _SOURCE;

        public string SOURCE
        {
            get { return _SOURCE; }
            set { _SOURCE = value; }
        }


        List<CRM_OA_KHTSMX> _KHTSMX;

        public List<CRM_OA_KHTSMX> KHTSMX
        {
            get { return _KHTSMX; }
            set { _KHTSMX = value; }
        }







        public class CRM_OA_KHTSMX
        {
            string _CPMC;

            public string CPMC
            {
                get { return _CPMC; }
                set { _CPMC = value; }
            }
            string _BZGG;

            public string BZGG
            {
                get { return _BZGG; }
                set { _BZGG = value; }
            }
            string _BLPSL;

            public string BLPSL
            {
                get { return _BLPSL; }
                set { _BLPSL = value; }
            }
            string _RQM;

            public string RQM
            {
                get { return _RQM; }
                set { _RQM = value; }
            }
            string _REASON;

            public string REASON
            {
                get { return _REASON; }
                set { _REASON = value; }
            }

        }





        List<CRM_OA_KHTS_IMG> _IMG;

        public List<CRM_OA_KHTS_IMG> IMG
        {
            get { return _IMG; }
            set { _IMG = value; }
        }
        public class CRM_OA_KHTS_IMG
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
