
using Sonluk.UI.Model.CRM.OA_TRANSMITService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class OA_TRANSMIT
    {
        private OA_TRANSMITSoapClient client = new OA_TRANSMITSoapClient("OA_TRANSMITSoap", AppConfig.Settings("RemoteAddress") + "CRM/OA_TRANSMIT.asmx");
        public int Create(CRM_OA_TRANSMIT model,string ptoken)
        {
            return client.Create(model,ptoken);
        }
      
        public int Update(CRM_OA_TRANSMIT model,string ptoken)
        {
            return client.Update(model,ptoken);
        }
      
        public int Delete(int ID,string ptoken)
        {
            return client.Delete(ID,ptoken);
        }
       
        public CRM_OA_TRANSMIT[] Read(int Status,string ptoken)
        {
            return client.Read(Status,ptoken);
        }
        public CRM_OA_TRANSMIT[] ReadByParam(CRM_OA_TRANSMIT model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
    }
}
