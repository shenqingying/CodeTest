using Sonluk.UI.Model.LE.TRA.CarrierService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.LE.TRA
{
    public class Carrier
    {
        private CarrierSoapClient client = new CarrierSoapClient("CarrierSoap", AppConfig.Settings("RemoteAddress") + "LE/TRA/Carrier.asmx");

        public IList<CompanyInfo> Read()
        {
            return client.Read();
        }
    }
}
