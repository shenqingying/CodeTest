using Sonluk.Entities.Common;
using Sonluk.Utility.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Sonluk.Utility
{
    public class Logger
    {
        private static Queues _Queues = new Queues();

        static Logger()
        {
            Process.Start(_Queues);
        }

        public static void Write(string title, string content)
        {
            _Queues.Add(new LogInfo(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fffffff"),title, content));
        }
    }
}
