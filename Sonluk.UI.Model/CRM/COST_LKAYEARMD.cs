using Sonluk.UI.Model.CRM.COST_LKAYEARMDService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_LKAYEARMD
    {
        private COST_LKAYEARMDSoapClient client = new COST_LKAYEARMDSoapClient("COST_LKAYEARMDSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_LKAYEARMD.asmx");

        public int Create(CRM_COST_LKAYEARMD model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_LKAYEARMD model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public int UpdateMDSL(int LKAYEARTTID, string ptoken)
        {
            return client.UpdateMDSL(LKAYEARTTID, ptoken);
        }
        public CRM_COST_LKAYEARMD[] ReadByParam(CRM_COST_LKAYEARMD model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int Delete(int MDID, string ptoken)
        {
            return client.Delete(MDID, ptoken);
        }
        public CRM_COST_LKAYEARMD[] ReadMDQKbyKHID(int KHID, string ptoken)
        {
            return client.ReadMDQKbyKHID(KHID, ptoken);
        }
    }
}
