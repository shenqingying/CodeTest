using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace Sonluk.Utility.Net
{
    public class IPAddressConverter
    {
        public static long IPv4AddressToInt64(string ip)
        {
            return IPv4AddressToInt64(IPAddress.Parse(ip));
        }

        public static long IPv4AddressToInt64(IPAddress ip)
        {
            byte[] IPArr = ip.GetAddressBytes();
            long a = Convert.ToInt64(IPArr[0]);
            long b = Convert.ToInt64(IPArr[1]);
            long c = Convert.ToInt64(IPArr[2]);
            long d = Convert.ToInt64(IPArr[3]);
            return ((a * 256 + b) * 256 + c) * 256 + d;
  
        }

        public static IPAddress Int64ToIPv4Address(long ip)
        {

            return IPAddress.Parse(Int64ToIPv4AddressStr(ip));

        }

        public static string Int64ToIPv4AddressStr(long ip)
        {

            long d = ip % 256;
            ip = (ip - d) / 256;
            long c = ip % 256;
            ip = (ip - c) / 256;
            long b = ip % 256;
            ip = (ip - b) / 256;
            long a = ip % 256;

            return a.ToString()+"."+b.ToString()+"."+c.ToString()+"."+d.ToString();

        }
    }
}
