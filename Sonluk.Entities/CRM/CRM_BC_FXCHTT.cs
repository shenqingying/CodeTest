using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_BC_FXCHTT
    {
        int _FXCHTTID;

        public int FXCHTTID
        {
            get { return _FXCHTTID; }
            set { _FXCHTTID = value; }
        }
        int _KHID;

        public int KHID
        {
            get { return _KHID; }
            set { _KHID = value; }
        }
        int _SDFID;

        public int SDFID
        {
            get { return _SDFID; }
            set { _SDFID = value; }
        }
        
        string _BEIZ;

        public string BEIZ
        {
            get { return _BEIZ; }
            set { _BEIZ = value; }
        }
        int _CJR;

        public int CJR
        {
            get { return _CJR; }
            set { _CJR = value; }
        }
        string _CJRQ;

        public string CJRQ
        {
            get { return _CJRQ; }
            set { _CJRQ = value; }
        }
        bool _ISDELETE;

        public bool ISDELETE
        {
            get { return _ISDELETE; }
            set { _ISDELETE = value; }
        }




    }
}
