using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Sonluk.Utility.Net
{
    public class Address
    {
        public int Type(string address)
        {
            int type = 0;
            IPAddress ipAddress;
            if (IPAddress.TryParse(address, out ipAddress))
            {
                type = 1;
                Regex regex = new Regex(@"^((192\.168|172\.([1][6-9]|[2]\d|3[01]))(\.([2][0-4]\d|[2][5][0-5]|[01]?\d?\d)){2}|10(\.([2][0-4]\d|[2][5][0-5]|[01]?\d?\d)){3})$");

                if (!regex.IsMatch(address))
                {
                    type = 2;
                }
            }
            return type;
        }
    }
}
