using Sonluk.UI.Model.CRM.KH_GROUP_XSQYService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class KH_GROUP_XSQY
    {
        private KH_GROUP_XSQYSoapClient client = new KH_GROUP_XSQYSoapClient("KH_GROUP_XSQYSoap", AppConfig.Settings("RemoteAddress") + "CRM/KH_GROUP_XSQY.asmx");
        public int Create(CRM_KH_GROUP_XSQY model, string ptoken)
        {

            return client.Create(model, ptoken);


        }

        public int Update(CRM_KH_GROUP_XSQY model, string ptoken)
        {

            return client.Update(model, ptoken);

        }

        public int Delete(int XSQYID, string ptoken)
        {

            return client.Delete(XSQYID, ptoken);


        }

        public CRM_KH_GROUP_XSQY[] Read(string ptoken)
        {

            return client.Read(ptoken);


        }

    }
}
