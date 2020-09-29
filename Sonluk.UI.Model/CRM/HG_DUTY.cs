using Sonluk.UI.Model.CRM.HG_DUTYService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class HG_DUTY
    {
        private HG_DUTYSoapClient client = new HG_DUTYSoapClient("HG_DUTYSoap", AppConfig.Settings("RemoteAddress") + "CRM/HG_DUTY.asmx");
       

        public int Create(CRM_HG_DUTY model, string ptoken)
        {
            return client.Create(model,ptoken);
        }
     
        public int Update(CRM_HG_DUTY model, string ptoken)
        {
            return client.Update(model,ptoken);
        }
       
        public int Delete(int DUTYID, string ptoken)
        {
            return client.Delete(DUTYID,ptoken);
        }
   
        public CRM_HG_DUTY[] Read(string ptoken)
        {
            return client.Read(ptoken);
        }



    }
}
