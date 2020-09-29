using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_KQ_YCKQSMList : CRM_KQ_YCKQSM
    {
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
        string _SMRQ_BEGIN;

        public string SMRQ_BEGIN
        {
            get { return _SMRQ_BEGIN; }
            set { _SMRQ_BEGIN = value; }
        }
        string _SMRQ_END;

        public string SMRQ_END
        {
            get { return _SMRQ_END; }
            set { _SMRQ_END = value; }
        }
        int _DEP;

        public int DEP
        {
            get { return _DEP; }
            set { _DEP = value; }
        }
        string _STAFFNAME;

        public string STAFFNAME
        {
            get { return _STAFFNAME; }
            set { _STAFFNAME = value; }
        }
        string _STAFFNO;

        public string STAFFNO
        {
            get { return _STAFFNO; }
            set { _STAFFNO = value; }
        }
        string _STAFFTYPE;

        public string STAFFTYPE
        {
            get { return _STAFFTYPE; }
            set { _STAFFTYPE = value; }
        }

    }
}
