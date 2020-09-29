using Sonluk.UI.Model.CRM.KH_GROUP_STAFFService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class KH_GROUP_STAFF
    {
        private KH_GROUP_STAFFSoapClient client = new KH_GROUP_STAFFSoapClient("KH_GROUP_STAFFSoap", AppConfig.Settings("RemoteAddress") + "CRM/KH_GROUP_STAFF.asmx");
        
        public int Create(int STAFFID, int GID, string ptoken)
        {
            return client.Create(STAFFID, GID,ptoken);
        }
      
        public int Delete(int STAFFID, int GID, string ptoken)
        {
            return client.Delete(STAFFID, GID,ptoken);
        }
     
        public string[][] ReadByStaffID(int StaffID, string ptoken)
        {
            return client.ReadByStaffID(StaffID,ptoken);
        }
        public string[][] Read(string ptoken)
        {
            return client.Read(ptoken);
        }
        public CRM_KH_GROUP_STAFFList ReadStruct(int STAFFID, int GID, string ptoken)
        {

            return client.ReadStruct(STAFFID, GID, ptoken);
          


        }
        public int Update(int STAFFID, int oGID, int nGid, string ptoken)
        {

            return client.Update(STAFFID, oGID, nGid,ptoken);
            

        }

        public CRM_KH_GROUP_STAFFList[] Report(string STAFFNAME, int GID, string ptoken)
        {

            return client.Report(STAFFNAME, GID,ptoken);
          

        }
    }
}
