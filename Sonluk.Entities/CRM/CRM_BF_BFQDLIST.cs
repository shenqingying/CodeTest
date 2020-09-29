using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_BF_BFQDLIST
    {
        int _BFQDID;

        public int BFQDID
        {
            get { return _BFQDID; }
            set { _BFQDID = value; }
        }
        int _BFDJID;

        public int BFDJID
        {
            get { return _BFDJID; }
            set { _BFDJID = value; }
        }
        int _QDID;

        public int QDID
        {
            get { return _QDID; }
            set { _QDID = value; }
        }
        string _QDIDDES;

        public string QDIDDES
        {
            get { return _QDIDDES; }
            set { _QDIDDES = value; }
        }
    }
}
