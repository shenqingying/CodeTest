using Sonluk.UI.Model.MES.PMM_SYSService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class PMM_SYS
    {
        private PMM_SYSSoapClient client = new PMM_SYSSoapClient("PMM_SYSSoap", AppConfig.Settings("RemoteAddress") + "MES/PMM_SYS.asmx");

        public MES_PMM_SYS SELECT(MES_PMM_SYS model, string token)
        {
            return client.SELECT(model, token);
        }

        public MES_RETURN_UI UPDATE(MES_PMM_SYS model, string token)
        {
            MES_RETURN mr = client.UPDATE(model, token);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
    }
}
