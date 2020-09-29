using Sonluk.UI.Model.EM.SY_SBBHMANUALService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.EM
{
    public class SY_SBBHMANUAL
    {
        private SY_SBBHMANUALSoapClient client = new SY_SBBHMANUALSoapClient("SY_SBBHMANUALSoap", AppConfig.Settings("RemoteAddress") + "EM/SY_SBBHMANUAL.asmx");
        public MES_RETURN_UI Create(EM_SY_SBBHMANUAL model, string ptoken)
        {
            MES_RETURN mr = client.Create(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI Update(EM_SY_SBBHMANUAL model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public EM_SY_SBBHMANUAL[] Read(EM_SY_SBBHMANUAL model, string ptoken)
        {
            return client.Read(model, ptoken);
        }
        public MES_RETURN_UI Delete(EM_SY_SBBHMANUAL model, string ptoken)
        {
            MES_RETURN mr = client.DELETE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
    }
}
