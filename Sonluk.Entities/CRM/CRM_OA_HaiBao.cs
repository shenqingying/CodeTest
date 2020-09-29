using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_OA_HaiBao
    {
        string _TITLE;

        public string TITLE
        {
            get { return _TITLE; }
            set { _TITLE = value; }
        }
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

        string _CJHDMDSL;

        public string CJHDMDSL
        {
            get { return _CJHDMDSL; }
            set { _CJHDMDSL = value; }
        }
        string _HDBEGINDATE;

        public string HDBEGINDATE
        {
            get { return _HDBEGINDATE; }
            set { _HDBEGINDATE = value; }
        }
        string _HDENDDATE;

        public string HDENDDATE
        {
            get { return _HDENDDATE; }
            set { _HDENDDATE = value; }
        }
        string _KHTHBEGINDATE;

        public string KHTHBEGINDATE
        {
            get { return _KHTHBEGINDATE; }
            set { _KHTHBEGINDATE = value; }
        }
        string _KHTHENDDATE;

        public string KHTHENDDATE
        {
            get { return _KHTHENDDATE; }
            set { _KHTHENDDATE = value; }
        }
        string _DP1;

        public string DP1
        {
            get { return _DP1; }
            set { _DP1 = value; }
        }
        string _DP2;

        public string DP2
        {
            get { return _DP2; }
            set { _DP2 = value; }
        }
        string _CCJ;

        public string CCJ
        {
            get { return _CCJ; }
            set { _CCJ = value; }
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
        string _DPYJXS;

        public string DPYJXS
        {
            get { return _DPYJXS; }
            set { _DPYJXS = value; }
        }
        string _YJHDQJXS;

        public string YJHDQJXS
        {
            get { return _YJHDQJXS; }
            set { _YJHDQJXS = value; }
        }
        string _YJFB;

        public string YJFB
        {
            get { return _YJFB; }
            set { _YJFB = value; }
        }
        string _HDFASM;

        public string HDFASM
        {
            get { return _HDFASM; }
            set { _HDFASM = value; }
        }
        string _BELONGKA;

        public string BELONGKA
        {
            get { return _BELONGKA; }
            set { _BELONGKA = value; }
        }



        List<CRM_OA_HaiBao_MX> _HaiBao_MX;

        public List<CRM_OA_HaiBao_MX> HaiBao_MX
        {
            get { return _HaiBao_MX; }
            set { _HaiBao_MX = value; }
        }


        public class CRM_OA_HaiBao_MX
        {
            string _FYLX;

            public string FYLX
            {
                get { return _FYLX; }
                set { _FYLX = value; }
            }

            
            string _CXFY;

            public string CXFY
            {
                get { return _CXFY; }
                set { _CXFY = value; }
            }
            
            string _BEIZ;

            public string BEIZ
            {
                get { return _BEIZ; }
                set { _BEIZ = value; }
            }

        }





        List<CRM_OA_HaiBao_OPINION> _OPINION;

        public List<CRM_OA_HaiBao_OPINION> OPINION
        {
            get { return _OPINION; }
            set { _OPINION = value; }
        }

        public class CRM_OA_HaiBao_OPINION
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



        List<CRM_OA_HaiBao_IMG> _IMG;

        public List<CRM_OA_HaiBao_IMG> IMG
        {
            get { return _IMG; }
            set { _IMG = value; }
        }
        public class CRM_OA_HaiBao_IMG
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
