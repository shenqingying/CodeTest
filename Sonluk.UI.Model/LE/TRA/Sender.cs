using Sonluk.UI.Model.LE.TRA.SenderService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.LE.TRA
{
    public class Sender
    {
        private SenderSoapClient client = new SenderSoapClient("SenderSoap", AppConfig.Settings("RemoteAddress") + "LE/TRA/Sender.asmx");

        public IList<CompanyInfo> Read()
        {
            return client.ReadList();
        }

        public CompanyInfo Read(string serialNumber)
        {
            return client.Read(serialNumber);
        }
    }
}
