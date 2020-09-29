using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_KH_BFList
    {
        int _BFID;

        public int BFID
        {
            get { return _BFID; }
            set { _BFID = value; }
        }
        int _DUTYID;

        public int DUTYID
        {
            get { return _DUTYID; }
            set { _DUTYID = value; }
        }
        int _BFZQ;

        public int BFZQ
        {
            get { return _BFZQ; }
            set { _BFZQ = value; }
        }
        int _BFCS;

        public int BFCS
        {
            get { return _BFCS; }
            set { _BFCS = value; }
        }
        int _ISACTIVE;

        public int ISACTIVE
        {
            get { return _ISACTIVE; }
            set { _ISACTIVE = value; }
        }
        int _STAFFID;

        public int STAFFID
        {
            get { return _STAFFID; }
            set { _STAFFID = value; }
        }
        string _CJSJ;

        public string CJSJ
        {
            get { return _CJSJ; }
            set { _CJSJ = value; }
        }
        string _DUTYIDDES;

        public string DUTYIDDES
        {
            get { return _DUTYIDDES; }
            set { _DUTYIDDES = value; }
        }
        string _BFZQDES;

        public string BFZQDES
        {
            get { return _BFZQDES; }
            set { _BFZQDES = value; }
        }
    }
}
