using Sonluk.UI.Model.LE.TRA.ReceiverService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.LE.TRA
{
    public class Receiver
    {
        private ReceiverSoapClient client = new ReceiverSoapClient("ReceiverSoap", AppConfig.Settings("RemoteAddress") + "LE/TRA/Receiver.asmx");

        public bool Exists(string serialNumber)
        {
            return client.Exists(serialNumber);
        }

        public IList<CompanyInfo> Read(int city)
        {
            return client.Read(city);
        }

        public CompanyInfo Read(string serialNumber)
        {
            return client.ReadBySerialNumber(serialNumber);
        }

        public IList<CompanyInfo> Select(string keyword)
        {
            return client.Select(keyword);
        }

        public int Create(CompanyInfo node)
        {
            return client.Create(node);
        }

        public int Update(CompanyInfo node)
        {
            return client.Update(node);
        }

    }
}
