using Sonluk.UI.Model.LE.TRA.UnitService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.LE.TRA
{
    public class Unit
    {
        private UnitSoapClient client = new UnitSoapClient("UnitSoap", AppConfig.Settings("RemoteAddress") + "LE/TRA/Unit.asmx");

        public IList<UnitInfo> Read()
        {
            return client.Read();
        }
    }
}
