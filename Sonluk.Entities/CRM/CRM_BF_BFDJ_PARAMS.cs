using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_BF_BFDJ_PARAMS
    {
        public CRM_BF_BFDJ_PARAMS()
        {
            this.ISACTIVE = 0;
            this.BFRYID = 0;
            this.BFJHID = 0;
            this.BFLX = 0;
            this.CRMID = "";
            this.KHMC = "";
            this.KHLX = 0;
            
        }
        int _ISACTIVE;

        public int ISACTIVE
        {
            get { return _ISACTIVE; }
            set { _ISACTIVE = value; }
        }
        int _BFRYID;

        public int BFRYID
        {
            get { return _BFRYID; }
            set { _BFRYID = value; }
        }
        int _BFJHID;

        public int BFJHID
        {
            get { return _BFJHID; }
            set { _BFJHID = value; }
        }
        int _BFLX;

        public int BFLX
        {
            get { return _BFLX; }
            set { _BFLX = value; }
        }
        string _CRMID;

        public string CRMID
        {
            get { return _CRMID; }
            set { _CRMID = value; }
        }
        string _KHMC;

        public string KHMC
        {
            get { return _KHMC; }
            set { _KHMC = value; }
        }
        int _KHLX;

        public int KHLX
        {
            get { return _KHLX; }
            set { _KHLX = value; }
        }
        string _BEGINTIME;

        public string BEGINTIME
        {
            get { return _BEGINTIME; }
            set { _BEGINTIME = value; }
        }

        string _ENDTIME;

        public string ENDTIME
        {
            get { return _ENDTIME; }
            set { _ENDTIME = value; }
        }

    }
}
