using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
  public  class CRM_COST_KAXSReport_Compare
    {
        private int _SJLX;

        public int SJLX
        {
            get { return _SJLX; }
            set { _SJLX = value; }
        }
        private int _XSLX;

        public int XSLX
        {
            get { return _XSLX; }
            set { _XSLX = value; }
        }
        private string _BEGINDATE;

        public string BEGINDATE
        {
            get { return _BEGINDATE; }
            set { _BEGINDATE = value; }
        }
        private string _ENDDATE;

        public string ENDDATE
        {
            get { return _ENDDATE; }
            set { _ENDDATE = value; }
        }
        private string _MC;

        public string MC
        {
            get { return _MC; }
            set { _MC = value; }
        }
        private string _GMEMO;

        public string GMEMO
        {
            get { return _GMEMO; }
            set { _GMEMO = value; }
        }
        private int _GID;

        public int GID
        {
            get { return _GID; }
            set { _GID = value; }
        }
        private string _GNAME;

        public string GNAME
        {
            get { return _GNAME; }
            set { _GNAME = value; }
        }
        private int _CPLX;

        public int CPLX
        {
            get { return _CPLX; }
            set { _CPLX = value; }
        }
        private int _SORT;

        public int SORT
        {
            get { return _SORT; }
            set { _SORT = value; }
        }
        private string _CURRENT_HJ;

        public string CURRENT_HJ
        {
            get { return _CURRENT_HJ; }
            set { _CURRENT_HJ = value; }
        }
        private string _PAST_HJ;

        public string PAST_HJ
        {
            get { return _PAST_HJ; }
            set { _PAST_HJ = value; }
        }
        private string _COMPARE_NUM1;

        public string COMPARE_NUM1
        {
            get { return _COMPARE_NUM1; }
            set { _COMPARE_NUM1 = value; }
        }
        private string _COMPARE_NUM2;

        public string COMPARE_NUM2
        {
            get { return _COMPARE_NUM2; }
            set { _COMPARE_NUM2 = value; }
        }
    }
}
