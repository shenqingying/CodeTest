using Sonluk.UI.Model.BC.EnqueueService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.BC
{
    public class Enqueue
    {
        private EnqueueSoapClient client = new EnqueueSoapClient("EnqueueSoap", AppConfig.Settings("RemoteAddress") + "BC/Enqueue.asmx");

        public IList<EnqueueInfo> Read(string value)
        {
            return client.Read(value);
        }
    }
}
