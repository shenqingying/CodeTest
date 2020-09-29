using Sonluk.UI.Model.CRM.BF_BFJHMXService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class BF_BFJHMX
    {
        private BF_BFJHMXSoapClient client = new BF_BFJHMXSoapClient("BF_BFJHMXSoap", AppConfig.Settings("RemoteAddress") + "CRM/BF_BFJHMX.asmx");
        public int Create(CRM_BF_BFJHMX model, string ptoken)
        {

            return client.Create(model, ptoken);
           

        }
       
        public int Update(CRM_BF_BFJHMX model, string ptoken)
        {

            return client.Update(model, ptoken);
            

        }
       
        public int Delete(CRM_BF_BFJHMX model, string ptoken)
        {

            return client.Delete(model, ptoken);
        }

        public CRM_BF_BFJHMXList[] ReadbyBFJHID(int BFJHID, string ptoken)
        {

            return client.ReadbyBFJHID(BFJHID,ptoken);
           

        }
    }
}
