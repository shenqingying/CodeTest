using Sonluk.UI.Model.CRM.COST_LKAYEARXSService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_LKAYEARXS
    {
        private COST_LKAYEARXSSoapClient client = new COST_LKAYEARXSSoapClient("COST_LKAYEARXSSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_LKAYEARXS.asmx");

        public int Create(CRM_COST_LKAYEARXS model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_LKAYEARXS model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_COST_LKAYEARXS[] ReadByParam(CRM_COST_LKAYEARXS model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int Delete(int LKAYEARTTID, string ptoken)
        {
            return client.Delete(LKAYEARTTID, ptoken);
        }
        public int UpdateSonlukXS(int LKAYEARTTID, string ptoken)
        {
            return client.UpdateSonlukXS(LKAYEARTTID, ptoken);
        }
    }
}
