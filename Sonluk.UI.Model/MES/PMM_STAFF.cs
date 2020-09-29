using Sonluk.UI.Model.MES.PMM_STAFFService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class PMM_STAFF
    {
        private PMM_STAFFSoapClient client = new PMM_STAFFSoapClient("PMM_STAFFSoap", AppConfig.Settings("RemoteAddress") + "MES/PMM_STAFF.asmx");

        public MES_PMM_STAFF_SELECT SELECT(MES_PMM_STAFF model, string token)
        {
            return client.SELECT(model, token);
        }

        public MES_RETURN_UI COVER(MES_PMM_STAFF model, string token)
        {
            MES_RETURN mr = client.COVER(model, token);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public MES_RETURN_UI DELETE(MES_PMM_STAFF model, string token)
        {
            MES_RETURN mr = client.DELETE(model, token);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
    }
}
