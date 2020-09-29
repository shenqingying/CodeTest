using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_OA_YCKQSM
    {
        string _STAFFNAME;

        public string STAFFNAME
        {
            get { return _STAFFNAME; }
            set { _STAFFNAME = value; }
        }

        string _QDSJ;

        public string QDSJ
        {
            get { return _QDSJ; }
            set { _QDSJ = value; }
        }
        string _QDWZ;

        public string QDWZ
        {
            get { return _QDWZ; }
            set { _QDWZ = value; }
        }
        string _KQJL;

        public string KQJL
        {
            get { return _KQJL; }
            set { _KQJL = value; }
        }

        List<SMTABLE> _SMTABLEList;

        public List<SMTABLE> SMTABLEList
        {
            get { return _SMTABLEList; }
            set { _SMTABLEList = value; }
        }
    }
    public class SMTABLE
    {
        string _SMRQ;

        public string SMRQ
        {
            get { return _SMRQ; }
            set { _SMRQ = value; }
        }
        string _SMSXB;

        public string SMSXB
        {
            get { return _SMSXB; }
            set { _SMSXB = value; }
        }
        string _SMSX;

        public string SMSX
        {
            get { return _SMSX; }
            set { _SMSX = value; }
        }
        
    }
}
