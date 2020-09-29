using Sonluk.UI.Model.CRM.KH_KHXSService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class KH_KHXS
    {
        private KH_KHXSSoapClient client = new KH_KHXSSoapClient("KH_KHXSSoap", AppConfig.Settings("RemoteAddress") + "CRM/KH_KHXS.asmx");
        public int Create(CRM_KH_KHXS model, string ptoken)
        {

            return client.Create(model,ptoken);
          


        }
     
        public int Update(CRM_KH_KHXS model, string ptoken)
        {

            return client.Update(model,ptoken);
           

        }
       
        public int Delete(CRM_KH_KHXS model, string ptoken)
        {

            return client.Delete(model,ptoken);
          

        }
     
        public CRM_KH_KHXSList[] Read(CRM_KH_KHXS model, string ptoken)
        {

            return client.Read(model,ptoken);
          

        }
        public CRM_KH_KHXS_DZSreportList[] DZSreport(CRM_KH_KHXS_DZSreport model,int STAFFID, string ptoken)
        {
            return client.DZSreport(model, STAFFID, ptoken);
        }
    }
}
