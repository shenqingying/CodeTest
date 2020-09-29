using Sonluk.UI.Model.MM.ScheduleRequisitionService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MM
{
    public class ScheduleRequisition
    {
        private ScheduleRequisitionSoapClient client = new ScheduleRequisitionSoapClient("ScheduleRequisitionSoap", AppConfig.Settings("RemoteAddress") + "MM/ScheduleRequisition.asmx");

        public string Create(ScheReqInfo node)
        {
            return client.Create(node);
        }

        public IList<ScheReqInfo> Read(ScheReqInfo keyword)
        {
            return client.Select(keyword);
        }

        public ScheReqInfo Read(string serialNumber)
        {
            return client.Read(serialNumber);
        }

        public bool Update(ScheReqInfo node)
        {
            return client.Update(node);
        }

        public bool Update(string serialNumber, string account, string status, string releaseCode, string comments)
        {
            return client.UpdateStatus(serialNumber, account, status, releaseCode, comments);
        }

        public bool Delete(string serialNumber)
        {
            return client.Delete(serialNumber);
        }

        public IList<ScheduleLineInfo> ItemRead(ScheReqInfo keyword)
        {
            return client.ItemRead(keyword);
        }

        public bool ItemStatus(IList<ScheduleLineInfo> nodes, int status, string comments)
        {
            return client.ItemStatus(nodes.ToArray(), status, comments);
        }

        public IList<ScheDelivDestInfo> DeliveryDestination()
        {
            return client.DeliveryDestination();
        }
    }
}
