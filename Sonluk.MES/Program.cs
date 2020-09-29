using Sonluk.MES.MES;
using Sonluk.MES.MES.main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Sonluk.MES
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }
    }
}
