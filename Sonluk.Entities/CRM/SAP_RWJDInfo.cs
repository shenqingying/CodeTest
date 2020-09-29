using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class SAP_RWJDInfo
    {
        private decimal _Task1;
        private decimal _Task2;
        private decimal _Jz1;
        private decimal _Jz2;

        public decimal Task1
        {
            get { return _Task1; }
            set { _Task1 = value; }
        }
        public decimal Task2
        {
            get { return _Task2; }
            set { _Task2 = value; }
        }
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
