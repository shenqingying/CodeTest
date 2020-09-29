using Sonluk.UI.Model.CRM.COST_LKAEachYEARService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_LKAEachYEAR
    {
        private COST_LKAEachYEARSoapClient client = new COST_LKAEachYEARSoapClient("COST_LKAEachYEARSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_LKAEachYEAR.asmx");

        public int Create(CRM_COST_LKAEachYEAR model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int UpdateByTTID(int LKAYEARTTID, string ptoken)
        {
            return client.UpdateByTTID(LKAYEARTTID, ptoken);
        }
        public CRM_COST_LKAEachYEAR[] ReadByParam(CRM_COST_LKAEachYEAR model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int DeleteByTTID(int LKAYEARTTID, string ptoken)
        {
            return client.DeleteByTTID(LKAYEARTTID, ptoken);
        }


    }
}
