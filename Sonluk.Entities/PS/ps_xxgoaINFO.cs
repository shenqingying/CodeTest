using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.PS
{
    public class ps_xxgoaINFO
    {
        private string _RETURNS;

        public string RETURNS
        {
            get { return _RETURNS; }
            set { _RETURNS = value; }
        }
        private List<PS_SXXGOA> _T_OUT;

        public List<PS_SXXGOA> T_OUT
        {
            get { return _T_OUT; }
            set { _T_OUT = value; }
        }

    }
}
