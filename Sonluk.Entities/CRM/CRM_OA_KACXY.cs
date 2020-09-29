using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_OA_KACXY
    {
        string _SQR;

        public string SQR
        {
            get { return _SQR; }
            set { _SQR = value; }
        }
        string _SQRQ;

        public string SQRQ
        {
            get { return _SQRQ; }
            set { _SQRQ = value; }
        }
        string _MDMC;

        public string MDMC
        {
            get { return _MDMC; }
            set { _MDMC = value; }
        }
        string _MC;

        public string MC
        {
            get { return _MC; }
            set { _MC = value; }
        }


        List<CRM_OA_KACXYMX> _KACXYMX;

        public List<CRM_OA_KACXYMX> KACXYMX
        {
            get { return _KACXYMX; }
            set { _KACXYMX = value; }
        }

        public class CRM_OA_KACXYMX
        {
            string _SF;

            public string SF
            {
                get { return _SF; }
                set { _SF = value; }
            }
            string _CS;

            public string CS
            {
                get { return _CS; }
                set { _CS = value; }
            }
            string _FZR;

            public string FZR
            {
                get { return _FZR; }
                set { _FZR = value; }
            }
            string _GW;

            public string GW
            {
                get { return _GW; }
                set { _GW = value; }
            }
            string _KHJS;

            public string KHJS
            {
                get { return _KHJS; }
                set { _KHJS = value; }
            }
            string _NAME;

            public string NAME
            {
                get { return _NAME; }
                set { _NAME = value; }
            }
            string _SEX;

            public string SEX
            {
                get { return _SEX; }
                set { _SEX = value; }
            }
            string _SFZ;

            public string SFZ
            {
                get { return _SFZ; }
                set { _SFZ = value; }
            }
            string _TEL;

            public string TEL
            {
                get { return _TEL; }
                set { _TEL = value; }
            }
            string _SGRQ;

            public string SGRQ
            {
                get { return _SGRQ; }
                set { _SGRQ = value; }
            }
            string _QZCS;

            public string QZCS
            {
                get { return _QZCS; }
                set { _QZCS = value; }
            }
            string _XS1;

            public string XS1
            {
                get { return _XS1; }
                set { _XS1 = value; }
            }
            string _XS2;

            public string XS2
            {
                get { return _XS2; }
                set { _XS2 = value; }
            }
            string _XS3;

            public string XS3
            {
                get { return _XS3; }
                set { _XS3 = value; }
            }
            string _XSZE;

            public string XSZE
            {
                get { return _XSZE; }
                set { _XSZE = value; }
            }
            string _SUPPORT;

            public string SUPPORT
            {
                get { return _SUPPORT; }
                set { _SUPPORT = value; }
            }
            string _CHANGE;

            public string CHANGE
            {
                get { return _CHANGE; }
                set { _CHANGE = value; }
            }
            string _YJXS;

            public string YJXS
            {
                get { return _YJXS; }
                set { _YJXS = value; }
            }
            string _BANK;

            public string BANK
            {
                get { return _BANK; }
                set { _BANK = value; }
            }
            string _BANKCARD;

            public string BANKCARD
            {
                get { return _BANKCARD; }
                set { _BANKCARD = value; }
            }

            string _BEIZ;

            public string BEIZ
            {
                get { return _BEIZ; }
                set { _BEIZ = value; }
            }
            








        }


        List<CRM_OA_KACXY_OPINION> _OPINION;

        public List<CRM_OA_KACXY_OPINION> OPINION
        {
            get { return _OPINION; }
            set { _OPINION = value; }
        }

        public class CRM_OA_KACXY_OPINION
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



        List<CRM_OA_KACXY_IMG> _IMG;

        public List<CRM_OA_KACXY_IMG> IMG
        {
            get { return _IMG; }
            set { _IMG = value; }
        }
        public class CRM_OA_KACXY_IMG
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
