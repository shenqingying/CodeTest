using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.BC
{
    public class GdInfo
    {
        private List<ZSL_BCS206> et_gd;
        private string _O_MESSAGE;

        public string O_MESSAGE
        {
            get { return _O_MESSAGE; }
            set { _O_MESSAGE = value; }
        }
        public List<ZSL_BCS206> Et_gd
        {
            get { return et_gd; }
            set { et_gd = value; }
        }
    }
}
