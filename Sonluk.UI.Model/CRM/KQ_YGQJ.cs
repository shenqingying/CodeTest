using Sonluk.UI.Model.CRM.KQ_YGQJService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class KQ_YGQJ
    {
        private KQ_YGQJSoapClient client = new KQ_YGQJSoapClient("KQ_YGQJSoap", AppConfig.Settings("RemoteAddress") + "CRM/KQ_YGQJ.asmx");
       

        public int Create(CRM_KQ_YGQJ model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
       
        public int Update(CRM_KQ_YGQJ model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
    
        public int Delete(int YGQJID, string ptoken)
        {
            return client.Delete(YGQJID, ptoken);
        }

        public CRM_KQ_YGQJList[] ReadBySTAFFID(int STAFFID, int STATUS, string ptoken)
        {
            return client.ReadBySTAFFID(STAFFID,STATUS,ptoken);
        }

        public int Verify_QJ(string beginTime, string endTime, int STAFFID, string ptoken, int YGQJID, int CCID)
        {

            return client.Verify_QJ(beginTime, endTime, STAFFID, YGQJID,CCID, ptoken);
          

        }

        public CRM_KQ_YGQJ ReadByYGQJID(int YGQJID, string ptoken)
        {

            return client.ReadByYGQJID(YGQJID,ptoken);
           

        }
        public CRM_KQ_YGQJList[] ReadByDepartRight(CRM_KQ_YGQJ model, string ptoken)
        {
            return client.ReadByDepartRight(model, ptoken);
        }
        public CRM_KQ_YGQJList[] Read(CRM_KQ_YGQJ model, string ptoken)
        {

            return client.Read(model,ptoken);
           

        }

    }
}
