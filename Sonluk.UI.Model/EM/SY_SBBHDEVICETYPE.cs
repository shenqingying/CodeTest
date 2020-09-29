using Sonluk.UI.Model.EM.SY_SBBHDEVICETYPEService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.EM
{
    public class SY_SBBHDEVICETYPE
    {
        private SY_SBBHDEVICETYPESoapClient client = new SY_SBBHDEVICETYPESoapClient("SY_SBBHDEVICETYPESoap", AppConfig.Settings("RemoteAddress") + "EM/SY_SBBHDEVICETYPE.asmx");
        public MES_RETURN_UI Create(EM_SY_SBBHDEVICETYPE model, string ptoken)
        {
            MES_RETURN mr = client.Create(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public EM_SY_SBBHDEVICETYPELIST[] Read(EM_SY_SBBHDEVICETYPE model, string ptoken)
        {
            return client.Read(model, ptoken);
        }
        public MES_RETURN_UI Delete(EM_SY_SBBHDEVICETYPE model, string ptoken)
        {
            MES_RETURN mr = client.DELETE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
    }
}
