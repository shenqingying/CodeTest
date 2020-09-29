using Sonluk.UI.Model.HR.RY_BANKNOService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.HR
{
    public class RY_BANKNO
    {
        private WS_HR_RY_BANKNOSoapClient client = new WS_HR_RY_BANKNOSoapClient("WS_HR_RY_BANKNOSoap", AppConfig.Settings("RemoteAddress") + "HR/WS_HR_RY_BANKNO.asmx");
        public MES_RETURN_UI INSERT(HR_RY_BANKNO model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI UPDATE(HR_RY_BANKNO model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, 2, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI DELETE(HR_RY_BANKNO model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, 1, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_RY_BANKNO_SELECT SELECT(HR_RY_BANKNO model, string ptoken)
        {
            return client.SELECT(model, ptoken);
        }
    }
}
