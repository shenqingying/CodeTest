using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

using System.Management;

namespace Sonluk.MES.MES
{
    public class DeviceInfo
    {
        /// <summary>  
        /// 获取网卡的MAC地址  
        /// </summary>  
        /// <returns>返回一个string</returns>  
        public static string GetNetCardMAC()
        {
            try
            {
                string stringMAC = "";
                ManagementClass MC = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection MOC = MC.GetInstances();
                foreach (ManagementObject MO in MOC)
                {
                    if ((bool)MO["IPEnabled"] == true)
                    {
                        stringMAC += MO["MACAddress"].ToString();
                    }
                }
                return stringMAC;
            }
            catch
            {
                return "";
            }
        }  
    }
}
