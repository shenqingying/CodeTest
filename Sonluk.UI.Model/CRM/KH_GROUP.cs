using Sonluk.UI.Model.CRM.KH_GROUPService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class KH_GROUP
    {
        private KH_GROUPSoapClient client = new KH_GROUPSoapClient("KH_GROUPSoap", AppConfig.Settings("RemoteAddress") + "CRM/KH_GROUP.asmx");
        

      
        public int Create(CRM_KH_GROUP model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
      
        public int Update(CRM_KH_GROUP model, string ptoken)
        {
            return client.Update(model, ptoken);
        }

        public CRM_KH_GROUPList[] Read(string ptoken)
        {
            return client.Read(ptoken);
        }

        public CRM_KH_GROUPList[] ReadByParam(CRM_KH_GROUPList model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
       
        public int Delect(int GID, string ptoken)
        {
            return client.Delect(GID, ptoken);
        }
        //public string[][] ReadByKHID(string ptoken, int KHID)
        //{
        //    return client.ReadByKHID(ptoken, KHID);
        //}
        public CRM_KH_GROUPList ReadbyGId(int GID, string ptoken)
        {

            return client.ReadbyGId(GID,ptoken);
           

        }
        public CRM_KH_GROUPList[] ReadBySTAFFID(int STAFFID, string ptoken)
        {
            return client.ReadBySTAFFID(STAFFID,ptoken);         
        }

        public int ReadGidByGNAME(string gname, string ptoken)
        {
            return client.ReadGidByGNAME(gname,ptoken);
        }
    }
}
