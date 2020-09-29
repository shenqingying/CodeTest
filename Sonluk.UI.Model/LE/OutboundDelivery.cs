using Sonluk.UI.Model.LE.OutboundDeliveryService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.LE
{
    public class OutboundDelivery
    {
        private OutboundDeliverySoapClient client = new OutboundDeliverySoapClient("OutboundDeliverySoap", AppConfig.Settings("RemoteAddress") + "LE/OutboundDelivery.asmx");

        public IList<DeliveryInfo> Read(DeliveryInfo keyowrds)
        {
            return client.Read(keyowrds);
        }

        public IList<DeliveryItemInfo> ItemRead(string serialNumber)
        {
            return client.ItemRead(serialNumber);
        }

        public MemoryStream Export(IList<DeliveryInfo> nodes)
        {
            byte[] fileByte = client.Export(nodes.ToArray());
            MemoryStream memoryStream = new MemoryStream(fileByte);
            return memoryStream;
        }
    }
}
