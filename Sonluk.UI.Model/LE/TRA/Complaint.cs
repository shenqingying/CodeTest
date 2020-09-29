using Sonluk.UI.Model.LE.TRA.ComplaintService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.LE.TRA
{
    public class Complaint
    {
        private ComplaintSoapClient client = new ComplaintSoapClient("ComplaintSoap", AppConfig.Settings("RemoteAddress") + "LE/TRA/Complaint.asmx");

        public IList<ComplaintInfo> Read(ComplaintInfo keyowrds)
        {
            return client.Select(keyowrds);
        }

        public ComplaintInfo Read(int ID)
        {
            return client.Read(ID);
        }

        public ComplaintInfo Generate(int consignmentNote)
        {
            return client.Generate(consignmentNote);
        }

        public int Create(ComplaintInfo node)
        {
            return client.Create(node);
        }

        public int Update(ComplaintInfo node)
        {
            return client.Update(node);
        }

        public int Modify(ComplaintInfo node)
        {
            return client.Modify(node);
        
        }

        public IList<ComplaintInfo> Report(ComplaintInfo keywords)
        {
            return client.Report(keywords);
        }

        public MemoryStream Export(string type, IList<ComplaintInfo> nodes)
        {
            byte[] fileByte = client.Export(type, nodes.ToArray());
            MemoryStream memoryStream = new MemoryStream(fileByte);
            return memoryStream;
        }

    }
}
