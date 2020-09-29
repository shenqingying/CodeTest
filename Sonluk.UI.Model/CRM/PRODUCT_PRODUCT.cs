using Sonluk.UI.Model.CRM.PRODUCT_PRODUCTService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class PRODUCT_PRODUCT
    {
        private PRODUCT_PRODUCTSoapClient client = new PRODUCT_PRODUCTSoapClient("PRODUCT_PRODUCTSoap", AppConfig.Settings("RemoteAddress") + "CRM/PRODUCT_PRODUCT.asmx");


        public int Create(CRM_PRODUCT_PRODUCT model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_PRODUCT_PRODUCT model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public int Delete(int PRODUCTID, string ptoken)
        {
            return client.Delete(PRODUCTID, ptoken);
        }
        public CRM_PRODUCT_PRODUCT[] ReadByParam(CRM_PRODUCT_PRODUCT model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public CRM_PRODUCT_PRODUCT ReadByID(int PRODUCTID, string ptoken)
        {
            return client.ReadByID(PRODUCTID, ptoken);
        }
        public CRM_PRODUCT_PRODUCT[] ReadByRight(int KHID, string SDF, int CPLX, int ORDERTTID, string CPMC, string ptoken)
        {
            return client.ReadByRight(KHID,SDF, CPLX, ORDERTTID, CPMC, ptoken);
        }
        public CRM_PRODUCT_PRODUCT[] ReadCPLXByRight(int KHID, string ptoken)
        {
            return client.ReadCPLXByRight(KHID, ptoken);
        }


    }
}
