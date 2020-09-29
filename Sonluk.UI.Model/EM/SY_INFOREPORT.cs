using Sonluk.UI.Model.EM.SY_INFOREPORTService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.EM
{
    public class SY_INFOREPORT
    {
        private SY_INFOREPORTSoapClient client = new SY_INFOREPORTSoapClient("SY_INFOREPORTSoap", AppConfig.Settings("RemoteAddress") + "EM/SY_INFOREPORT.asmx");
        public MES_RETURN_UI Create(EM_SY_INFOREPORT model, string ptoken)
        {
            MES_RETURN mr = client.Create(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public EM_SY_INFOREPORT[] Read(EM_SY_INFOREPORTList model, string ptoken)
        {
            return client.Read(model, ptoken);
        }
    }
}
