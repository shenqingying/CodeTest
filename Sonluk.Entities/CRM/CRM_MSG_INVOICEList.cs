using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_MSG_INVOICEList : CRM_MSG_INVOICE
    {
        string _MC;

        public string MC
        {
            get { return _MC; }
            set { _MC = value; }
        }

        string _CJRDES;

        public string CJRDES
        {
            get { return _CJRDES; }
            set { _CJRDES = value; }
        }

        string _XGRDES;

        public string XGRDES
        {
            get { return _XGRDES; }
            set { _XGRDES = value; }
        }

    }
}
