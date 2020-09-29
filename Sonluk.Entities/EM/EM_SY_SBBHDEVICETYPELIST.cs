using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.EM
{
    public class EM_SY_SBBHDEVICETYPELIST
    {
        string _SBBH;

        public string SBBH
        {
            get { return _SBBH; }
            set { _SBBH = value; }
        }
        int _DID;

        public int DID
        {
            get { return _DID; }
            set { _DID = value; }
        }
        string _GZZX;

        public string GZZX
        {
            get { return _GZZX; }
            set { _GZZX = value; }
        }
        string _GZZXBH;

        public string GZZXBH
        {
            get { return _GZZXBH; }
            set { _GZZXBH = value; }
        }
        string _GC;

        public string GC
        {
            get { return _GC; }
            set { _GC = value; }
        }
        string _SBMS;

        public string SBMS
        {
            get { return _SBMS; }
            set { _SBMS = value; }
        }
        string _DMS;

        public string DMS
        {
            get { return _DMS; }
            set { _DMS = value; }
        }
    }
}
