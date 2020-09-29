using Sonluk.UI.Model.CRM.PRODUCT_GROUPService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class PRODUCT_GROUP
    {
        private PRODUCT_GROUPSoapClient client = new PRODUCT_GROUPSoapClient("PRODUCT_GROUPSoap", AppConfig.Settings("RemoteAddress") + "CRM/PRODUCT_GROUP.asmx");


        public int Create(CRM_PRODUCT_GROUP model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_PRODUCT_GROUP model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public int Delete(int GROUPID, string ptoken)
        {
            return client.Delete(GROUPID, ptoken);
        }
        public CRM_PRODUCT_GROUP[] Read(string ptoken)
        {
            return client.Read(ptoken);
        }
        public int ReadByIDGroupName(string GROUPNAME, string ptoken)
        {
            return client.ReadByIDGroupName(GROUPNAME, ptoken);
        }

    }
}
