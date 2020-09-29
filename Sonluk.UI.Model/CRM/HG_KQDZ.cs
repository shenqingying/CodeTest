

using Sonluk.UI.Model.CRM.HG_KQDZService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class HG_KQDZ
    {
        private HG_KQDZSoapClient client = new HG_KQDZSoapClient("HG_KQDZSoap", AppConfig.Settings("RemoteAddress") + "CRM/HG_KQDZ.asmx");
        
        public int Create(CRM_HG_KQDZ model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        
        public int Update(CRM_HG_KQDZ model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
       
        public int Delete(int KQDZID, string ptoken)
        {
            return client.Delete(KQDZID, ptoken);
        }
      
        public CRM_HG_KQDZ[] Read(int KQDZID, string ptoken)
        {
            return client.Read(KQDZID,ptoken);
        }
        public CRM_HG_KQDZ[] ReadBySTAFFID(int STAFFID,string ptoken)
        {
            return client.ReadBySTAFFID(STAFFID, ptoken);
        }
        public CRM_HG_KQDZ[] ReadBylikeKQDZ(string KQDZ,string ptoken)
        {
            return client.ReadBylikeKQDZ(KQDZ, ptoken);
        }

        public CRM_HG_KQDZList[] Report(CRM_HG_KQDZList model, string ptoken)
        {

            return client.Report(model, ptoken);
           

        }
    }
}
