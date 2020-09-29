using Sonluk.UI.Model.LE.TRA.DestinationService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.LE.TRA
{
    public class Destination
    {
        private DestinationSoapClient client = new DestinationSoapClient("DestinationSoap", AppConfig.Settings("RemoteAddress") + "LE/TRA/Destination.asmx");

        public IList<DestinationInfo> Read(int parentID)
        {
            return client.Read(parentID);
        }

        public DestinationInfo ReadSingle(int ID)
        {
            return client.ReadSingle(ID);
        }

        public int Modify(DestinationInfo node)
        {
            return client.Modify(node);
        }

    }
}
