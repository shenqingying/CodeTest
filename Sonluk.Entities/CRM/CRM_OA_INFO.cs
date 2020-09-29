using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
   public class CRM_OA_INFO
    {
        string _SUBJECT;

        public string SUBJECT
        {
            get { return _SUBJECT; }
            set { _SUBJECT = value; }
        }
        string _ADDRESS;

        public string ADDRESS
        {
            get { return _ADDRESS; }
            set { _ADDRESS = value; }
        }
        string _SENDNAME;

        public string SENDNAME
        {
            get { return _SENDNAME; }
            set { _SENDNAME = value; }
        }
    }
}
