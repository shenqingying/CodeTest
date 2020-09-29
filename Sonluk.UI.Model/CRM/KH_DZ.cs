using Sonluk.UI.Model.CRM.KH_DZService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class KH_DZ
    {
        private KH_DZSoapClient client = new KH_DZSoapClient("KH_DZSoap", AppConfig.Settings("RemoteAddress") + "CRM/KH_DZ.asmx");
        public int Create(CRM_KH_DZ model, string ptoken)
        {

            return client.Create(model,ptoken);
           

        }
      
        public int Update(CRM_KH_DZ model, string ptoken)
        {

            return client.Update(model,ptoken);
          

        }
       
        public int Delete(int DZID, string ptoken)
        {

            return client.Delete(DZID,ptoken);
        

        }

        public CRM_KH_DZList[] ReadByKHID(int KHID, string ptoken)
        {

            return client.ReadByKHID(KHID,ptoken);
            

        }
    }
}
