using Sonluk.UI.Model.CRM.KH_HDService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class KH_HD
    {
        private KH_HDSoapClient client = new KH_HDSoapClient("KH_HDSoap", AppConfig.Settings("RemoteAddress") + "CRM/KH_HD.asmx");

        public int Create(CRM_KH_HD model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_KH_HD model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public int Delete(int HDID, string ptoken)
        {
            return client.Delete(HDID, ptoken);
        }
        public CRM_KH_HDList[] ReadByKHID(int KHID, string ptoken)
        {
            return client.ReadByKHID(KHID, ptoken);
        }
        public CRM_KH_HD ReadByID(int HDID, string ptoken)
        {
            return client.ReadByID(HDID, ptoken);
        }


    }
}
