using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.HR
{
    public class HR_GS_GSSL
    {
        private int _SWLBID;

        public int SWLBID
        {
            get { return _SWLBID; }
            set { _SWLBID = value; }
        }
        private int _RYLB;

        public int RYLB
        {
            get { return _RYLB; }
            set { _RYLB = value; }
        }
        private string _RYLBNAME;

        public string RYLBNAME
        {
            get { return _RYLBNAME; }
            set { _RYLBNAME = value; }
        }
        private int _GSLB;

        public int GSLB
        {
            get { return _GSLB; }
            set { _GSLB = value; }
        }
        private string _GSLBNAME;

        public string GSLBNAME
        {
            get { return _GSLBNAME; }
            set { _GSLBNAME = value; }
        }
        private int _ISACTION;

        public int ISACTION
        {
            get { return _ISACTION; }
            set { _ISACTION = value; }
        }
        private int _ISDELETE;

        public int ISDELETE
        {
            get { return _ISDELETE; }
            set { _ISDELETE = value; }
        }
        private int _CJR;

        public int CJR
        {
            get { return _CJR; }
            set { _CJR = value; }
        }
        private string _CJRNAME;

        public string CJRNAME
        {
            get { return _CJRNAME; }
            set { _CJRNAME = value; }
        }
        private string _CJTIME;

        public string CJTIME
        {
            get { return _CJTIME; }
            set { _CJTIME = value; }
        }
        private int _XGR;

        public int XGR
        {
            get { return _XGR; }
            set { _XGR = value; }
        }
        private string _XGRNAME;

        public string XGRNAME
        {
            get { return _XGRNAME; }
            set { _XGRNAME = value; }
        }
        private string _XGTIME;

        public string XGTIME
        {
            get { return _XGTIME; }
            set { _XGTIME = value; }
        }
        private string _REMARK;

        public string REMARK
        {
            get { return _REMARK; }
            set { _REMARK = value; }
        }
        private List<HR_XZGL_TAX_TAXSLMX> _HR_XZGL_TAX_TAXSLMX;

        public List<HR_XZGL_TAX_TAXSLMX> HR_XZGL_TAX_TAXSLMX
        {
            get { return _HR_XZGL_TAX_TAXSLMX; }
            set { _HR_XZGL_TAX_TAXSLMX = value; }
        }
        private int _TAXQZD;

        public int TAXQZD
        {
            get { return _TAXQZD; }
            set { _TAXQZD = value; }
        }
        private string _JSGS;

        public string JSGS
        {
            get { return _JSGS; }
            set { _JSGS = value; }
        }
        private int _ISGLZXFJ;

        public int ISGLZXFJ
        {
            get { return _ISGLZXFJ; }
            set { _ISGLZXFJ = value; }
        }
    }
}
