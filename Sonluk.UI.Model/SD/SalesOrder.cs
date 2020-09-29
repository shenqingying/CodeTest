using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sonluk.Utility;
using Sonluk.UI.Model.SD.SalesOrderService;

namespace Sonluk.UI.Model.SD
{
    public class SalesOrder
    {
        private SalesOrderSoapClient client = new SalesOrderSoapClient("SalesOrderSoap", AppConfig.Settings("RemoteAddress") + "SD/SalesOrder.asmx");

        public IList<SOItemInfo> Read(SOKeywordInfo node)
        {
            return client.Read(node);
        }

        public string ProcessingRecords(IList<SOItemInfo> nodes)
        {
            return client.ProcessingRecords(nodes.ToArray());
        }
    }
}
