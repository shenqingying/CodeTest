using Sonluk.UI.Model.CRM.KH_GROUP_KHService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class KH_GROUP_KH
    {
        private KH_GROUP_KHSoapClient client = new KH_GROUP_KHSoapClient("KH_GROUP_KHSoap", AppConfig.Settings("RemoteAddress") + "CRM/KH_GROUP_KH.asmx");
        
        public string[][] ReadByKHID(string ptoken, int KHID)
        {
            return client.ReadByKHID(ptoken, KHID);
        }

        public int Create(int KHID, int GID, string ptoken)
        {
            return client.Create(KHID, GID, ptoken);
        }
     
        public int Delete(int KHID, int GID, string ptoken)
        {
            return client.Delete(KHID, GID, ptoken);
        }
        public string[][] Read(string ptoken)
        {
            return client.Read(ptoken);
        }

        public int DeletebyKHID(int KHID, string ptoken)
        {

            return client.DeletebyKHID(KHID,ptoken);
          

        }

        public CRM_KH_GROUP_KHList[] ReadStruct(int KHID, int GID, string ptoken)
        {


            return client.ReadStruct(KHID, GID,ptoken);
           
        }
        public int Update(int KHID, int oGID, int nGid, string ptoken)
        {

            return client.Update(KHID, oGID, nGid,ptoken);
           

        }
        public CRM_KH_GROUP_KHList[] Report(string KHMC, int GID, string ptoken)
        {

            return client.Report(KHMC, GID,ptoken);
          

        }
        public CRM_KH_GROUP_KHList[] Report2(CRM_KH_GROUP_KHList model, string ptoken)
        {
            return client.Report2(model, ptoken);
        }
    }
}
