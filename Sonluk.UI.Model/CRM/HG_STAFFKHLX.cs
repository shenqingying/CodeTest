using Sonluk.UI.Model.CRM.HG_STAFFKHLXService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class HG_STAFFKHLX
    {
        private HG_STAFFKHLXSoapClient client = new HG_STAFFKHLXSoapClient("HG_STAFFKHLXSoap", AppConfig.Settings("RemoteAddress") + "CRM/HG_STAFFKHLX.asmx");
        public int Create(CRM_HG_STAFFKHLX model, string ptoken)
        {

            return client.Create(model, ptoken);
            ;

        }

        public int Update(CRM_HG_STAFFKHLX model, string ptoken)
        {

            return client.Update(model, ptoken);


        }
        public int Delete(int STAFFKHLXID, string ptoken)
        {

            return client.Delete(STAFFKHLXID, ptoken);


        }

        public CRM_HG_STAFFKHLX[] Read(string ptoken)
        {

            return client.Read(ptoken);


        }
        public CRM_HG_STAFFKHLX ReadBySTAFFKHLXID(int STAFFKHLXID, string ptoken)
        {
            return client.ReadBySTAFFKHLXID(STAFFKHLXID, ptoken);
        }
    }
}
