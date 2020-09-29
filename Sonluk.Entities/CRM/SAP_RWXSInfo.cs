using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class SAP_RWXSInfo
    {
        private decimal _Jz1;
        private decimal _Jz2;

        public decimal Jz1
        {
            get { return _Jz1; }
            set { _Jz1 = value; }
        }
        public decimal Jz2
        {
            get { return _Jz2; }
            set { _Jz2 = value; }
        }
    }
}
