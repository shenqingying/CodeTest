using Sonluk.UI.Model.LE.TRA.PriceService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.LE.TRA
{
    public class Price
    {
        private PriceSoapClient _Client = new PriceSoapClient("PriceSoap", AppConfig.Settings("RemoteAddress") + "LE/TRA/Price.asmx");

        public IList<PriceInfo> Read(int routeID)
        {
            return _Client.Read(routeID).ToList();
        }

        public int Create(List<PriceInfo> nodes)
        {
            return _Client.Create(nodes.ToArray());
        }

    }
}
