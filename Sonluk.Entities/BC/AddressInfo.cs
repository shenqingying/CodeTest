using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.BC
{
    public class AddressInfo
    {
        private string _FullName;

        public string FullName
        {
            get { return _FullName; }
            set { _FullName = value; }
        }
    }
}
