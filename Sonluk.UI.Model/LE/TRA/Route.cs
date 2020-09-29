using Sonluk.UI.Model.LE.TRA.RouteService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.LE.TRA
{
    public class Route
    {
        private RouteSoapClient _Client = new RouteSoapClient("RouteSoap", AppConfig.Settings("RemoteAddress") + "LE/TRA/Route.asmx");

        public RouteInfo Read(int source, int destination, decimal weight, string departure)
        {
            return _Client.Read(source, destination, weight, departure);
        }

        public RouteInfo Read(int cityID)
        {
            return _Client.ReadByCityID(cityID);
        }

        public int Create(RouteInfo node)
        {
            return _Client.Create(node);
        }

        public int Update(RouteInfo node)
        {
            return _Client.Update(node);
        }

        public string ReadDJ(int source, int destination, decimal weight)
        {
            return _Client.ReadDJ(source, destination, weight);
        }

        public string ReadZSF(int BZDID, int EZDID)
        {
            return _Client.ReadZSF(BZDID, EZDID);
        }
    }
}
