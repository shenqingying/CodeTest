using Sonluk.UI.Model.OA.FlowService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.OA
{
    public class Flow
    {
        private FlowSoapClient client = new FlowSoapClient("FlowSoap", AppConfig.Settings("RemoteAddress") + "OA/Flow.asmx");

        public IList<FlowLogInfo> Log(string startDate, string endDate,string keyword)
        {
            return client.Log(startDate, endDate, keyword);
        }

    }
}
