using Sonluk.UI.Model.CRM.COST_CXHDPGHZService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_CXHDPGHZ
    {
        private COST_CXHDPGHZSoapClient client = new COST_CXHDPGHZSoapClient("COST_CXHDPGHZSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_CXHDPGHZ.asmx");

        public int Create(CRM_COST_CXHDPGHZ model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_CXHDPGHZ model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_COST_CXHDPGHZ[] ReadByParam(CRM_COST_CXHDPGHZ model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int Delete(int PGHZID, string ptoken)
        {
            return client.Delete(PGHZID, ptoken);
        }
        public int DeleteByCXHDID(int CXHDID, string ptoken)
        {
            return client.DeleteByCXHDID(CXHDID, ptoken);
        }
        public CRM_COST_CXHDPGHZ[] GetReport(CRM_COST_CXHDPGHZ model, string ptoken)
        {
            return client.GetReport(model, ptoken);
        }
        public int AutoUpdate(int CXHDID, string ptoken)
        {
            return client.AutoUpdate(CXHDID, ptoken);
        }



    }
}
