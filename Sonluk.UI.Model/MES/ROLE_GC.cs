using Sonluk.UI.Model.MES.ROLE_GCService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class ROLE_GC
    {
        private ROLE_GCSoapClient client = new ROLE_GCSoapClient("ROLE_GCSoap", AppConfig.Settings("RemoteAddress") + "MES/ROLE_GC.asmx");
        public MES_RETURN_UI INSERT(MES_ROLE_GC[] model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI DELETE(int STAFFID, string ptoken)
        {
            MES_RETURN mr = client.DELETE(STAFFID, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
    }
}
