using Sonluk.UI.Model.CRM.HD_ZDFService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class HD_ZDF
    {
        private HD_ZDFSoapClient client = new HD_ZDFSoapClient("HD_ZDFSoap", AppConfig.Settings("RemoteAddress") + "CRM/HD_ZDF.asmx");
        public int Create(CRM_HD_ZDF model, string ptoken)
        {
            return client.Create(model, ptoken);
        }

        public int Update(CRM_HD_ZDF model, string ptoken)
        {
            return client.Update(model, ptoken);
        }

        public int Delete(int ZDFID, string ptoken)
        {
            return client.Delete(ZDFID, ptoken);
        }
        public CRM_HD_ZDFList[] Read(CRM_HD_ZDF_PARAMS model, string ptoken)
        {

            return client.Read(model, ptoken);


        }
        public CRM_HD_ZDF ReadByZDFID(int ZDFID, string ptoken)
        {
            return client.ReadByZDFID(ZDFID, ptoken);
        }

        public CRM_HD_ZDFList[] ReadBySTAFFID(CRM_HD_ZDF_PARAMS model, string ptoken)
        {
            return client.ReadBySTAFFID(model, ptoken);
        }
    }
}
