using Sonluk.UI.Model.LE.TRA.GoodsService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.LE.TRA
{
    public class Goods
    {
        private GoodsSoapClient _Client = new GoodsSoapClient("GoodsSoap", AppConfig.Settings("RemoteAddress") + "LE/TRA/Goods.asmx");

        public GoodsInfo Read(string serialNumber)
        {
            return _Client.Read(serialNumber);
        }

        public int Update(GoodsInfo node)
        {
            return _Client.Update(node);
        }

        public IList<GoodsInfo> Type()
        {
            return _Client.Type();
        }

    }
}
