using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_GC
    {
        private string _GC;

        public string GC
        {
            get { return _GC; }
            set { _GC = value; }
        }

        private string _GCMS;

        public string GCMS
        {
            get { return _GCMS; }
            set { _GCMS = value; }
        }

        private string _GCDYMS;

        public string GCDYMS
        {
            get { return _GCDYMS; }
            set { _GCDYMS = value; }
        }

        private int _ISACTION;

        public int ISACTION
        {
            get { return _ISACTION; }
            set { _ISACTION = value; }
        }


        private string _GCADDRESS;

        public string GCADDRESS
        {
            get { return _GCADDRESS; }
            set { _GCADDRESS = value; }
        }

        private bool _ISAUTOWORKSPACE;

        public bool ISAUTOWORKSPACE
        {
            get { return _ISAUTOWORKSPACE; }
            set { _ISAUTOWORKSPACE = value; }
        }

        private int _STAFFID;

        public int STAFFID
        {
            get { return _STAFFID; }
            set { _STAFFID = value; }
        }

        private string _GCDM;

        public string GCDM
        {
            get { return _GCDM; }
            set { _GCDM = value; }
        }


    }
}
