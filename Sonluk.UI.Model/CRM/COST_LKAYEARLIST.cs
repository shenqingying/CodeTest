using Sonluk.UI.Model.CRM.COST_LKAYEARLISTService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_LKAYEARLIST
    {
        private COST_LKAYEARLISTSoapClient client = new COST_LKAYEARLISTSoapClient("COST_LKAYEARLISTSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_LKAYEARLIST.asmx");

        public int Create(CRM_COST_LKAYEARLIST model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_LKAYEARLIST model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_COST_LKAYEARLIST[] ReadByParam(CRM_COST_LKAYEARLIST model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int Delete(int LISTID, string ptoken)
        {
            return client.Delete(LISTID, ptoken);
        }
        public int UpdateByTTID(int LKAYEARTTID, string ptoken)
        {
            return client.UpdateByTTID(LKAYEARTTID, ptoken);
        }
        public int DeleteByTTID(int LKAYEARTTID, string ptoken)
        {
            return client.DeleteByTTID(LKAYEARTTID, ptoken);
        }
        public CRM_COST_LKAYEARLIST[] ReadListByKHID(int KHID, string YEAR, string ptoken)
        {
            return client.ReadListByKHID(KHID, YEAR, ptoken);
        }
    }
}
