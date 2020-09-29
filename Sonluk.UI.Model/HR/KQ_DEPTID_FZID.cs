using Sonluk.UI.Model.HR.KQ_DEPTID_FZIDService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.HR
{
    public class KQ_DEPTID_FZID
    {
        private WS_HR_KQ_DEPTID_FZIDSoapClient client = new WS_HR_KQ_DEPTID_FZIDSoapClient("WS_HR_KQ_DEPTID_FZIDSoap", AppConfig.Settings("RemoteAddress") + "HR/WS_HR_KQ_DEPTID_FZID.asmx");
        public MES_RETURN_UI UPDATE(HR_KQ_DEPTID_FZID model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_KQ_DEPTID_FZID_SELECT SELECT(HR_KQ_DEPTID_FZID model, int LB, string ptoken)
        {
            return client.SELECT(model, LB, ptoken);
        }
    }
}
