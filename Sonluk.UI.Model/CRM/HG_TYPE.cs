using Sonluk.UI.Model.CRM.HG_TYPEService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class HG_TYPE
    {
        private HG_TYPESoapClient client = new HG_TYPESoapClient("HG_TYPESoap", AppConfig.Settings("RemoteAddress") + "CRM/HG_TYPE.asmx");
        
        public int Create(CRM_HG_TYPE model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
     
        public int Update(CRM_HG_TYPE model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
     
        public CRM_HG_TYPE[] Read(string ptoken)
        {
            return client.Read(ptoken);
        }
       
        public int Delete(int TYPEID, string ptoken)
        {
            return client.Delete(TYPEID, ptoken);
        }
        public CRM_HG_TYPE[] ReadByTypeName(CRM_HG_TYPE model, string ptoken)
        {
            return client.ReadByTypeName(model, ptoken);
        }
    }
}
