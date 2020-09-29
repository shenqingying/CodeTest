using Sonluk.UI.Model.HR.SY_DUTYService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.HR
{
    public class SY_DUTY
    {
        private SY_DUTYSoapClient client = new SY_DUTYSoapClient("SY_DUTYSoap", AppConfig.Settings("RemoteAddress") + "HR/SY_DUTY.asmx");
        public MES_RETURN_UI INSERT(HR_SY_DUTY model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_SY_DUTY_SELECT SELECT(HR_SY_DUTY model, string ptoken)
        {
            return client.SELECT(model,ptoken);
        }
        public MES_RETURN_UI UPDATE(HR_SY_DUTY model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI DELETE(HR_SY_DUTY model, string ptoken)
        {
            MES_RETURN mr = client.DELETE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
    }
}
