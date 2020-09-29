using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.PS
{
    public class PS_MSG
    {
        private string _TYPE;
        private string _MESSAGE;

        public string MESSAGE
        {
            get { return _MESSAGE; }
            set { _MESSAGE = value; }
        }
        public string TYPE
        {
            get { return _TYPE; }
            set { _TYPE = value; }
        }
    }
}
