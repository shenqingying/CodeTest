using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_Message
    {
        string _TYPE;

        public string TYPE
        {
            get { return _TYPE; }
            set { _TYPE = value; }
        }
        string _MSG;

        public string MSG
        {
            get { return _MSG; }
            set { _MSG = value; }
        }
    }
}
