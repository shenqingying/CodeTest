using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.PS
{
    public class PS_wlXXINFO
    {
        private string _RETURNS;

        public string RETURNS
        {
            get { return _RETURNS; }
            set { _RETURNS = value; }
        }
        private List<PS_wlXX> _T_OUT;

        public List<PS_wlXX> T_OUT
        {
            get { return _T_OUT; }
            set { _T_OUT = value; }
        }

    }
}
