using Sonluk.UI.Model.EM.SY_STAFFIDBINDPBService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.EM
{
    public class SY_STAFFIDBINDPB
    {
        private SY_STAFFIDBINDPBSoapClient client = new SY_STAFFIDBINDPBSoapClient("SY_STAFFIDBINDPBSoap", AppConfig.Settings("RemoteAddress") + "EM/SY_STAFFIDBINDPB.asmx");
        public MES_RETURN_UI Create(EM_SY_STAFFIDBINDPB model, string ptoken)
        {
            MES_RETURN mr = client.Create(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI Update(EM_SY_STAFFIDBINDPB model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public EM_SY_STAFFIDBINDPB[] Read(EM_SY_STAFFIDBINDPB model, string ptoken)
        {
            return client.Read(model, ptoken);
        }
        public MES_RETURN_UI Delete(EM_SY_STAFFIDBINDPB model, string ptoken)
        {
            MES_RETURN mr = client.DELETE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
    }
}
