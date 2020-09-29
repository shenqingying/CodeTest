using Sonluk.UI.Model.CRM.KQ_GZRLService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class KQ_GZRL
    {
        private KQ_GZRLSoapClient client = new KQ_GZRLSoapClient("KQ_GZRLSoap", AppConfig.Settings("RemoteAddress") + "CRM/KQ_GZRL.asmx");
       
        public int Create(CRM_KQ_GZRL model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
       
        public int Update(CRM_KQ_GZRL model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
       
        public int Delete(int BBID, string ptoken)
        {
            return client.Delete(BBID, ptoken);
        }
       
        public CRM_KQ_GZRL[] Read(string MS,int BBID,string ptoken)
        {
            return client.Read(MS,BBID,ptoken);
        }

        //public CRM_KQ_GZRL ReadByMS(string MS, string ptoken)
        //{

        //    return client.ReadByMS(MS,ptoken);
           
        //}
        //public CRM_KQ_GZRL ReadByBBID(int BBID, string ptoken)
        //{

        //    return client.ReadByBBID(BBID,ptoken);
          

        //}
    }
}
