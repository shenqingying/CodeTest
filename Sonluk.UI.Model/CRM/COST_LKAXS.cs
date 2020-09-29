using Sonluk.UI.Model.CRM.COST_LKAXSService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_LKAXS
    {
        private COST_LKAXSSoapClient client = new COST_LKAXSSoapClient("COST_LKAXSSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_LKAXS.asmx");


        public int CreateTT(CRM_COST_LKAXSTT model, string ptoken)
        {
            return client.CreateTT(model, ptoken);
        }
        public int UpdateTT(CRM_COST_LKAXSTT model, string ptoken)
        {
            return client.UpdateTT(model, ptoken);
        }
        public CRM_COST_LKAXSTT[] ReadTTByParam(CRM_COST_LKAXSTT model, int STAFFID, string ptoken)
        {
            return client.ReadTTByParam(model, STAFFID, ptoken);
        }
        public int DeleteTT(int LKAXSTTID, string ptoken)
        {
            return client.DeleteTT(LKAXSTTID, ptoken);
        }
        public CRM_COST_LKAXSTT[] ReadKHbasic(CRM_COST_LKAXSTT model, string ptoken)
        {
            return client.ReadKHbasic(model, ptoken);
        }


        public int CreateMX(CRM_COST_LKAXSMX model, string ptoken)
        {
            return client.CreateMX(model, ptoken);
        }
        public int UpdateMX(CRM_COST_LKAXSMX model, string ptoken)
        {
            return client.UpdateMX(model, ptoken);
        }
        public CRM_COST_LKAXSMX[] ReadMXByTTID(CRM_COST_LKAXSMX model, string ptoken)
        {
            return client.ReadMXByTTID(model, ptoken);
        }
        public int DeleteMX(int LKAXSMXID, string ptoken)
        {
            return client.DeleteMX(LKAXSMXID, ptoken);
        }

    }
}
