using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.BC
{
    public class UserInfo
    {
        private AddressInfo _Address;

        public AddressInfo Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
    }
}
