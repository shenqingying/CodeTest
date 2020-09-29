using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;

namespace Sonluk.MES.MES.publics
{
    class PrintPublic
    {
        
        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern long SetDefaultPrinter(string pszPrinter);

       

            private static PrintDocument fPrintDocument = new PrintDocument();
            //获取本机默认打印机名称
            public static String DefaultPrinter()
            {
                return fPrintDocument.PrinterSettings.PrinterName;
            }
            public static List<String> GetLocalPrinters()
            {
                List<String> fPrinters = new List<String>();
                fPrinters.Add(DefaultPrinter()); //默认打印机始终出现在列表的第一项
                foreach (String fPrinterName in PrinterSettings.InstalledPrinters)
                {
                    if (!fPrinters.Contains(fPrinterName))
                    {
                        fPrinters.Add(fPrinterName);
                    }
                }
                return fPrinters;
            }
            public enum PrinterStatus
            {
                其他状态 = 1,
                未知,
                空闲,
                正在打印,
                预热,
                停止打印,
                打印中,
                离线
            }
            /// <summary>
            /// 获取打印机的当前状态
            /// </summary>
            /// <param name="PrinterDevice">打印机设备名称</param>
            /// <returns>打印机状态</returns>
            public static PrinterStatus GetPrinterStat(string PrinterDevice)
            {
                PrinterStatus ret = 0;
                string path = @"win32_printer.DeviceId='" + PrinterDevice + "'";
                ManagementObject printer = new ManagementObject(path);
                printer.Get();
                ret = (PrinterStatus)Convert.ToInt32(printer.Properties["PrinterStatus"].Value);
                return ret;
            }

            
    }
}
