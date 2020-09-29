using Sonluk.UI.Model.LE.TRA.CityService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.LE.TRA
{
    public class City
    {
        private CitySoapClient _Client = new CitySoapClient("CitySoap", AppConfig.Settings("RemoteAddress") + "LE/TRA/City.asmx");

        public IList<CityInfo> Read()
        {
            return _Client.Read();
        }

        public int Create(CityInfo node)
        {
            return _Client.Create(node);
        }

        public int Update(CityInfo node)
        {
            return _Client.Update(node);
        }

        public int Modify(CityInfo node)
        {
            return _Client.Modify(node);
        }

        public int Delete(int ID, bool province)
        {
            return _Client.Delete(ID, province);
        }
    }
}
