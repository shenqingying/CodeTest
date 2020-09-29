using Sonluk.UI.Model.HR.KQ_RYID_BZIDService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.HR
{
    public class KQ_RYID_BZID
    {
        private WS_HR_KQ_RYID_BZIDSoapClient client = new WS_HR_KQ_RYID_BZIDSoapClient("WS_HR_KQ_RYID_BZIDSoap", AppConfig.Settings("RemoteAddress") + "HR/WS_HR_KQ_RYID_BZID.asmx");
        public MES_RETURN_UI UPDATE(HR_KQ_RYID_BZID model, int LB, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, LB, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_KQ_RYID_BZID_SELECT SELECT(HR_KQ_RYID_BZID model, int LB, string ptoken)
        {
            return client.SELECT(model, LB, ptoken);
        }
    }
}
