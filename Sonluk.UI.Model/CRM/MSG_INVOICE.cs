using Sonluk.UI.Model.CRM.MSG_INVOICEService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class MSG_INVOICE
    {
        private MSG_INVOICESoapClient client = new MSG_INVOICESoapClient("MSG_INVOICESoap", AppConfig.Settings("RemoteAddress") + "CRM/MSG_INVOICE.asmx");


        public int Create(CRM_MSG_INVOICE model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_MSG_INVOICE model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_MSG_INVOICEList[] ReadByParam(CRM_MSG_INVOICEParam model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int Delete(int INVOICEID, string ptoken)
        {
            return client.Delete(INVOICEID, ptoken);
        }
        public CRM_MSG_INVOICEList[] ReadByKHID(int KHID, string ptoken)
        {
            return client.ReadByKHID(KHID, ptoken);
        }
        public int AddCount(int INVOICEID, string ptoken)
        {
            return client.AddCount(INVOICEID, ptoken);
        }

    }
}
