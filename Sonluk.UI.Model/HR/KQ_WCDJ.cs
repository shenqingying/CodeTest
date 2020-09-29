using Sonluk.UI.Model.HR.KQ_WCDJService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.HR
{
    public class KQ_WCDJ
    {
        private WS_HR_KQ_WCDJSoapClient client = new WS_HR_KQ_WCDJSoapClient("WS_HR_KQ_WCDJSoap", AppConfig.Settings("RemoteAddress") + "HR/WS_HR_KQ_WCDJ.asmx");
        public MES_RETURN_UI INSERT(HR_KQ_WCDJ model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TID = mr.TID;
            return mrui;
        }
        public MES_RETURN_UI UPDATE(HR_KQ_WCDJ model, int LB, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, LB, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_KQ_WCDJ_SELECT SELECT(HR_KQ_WCDJ model, string ptoken)
        {
            return client.SELECT(model, ptoken);
        }
    }
}
