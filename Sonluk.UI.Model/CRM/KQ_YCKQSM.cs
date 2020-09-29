using Sonluk.UI.Model.CRM.KQ_YCKQSMService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
   public  class KQ_YCKQSM
    {
       private KQ_YCKQSMSoapClient client = new KQ_YCKQSMSoapClient("KQ_YCKQSMSoap", AppConfig.Settings("RemoteAddress") + "CRM/KQ_YCKQSM.asmx");
        public int Create(CRM_KQ_YCKQSM model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        
        public int Update(CRM_KQ_YCKQSM model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
    
        public CRM_KQ_YCKQSMList[] ReadBySTAFFID(int STAFFID, string ptoken)
        {
            return client.ReadBySTAFFID(STAFFID, ptoken);
        }
       
        public int Delete(int YCKQID, string ptoken)
        {
            return client.Delete(YCKQID, ptoken);
        }


        public CRM_KQ_YCKQList[] Report_YC(int STAFFID, string fromdate, string todate, string ptoken)
        {

            return client.Report_YC(STAFFID, fromdate, todate,ptoken);
           

        }
        public CRM_KQ_YCKQSMList[] ReadByParam(CRM_KQ_YCKQSMList model, string ptoken)
        {

            return client.ReadByParam(model, ptoken);


        }
       public int UpdateStatus(int YCKQID, int ISACTIVE, string ptoken)
        {
            return client.UpdateStatus(YCKQID, ISACTIVE, ptoken);
        }
    }
}
