using Sonluk.UI.Model.CRM.BF_BFQDService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class BF_BFQD
    {
         //private BF_BFSoapClient client = new BF_BFSoapClient("BF_BFSoap", AppConfig.Settings("RemoteAddress") + "CRM/BF_BF.asmx");
        BF_BFQDSoapClient client = new BF_BFQDSoapClient("BF_BFQDSoap", AppConfig.Settings("RemoteAddress") + "CRM/BF_BFQD.asmx");
        public int Create(CRM_BF_BFQD model, string ptoken)
        {
            return client.Create(model, ptoken);
          
        }
      
        public CRM_BF_BFQDLIST[] ReadByBFDJID(int BFDJID, string ptoken)
        {

            return client.ReadByBFDJID(BFDJID, ptoken);
           
        }
     
        public int Delete(int BFQDID, string ptoken)
        {

            return client.Delete(BFQDID, ptoken);
         

        }
    }
}
