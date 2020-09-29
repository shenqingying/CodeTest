using Sonluk.UI.Model.CRM.COST_PUBLICService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
 public   class COST_PUBLIC
    {
     private COST_PUBLICSoapClient client = new COST_PUBLICSoapClient("COST_PUBLICSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_PUBLIC.asmx");


     public CRM_COST_PUBLIC[] ReadByPublic(CRM_COST_HXZLTT MODEL, CRM_COST_ZZFTT MODEL_JXS, CRM_COST_ZZFTT MODEL_KA, CRM_COST_ZZFTT MODEL_LKA, CRM_COST_ZZFTT MODEL_ZDWD, int STAFFID, string ptoken)
     {
         return client.ReadByPublic(MODEL, MODEL_JXS, MODEL_KA, MODEL_LKA, MODEL_ZDWD, STAFFID, ptoken);
     }
        
    }
}
