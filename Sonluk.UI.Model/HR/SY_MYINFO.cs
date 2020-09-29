using Sonluk.UI.Model.HR.SY_MYINFOService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.HR
{
    public class SY_MYINFO
    {
        private WS_HR_SY_MYINFOSoapClient client = new WS_HR_SY_MYINFOSoapClient("WS_HR_SY_MYINFOSoap", AppConfig.Settings("RemoteAddress") + "HR/WS_HR_SY_MYINFO.asmx");
        public MES_RETURN_UI JM_ISTRUE(string MYPW, int STAFFID, int LB, string ptoken)
        {
            MES_RETURN mr = client.JM_ISTRUE(MYPW, STAFFID, LB, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI INSERT(HR_SY_MYINFO model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TID = mr.TID;
            return mrui;
        }
        public HR_SY_MYINFO_SELECT SELECT_REPORT(HR_SY_MYINFO model, string ptoken)
        {
            return client.SELECT_REPORT(model, ptoken);
        }
        public MES_RETURN_UI UPDATE(HR_SY_MYINFO model, int LB, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, LB, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TID = mr.TID;
            return mrui;
        }
        public HR_SY_MYINFO_SELECT SELECT(HR_SY_MYINFO model, int LB, string ptoken)
        {
            return client.SELECT(model, LB, ptoken);
        }
    }
}
