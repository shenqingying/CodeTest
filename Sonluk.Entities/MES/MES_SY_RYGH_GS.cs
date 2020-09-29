using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_RYGH_GS
    {
        private string _RYGSDM;

        public string RYGSDM
        {
            get { return _RYGSDM; }
            set { _RYGSDM = value; }
        }
        private string _RYGSSM;

        public string RYGSSM
        {
            get { return _RYGSSM; }
            set { _RYGSSM = value; }
        }
        private string _RYGSREMARK;

        public string RYGSREMARK
        {
            get { return _RYGSREMARK; }
            set { _RYGSREMARK = value; }
        }
        private int _ISACTION;

        public int ISACTION
        {
            get { return _ISACTION; }
            set { _ISACTION = value; }
        }
        private int _CJRID;

        public int CJRID
        {
            get { return _CJRID; }
            set { _CJRID = value; }
        }
        private int _LB;

        public int LB
        {
            get { return _LB; }
            set { _LB = value; }
        }
        private int _GHWS;

        public int GHWS
        {
            get { return _GHWS; }
            set { _GHWS = value; }
        }
    }
}
