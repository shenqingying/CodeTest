using Sonluk.UI.Model.CRM.QYJS_FILEService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class QYJS_FILE
    {
        private QYJS_FILESoapClient client = new QYJS_FILESoapClient("QYJS_FILESoap", AppConfig.Settings("RemoteAddress") + "CRM/QYJS_FILE.asmx");

        public int Create(CRM_QYJS_FILE model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_QYJS_FILE model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_QYJS_FILE[] ReadByParam(CRM_QYJS_FILE model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int Delete(int ID, string ptoken)
        {
            return client.Delete(ID, ptoken);
        }


    }
}
