using Sonluk.UI.Model.HR.KQ_PBFZService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.HR
{
    public class KQ_PBFZ
    {
        private WS_HR_KQ_PBFZSoapClient client = new WS_HR_KQ_PBFZSoapClient("WS_HR_KQ_PBFZSoap", AppConfig.Settings("RemoteAddress") + "HR/WS_HR_KQ_PBFZ.asmx");
        public MES_RETURN_UI INSERT(HR_KQ_PBFZ model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TID = mr.TID;
            return mrui;
        }
        public MES_RETURN_UI UPDATE(HR_KQ_PBFZ model, int LB, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, LB, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_KQ_PBFZ_SELECT SELECT(HR_KQ_PBFZ model, string ptoken)
        {
            return client.SELECT(model, ptoken);
        }
    }
}
