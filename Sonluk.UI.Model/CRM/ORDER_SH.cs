using Sonluk.UI.Model.CRM.ORDER_SHService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class ORDER_SH
    {
        private ORDER_SHSoapClient client = new ORDER_SHSoapClient("ORDER_SHSoap", AppConfig.Settings("RemoteAddress") + "CRM/ORDER_SH.asmx");
        public MES_RETURN_UI Modify(List<CRM_ORDER_SH> model, string token)
        {
            RETURN_MSG mr = client.Modify(model.ToArray(), token);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public CRM_ORDER_SH[] ReadByParam(CRM_ORDER_SH model, string token)
        {
            return client.ReadByParam(model,  token);
        }
        public CRM_ORDER_SH[] Report(CRM_ORDER_SH model, string token)
        {
            return client.Report(model, token);
        }
    }
}
