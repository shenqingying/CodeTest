using Sonluk.UI.Model.LE.TRA.FeedbackService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.LE.TRA
{
    public class Feedback
    {
        private FeedbackSoapClient client = new FeedbackSoapClient("FeedbackSoap", AppConfig.Settings("RemoteAddress") + "LE/TRA/Feedback.asmx");

        public IList<FeedbackInfo> Read(FeedbackInfo keyowrds)
        {
            return client.Select(keyowrds);
        }

        public FeedbackInfo Read(int ID)
        {
            return client.Read(ID);
        }

        public string Verify(FeedbackInfo node)
        {
            return client.Verify(node);
        }

        public int Modify(FeedbackInfo node)
        {
            return client.Modify(node);
        }

        public IList<FeedbackItemInfo> Import(Stream file)
        {
            MemoryStream memoryStream = new MemoryStream();
            file.CopyTo(memoryStream);
            return client.Import(memoryStream.ToArray());
        }

        public IList<FeedbackInfo> Report(FeedbackInfo keywords)
        {
            return client.Report(keywords);
        }

        public MemoryStream Export(string type, IList<FeedbackInfo> nodes)
        {
            byte[] fileByte = client.Export(type, nodes.ToArray());
            MemoryStream memoryStream = new MemoryStream(fileByte);
            return memoryStream;
        }
    }
}
