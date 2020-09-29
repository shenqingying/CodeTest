using Sonluk.UI.Model.HR.ROLE_DEPTService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.HR
{
    public class ROLE_DEPT
    {
        private WS_HR_ROLE_DEPTSoapClient client = new WS_HR_ROLE_DEPTSoapClient("WS_HR_ROLE_DEPTSoap", AppConfig.Settings("RemoteAddress") + "HR/WS_HR_ROLE_DEPT.asmx");
        public MES_RETURN_UI INSERT(HR_ROLE_DEPT model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TID = mr.TID;
            return mrui;
        }
        public MES_RETURN_UI UPDATE(HR_ROLE_DEPT model, int LB, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, LB, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_ROLE_DEPT_SELECT SELECT(HR_ROLE_DEPT model, string ptoken)
        {
            return client.SELECT(model, ptoken);
        }
    }
}
