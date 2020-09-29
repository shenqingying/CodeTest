using Sonluk.UI.Model.CRM.HG_BZGZSJService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class HG_BZGZSJ
    {
        private HG_BZGZSJSoapClient client = new HG_BZGZSJSoapClient("HG_BZGZSJSoap", AppConfig.Settings("RemoteAddress") + "CRM/HG_BZGZSJ.asmx");
       
        public int Create(CRM_HG_BZGZSJ model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
     
        public int Update(CRM_HG_BZGZSJ model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
       
        public int Delete(int BZID, string ptoken)
        {
            return client.Delete(BZID, ptoken);
        }
      
        public CRM_HG_BZGZSJ[] Read(int STAFFID, string ptoken)
        {
            return client.Read(STAFFID,ptoken);
        }
        public CRM_HG_BZGZSJ ReadByBZNAME(string BZNAME, string ptoken)
        {

            return client.ReadByBZNAME(BZNAME,ptoken);
           

        }
        public CRM_HG_BZGZSJ ReadByBZID(int BZID, string ptoken)
        {

            return client.ReadByBZID(BZID,ptoken);
            

        }
    }
}
