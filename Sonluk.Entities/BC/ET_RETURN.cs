using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.BC
{
    public class ET_RETURN
    {
        private string _TYPE;

        public string TYPE
        {
            get { return _TYPE; }
            set { _TYPE = value; }
        }

        private string _MESSAGE;

        public string MESSAGE
        {
            get { return _MESSAGE; }
            set { _MESSAGE = value; }
        }
    }
}
