
using Sonluk.UI.Model.CRM.HG_RYKQService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class HG_RYKQ
    {
        private HG_RYKQSoapClient client = new HG_RYKQSoapClient("HG_RYKQSoap", AppConfig.Settings("RemoteAddress") + "CRM/HG_RYKQ.asmx");
       
        public int Create(int STAFFID, int KQDZID, string ptoken)
        {
            return client.Create(STAFFID, KQDZID, ptoken);
        }
      
        public int Delete(int STAFFID, int KQDZID, string ptoken)
        {
            return client.Delete(STAFFID, KQDZID, ptoken);
        }
      
        public string[][] ReadBySTAFFID(int STAFFID, string ptoken)
        {
            return client.ReadBySTAFFID(STAFFID, ptoken);
        }
    }
}
