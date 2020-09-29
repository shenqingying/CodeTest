using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_OA_KH
    {
        string _MC;

        public string MC
        {
            get { return _MC; }
            set { _MC = value; }
        }
        string _JPXZ;

        public string JPXZ
        {
            get { return _JPXZ; }
            set { _JPXZ = value; }
        }
        string _KPDZ;

        public string KPDZ
        {
            get { return _KPDZ; }
            set { _KPDZ = value; }
        }
        string _KPDH;

        public string KPDH
        {
            get { return _KPDH; }
            set { _KPDH = value; }
        }
        string _NSRSBH;

        public string NSRSBH
        {
            get { return _NSRSBH; }
            set { _NSRSBH = value; }
        }
        string _YHZH;

        public string YHZH
        {
            get { return _YHZH; }
            set { _YHZH = value; }
        }
        string _YHMC;

        public string YHMC
        {
            get { return _YHMC; }
            set { _YHMC = value; }
        }
        string _GSLXR;

        public string GSLXR
        {
            get { return _GSLXR; }
            set { _GSLXR = value; }
        }
        string _GSLXDH;

        public string GSLXDH
        {
            get { return _GSLXDH; }
            set { _GSLXDH = value; }
        }
        string _FR;

        public string FR
        {
            get { return _FR; }
            set { _FR = value; }
        }
        string _GSFRGX;

        public string GSFRGX
        {
            get { return _GSFRGX; }
            set { _GSFRGX = value; }
        }
        string _KDJSDZ;

        public string KDJSDZ
        {
            get { return _KDJSDZ; }
            set { _KDJSDZ = value; }
        }
        string _KDLXR;

        public string KDLXR
        {
            get { return _KDLXR; }
            set { _KDLXR = value; }
        }
        string _KDLXDH;

        public string KDLXDH
        {
            get { return _KDLXDH; }
            set { _KDLXDH = value; }
        }
        string _HTXSRW;

        public string HTXSRW
        {
            get { return _HTXSRW; }
            set { _HTXSRW = value; }
        }
        string _HTJXXSRW;

        public string HTJXXSRW
        {
            get { return _HTJXXSRW; }
            set { _HTJXXSRW = value; }
        }
        string _XSSJSM;

        public string XSSJSM
        {
            get { return _XSSJSM; }
            set { _XSSJSM = value; }
        }
        string _FLSJSM;

        public string FLSJSM
        {
            get { return _FLSJSM; }
            set { _FLSJSM = value; }
        }
        string _SFCCJ;

        public string SFCCJ
        {
            get { return _SFCCJ; }
            set { _SFCCJ = value; }
        }
        string _KHSHDZ;

        public string KHSHDZ
        {
            get { return _KHSHDZ; }
            set { _KHSHDZ = value; }
        }
        string _KHSHLXR;

        public string KHSHLXR
        {
            get { return _KHSHLXR; }
            set { _KHSHLXR = value; }
        }
        string _KHSHLXDH;

        public string KHSHLXDH
        {
            get { return _KHSHLXDH; }
            set { _KHSHLXDH = value; }
        }
        string _TSQKSM;

        public string TSQKSM
        {
            get { return _TSQKSM; }
            set { _TSQKSM = value; }
        }
        string _GXQY;

        public string GXQY
        {
            get { return _GXQY; }
            set { _GXQY = value; }
        }
        string _JXSYX;

        public string JXSYX
        {
            get { return _JXSYX; }
            set { _JXSYX = value; }
        }
        string _YXSM;

        public string YXSM
        {
            get { return _YXSM; }
            set { _YXSM = value; }
        }
        string _QD;

        public string QD
        {
            get { return _QD; }
            set { _QD = value; }
        }
        string _STAFFNAME;

        public string STAFFNAME
        {
            get { return _STAFFNAME; }
            set { _STAFFNAME = value; }
        }
        string _TXRQ;

        public string TXRQ
        {
            get { return _TXRQ; }
            set { _TXRQ = value; }
        }

        string _KHSOURCE;

        public string KHSOURCE
        {
            get { return _KHSOURCE; }
            set { _KHSOURCE = value; }
        }

        string _KHLX2;

        public string KHLX2
        {
            get { return _KHLX2; }
            set { _KHLX2 = value; }
        }

        string _KHJS;

        public string KHJS
        {
            get { return _KHJS; }
            set { _KHJS = value; }
        }

        string _TITLE;

        public string TITLE
        {
            get { return _TITLE; }
            set { _TITLE = value; }
        }
        string _FIRSTAMOUNT;

        public string FIRSTAMOUNT
        {
            get { return _FIRSTAMOUNT; }
            set { _FIRSTAMOUNT = value; }
        }
        string _JOINACTIVITY;

        public string JOINACTIVITY
        {
            get { return _JOINACTIVITY; }
            set { _JOINACTIVITY = value; }
        }

        

        List<CRM_OA_KH_WD> _CRM_OA_KH_subWDList;

        public List<CRM_OA_KH_WD> CRM_OA_KH_subWDList
        {
            get { return _CRM_OA_KH_subWDList; }
            set { _CRM_OA_KH_subWDList = value; }
        }
        List<CRM_OA_KH_LKA> _CRM_OA_KH_LKAList;

        public List<CRM_OA_KH_LKA> CRM_OA_KH_LKAList
        {
            get { return _CRM_OA_KH_LKAList; }
            set { _CRM_OA_KH_LKAList = value; }
        }
        CRM_OA_KH_ZXS _CRM_OA_KH_ZXS;

        public CRM_OA_KH_ZXS CRM_OA_KH_ZXS
        {
            get { return _CRM_OA_KH_ZXS; }
            set { _CRM_OA_KH_ZXS = value; }
        }
      
    }
}
