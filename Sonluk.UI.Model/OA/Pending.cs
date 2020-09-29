using Sonluk.UI.Model.OA.PendingService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.OA
{
    public class Pending
    {
        private PendingSoapClient client = new PendingSoapClient("PendingSoap", AppConfig.Settings("RemoteAddress") + "OA/Pending.asmx");

        public IList<PendingInfo> Read( string ticketId, int firstNum, int pageSize,string address)
        {
            return client.Read(ticketId, firstNum, pageSize, address);
        }

    }
}
