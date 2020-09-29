using Sonluk.UI.Model.HR.KQ_BZService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.HR
{
    public class KQ_BZ
    {
        private WS_HR_KQ_BZSoapClient client = new WS_HR_KQ_BZSoapClient("WS_HR_KQ_BZSoap", AppConfig.Settings("RemoteAddress") + "HR/WS_HR_KQ_BZ.asmx");
        public MES_RETURN_UI INSERT(HR_KQ_BZ model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TID = mr.TID;
            return mrui;
        }
        public MES_RETURN_UI UPDATE(HR_KQ_BZ model, int LB, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, LB, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_KQ_BZ_SELECT SELECT(HR_KQ_BZ model, string ptoken)
        {
            return client.SELECT(model, ptoken);
        }
    }
}
