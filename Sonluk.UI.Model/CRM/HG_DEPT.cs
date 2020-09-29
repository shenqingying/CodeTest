using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sonluk.UI.Model.CRM.HG_DEPTService;
using Sonluk.Utility;
namespace Sonluk.UI.Model.CRM
{
    public class HG_DEPT
    {
        private HG_DEPTSoapClient client = new HG_DEPTSoapClient("HG_DEPTSoap", AppConfig.Settings("RemoteAddress") + "CRM/HG_DEPT.asmx");
        
        public int Create(CRM_HG_DEPT model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
      
        public int Update(CRM_HG_DEPT model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
   
        public int Delete(int DEPID, string ptoken)
        {
            return client.Delete(DEPID, ptoken);
        }
      
        public CRM_HG_DEPT[] Read(string ptoken)
        {
            return client.Read(ptoken);
        }
        public CRM_HG_DEPTList ReadByDEPID(int DEPID, string ptoken)
        {

            return client.ReadByDEPID(DEPID,ptoken);
         

        }
        public CRM_HG_DEPT ReadByName(string DEPNAME, string ptoken)
        {

            return client.ReadByName(DEPNAME,ptoken);
           

        }
        public CRM_HG_DEPT[] ReadByStaffid(int STAFFID, string ptoken)
        {

            return client.ReadByStaffid(STAFFID, ptoken);


        }

    }
}
