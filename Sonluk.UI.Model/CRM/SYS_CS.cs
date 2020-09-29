using Sonluk.UI.Model.CRM.SYS_CSService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class SYS_CS
    {
        private SYS_CSService.SYS_CSSoapClient client = new SYS_CSService.SYS_CSSoapClient("SYS_CSSoap", AppConfig.Settings("RemoteAddress") + "CRM/SYS_CS.asmx");

        public int Update(CRM_SYS_CS model, string ptoken)
        {

            return client.Update(model,ptoken);
          



        }
      
        public CRM_SYS_CS[] Read(int ID, string ptoken)
        {

            return client.Read(ID,ptoken);
           


        }
    }
}
