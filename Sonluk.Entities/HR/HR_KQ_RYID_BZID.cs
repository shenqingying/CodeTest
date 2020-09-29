using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.HR
{
    public class HR_KQ_RYID_BZID
    {
        private int _RYIDOLD;

        public int RYIDOLD
        {
            get { return _RYIDOLD; }
            set { _RYIDOLD = value; }
        }
        private int _RYIDNEW;

        public int RYIDNEW
        {
            get { return _RYIDNEW; }
            set { _RYIDNEW = value; }
        }
        private int _BZID;

        public int BZID
        {
            get { return _BZID; }
            set { _BZID = value; }
        }
        private string _GH;

        public string GH
        {
            get { return _GH; }
            set { _GH = value; }
        }
    }
}
