using Sonluk.UI.Model.CRM.KH_BFService;
using Sonluk.UI.Model.CRM.KH_DZService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
   public class KH_BF
    {
       private KH_BFSoapClient client = new KH_BFSoapClient("KH_BFSoap", AppConfig.Settings("RemoteAddress") + "CRM/KH_BF.asmx");
       public int Create(CRM_KH_BF model, string ptoken)
       {


           return client.Create(model, ptoken);
         

       }
     
       public int Update(CRM_KH_BF model, string ptoken)
       {
           return client.Update(model, ptoken);
       }
    
       public int Delete(int BFID, string ptoken)
       {
           return client.Delete(BFID, ptoken);
       
       }
       public CRM_KH_BFList[] Read(CRM_KH_BF model,string ptoken)
       {

           return client.Read(model,ptoken);
          
       }

    }
}
