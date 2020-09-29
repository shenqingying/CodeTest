using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_MSG_NOTICETTList : CRM_MSG_NOTICETT
    {
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

        string _DEPIDDES;

        public string DEPIDDES
        {
            get { return _DEPIDDES; }
            set { _DEPIDDES = value; }
        }


    }
}
