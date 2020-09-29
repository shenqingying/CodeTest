using Sonluk.UI.Model.CRM.QYJS_MENUService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class QYJS_MENU
    {
        private QYJS_MENUSoapClient client = new QYJS_MENUSoapClient("QYJS_MENUSoap", AppConfig.Settings("RemoteAddress") + "CRM/QYJS_MENU.asmx");

        public int Create(CRM_QYJS_MENU model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_QYJS_MENU model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public int Delete(int CATALOGID, string ptoken)
        {
            return client.Delete(CATALOGID, ptoken);
        }
        public CRM_QYJS_MENU ReadbyID(int CATALOGID, string ptoken)
        {
            return client.ReadbyID(CATALOGID, ptoken);
        }
        public CRM_QYJS_MENU[] ReadTTbyParam(CRM_QYJS_MENU model, string ptoken)
        {
            return client.ReadTTbyParam(model, ptoken);
        }



    }
}
