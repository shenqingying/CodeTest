using Sonluk.UI.Model.LE.TRA.ConsignmentNoteService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.LE.TRA
{
    public class ConsignmentNote
    {
        private ConsignmentNoteSoapClient client = new ConsignmentNoteSoapClient("ConsignmentNoteSoap", AppConfig.Settings("RemoteAddress") + "LE/TRA/ConsignmentNote.asmx");

        public int Exists(string serialNumber)
        {
            return client.Exists(serialNumber);
        }

        public CNInfo Generate(List<string> deliverySet, int carrier, bool replace)
        {
            return client.Generate(deliverySet.ToArray(), carrier, replace);
        }

        public int Create(CNInfo node)
        {
            return client.Create(node);
        }

        public IList<CNInfo> Read(CNInfo keyowrds)
        {
            return client.Select(keyowrds);
        }

        public IList<CNDeliveryInfo> ReadCNDeliveryByID(int ID)
        {
            return client.ReadCNDeliveryByID(ID);
        }

        public CNInfo Read(int ID)
        {
            return client.Read(ID);
        }

        public IList<CNInfo> Report(CNInfo keyowrds)
        {
            return client.Report(keyowrds);
        }

        public string CurrentNumber(int carrierID)
        {
            return client.CurrentNumber(carrierID);
        }

        public bool Update(CNInfo node)
        {
            return client.Update(node);
        }

        public int Delete(int ID)
        {
            return client.Delete(ID);
        }

        public MemoryStream Export(string type, IList<CNInfo> nodes)
        {
            byte[] fileByte = client.Export(type, nodes.ToArray());
            MemoryStream memoryStream = new MemoryStream(fileByte);
            return memoryStream;
        }

        public List<CNDeliveryInfo> CNDeliveryUPDATE(string serialNumber, int TYDID, int STATUS, string FILLNAME, string FILLID)
        {
            return client.CNDeliveryUPDATE(serialNumber, TYDID, STATUS, FILLNAME, FILLID).ToList();
        }
    }
}
