using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_OA_KH_ZXS
    {
        string _SF;

        public string SF
        {
            get { return _SF; }
            set { _SF = value; }
        }
        string _MC;

        public string MC
        {
            get { return _MC; }
            set { _MC = value; }
        }
        string _XS;

        public string XS
        {
            get { return _XS; }
            set { _XS = value; }
        }
        string _JXXS;

        public string JXXS
        {
            get { return _JXXS; }
            set { _JXXS = value; }
        }
        string _AXS;

        public string AXS
        {
            get { return _AXS; }
            set { _AXS = value; }
        }
        string _AREA;

        public string AREA
        {
            get { return _AREA; }
            set { _AREA = value; }
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
        string _MDDZ;

        public string MDDZ
        {
            get { return _MDDZ; }
            set { _MDDZ = value; }
        }
        string _WDSL;

        public string WDSL
        {
            get { return _WDSL; }
            set { _WDSL = value; }
        }
        string _MBWDSL;

        public string MBWDSL
        {
            get { return _MBWDSL; }
            set { _MBWDSL = value; }
        }
        string _BEIZ;

        public string BEIZ
        {
            get { return _BEIZ; }
            set { _BEIZ = value; }
        }
        string _JXSMC;

        public string JXSMC
        {
            get { return _JXSMC; }
            set { _JXSMC = value; }
        }
        string _JXSID;

        public string JXSID
        {
            get { return _JXSID; }
            set { _JXSID = value; }
        }
        List<TABLE1> _TABLE1List;

        public List<TABLE1> TABLE1List
        {
            get { return _TABLE1List; }
            set { _TABLE1List = value; }
        }


        List<TABLE2> _TABLE2List;

        public List<TABLE2> TABLE2List
        {
            get { return _TABLE2List; }
            set { _TABLE2List = value; }
        }


        List<TABLE3> _TABLE3List;

        public List<TABLE3> TABLE3List
        {
            get { return _TABLE3List; }
            set { _TABLE3List = value; }
        }

      

       

    }
    public class TABLE1
    {
        string _CHEPAI;

        public string CHEPAI
        {
            get { return _CHEPAI; }
            set { _CHEPAI = value; }
        }
        string _AD;

        public string AD
        {
            get { return _AD; }
            set { _AD = value; }
        }
        string _ZP;

        public string ZP
        {
            get { return _ZP; }
            set { _ZP = value; }
        }
    }
    public class TABLE2
    {
        string _KHSTAFF;

        public string KHSTAFF
        {
            get { return _KHSTAFF; }
            set { _KHSTAFF = value; }
        }
        string _TEL;

        public string TEL
        {
            get { return _TEL; }
            set { _TEL = value; }
        }
        string _GZNR;

        public string GZNR
        {
            get { return _GZNR; }
            set { _GZNR = value; }
        }

    }
    public class TABLE3
    {
        string _DPMC;

        public string DPMC
        {
            get { return _DPMC; }
            set { _DPMC = value; }
        }
        string _CD;

        public string CD
        {
            get { return _CD; }
            set { _CD = value; }
        }

    }
}
