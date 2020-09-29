using Sonluk.UI.Model.CRM.COST_LKAHXZLTTService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_LKAHXZLTT
    {
        private COST_LKAHXZLTTSoapClient client = new COST_LKAHXZLTTSoapClient("COST_LKAHXZLTTSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_LKAHXZLTT.asmx");

        public int Create(CRM_COST_LKAHXZLTT model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_LKAHXZLTT model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_COST_LKAHXZLTT[] ReadByParam(CRM_COST_LKAHXZLTT model, int STAFFID, string ptoken)
        {
            return client.ReadByParam(model, STAFFID, ptoken);
        }
        public int Delete(int HXZLTTID, string ptoken)
        {
            return client.Delete(HXZLTTID, ptoken);
        }
        public CRM_COST_LKAHXZLTT ReadTTGLinfo(CRM_COST_LKAHXZLTT model, string ptoken)
        {
            return client.ReadTTGLinfo(model, ptoken);
        }
        public CRM_COST_HXZLTT[] ReadByPublic(CRM_COST_HXZLTT model, int STAFFID, string ptoken)
        {
            return client.ReadByPublic(model, STAFFID, ptoken);
        }


    }
}
