using Sonluk.UI.Model.EM.SY_DEVICE_CONTRACTService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.EM
{
    public class SY_DEVICE_CONTRACT
    {
        private SY_DEVICE_CONTRACTSoapClient client = new SY_DEVICE_CONTRACTSoapClient("SY_DEVICE_CONTRACTSoap", AppConfig.Settings("RemoteAddress") + "EM/SY_DEVICE_CONTRACT.asmx");
        public MES_RETURN_UI Create(EM_SY_DEVICE_CONTRACT model, string ptoken)
        {
            MES_RETURN mr = client.Create(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI Delete(EM_SY_DEVICE_CONTRACT model, string ptoken)
        {
            MES_RETURN mr = client.DELETE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public EM_SY_DEVICE_CONTRACT[] Read(EM_SY_DEVICE_CONTRACT model, string ptoken)
        {
            return client.Read(model, ptoken);
        }

    }
}
