using Sonluk.UI.Model.DEV.LogService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.DEV
{
    public class Log
    {
        private LogSoapClient client = new LogSoapClient("LogSoap", AppConfig.Settings("RemoteAddress") + "DEV/Log.asmx");

        public IList<LogInfo> Read(int daysAge)
        {
            return client.Read(daysAge);
        }

    }
}
