using Sonluk.UI.Model.HR.KQ_BZ_BDIDService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.HR
{
    public class KQ_BZ_BDID
    {
        private WS_HR_KQ_BZ_BDIDSoapClient client = new WS_HR_KQ_BZ_BDIDSoapClient("WS_HR_KQ_BZ_BDIDSoap", AppConfig.Settings("RemoteAddress") + "HR/WS_HR_KQ_BZ_BDID.asmx");
        public MES_RETURN_UI INSERT(HR_KQ_BZ_BDID model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TID = mr.TID;
            return mrui;
        }
        public MES_RETURN_UI UPDATE(HR_KQ_BZ_BDID model, int LB, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, LB, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_KQ_BZ_BDID_SELECT SELECT(HR_KQ_BZ_BDID model, string ptoken)
        {
            return client.SELECT(model, ptoken);
        }
    }
}
