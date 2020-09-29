using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_WebMSG
    {
        bool _SUCCESS;

        public bool SUCCESS
        {
            get { return _SUCCESS; }
            set { _SUCCESS = value; }
        }
        string _MSG;

        public string MSG
        {
            get { return _MSG; }
            set { _MSG = value; }
        }
    }
}
