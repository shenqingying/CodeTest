using Sonluk.UI.Model.CRM.KH_KHBFService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class KH_KHBF
    {
        private KH_KHBFSoapClient client = new KH_KHBFSoapClient("KH_KHBFSoap", AppConfig.Settings("RemoteAddress") + "CRM/KH_KHBF.asmx");
        public int Create(CRM_KH_KHBFList model, string ptoken)
        {

            return client.Create(model, ptoken);


        }
        public CRM_KH_KHBFList[] Read(int BFID, int KHID, string ptoken)
        {
            return client.Read(BFID, KHID, ptoken);
        }

        public int Delete(CRM_KH_KHBFList model, string ptoken)
        {

            return client.Delete(model, ptoken);


        }
        public CRM_KH_KHBFList[] ReadByParms(CRM_KH_KHBF_Parms model, string ptoken)
        {

            return client.ReadByParms(model,ptoken);
          

        }
    }
}
