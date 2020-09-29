using Sonluk.UI.Model.CRM.HG_STAFFDUTYService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class HG_STAFFDUTY
    {
        private HG_STAFFDUTYSoapClient client = new HG_STAFFDUTYSoapClient("HG_STAFFDUTYSoap", AppConfig.Settings("RemoteAddress") + "CRM/HG_STAFFDUTY.asmx");
       

        public int Create(int STAFFID, int DUTYID, string ptoken)
        {
            return client.Create(STAFFID, DUTYID,ptoken);
        }
      
        public int Delete(int STAFFID, int DUTYID, string ptoken)
        {
            return client.Delete(STAFFID, DUTYID,ptoken);
        }
       
        public string[][] ReadBySTAFFID(int STAFFID, string ptoken)
        {
            return client.ReadBySTAFFID(STAFFID,ptoken);
        }
        public int DeleteByStaffid(int STAFFID, string ptoken)
        {

            return client.DeleteByStaffid(STAFFID, ptoken);
          

        }
    }
}
