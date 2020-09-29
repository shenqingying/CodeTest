using Sonluk.UI.Model.MES.ROLE_RY_ASSEMBLEService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class ROLE_RY_ASSEMBLE
    {
        private ROLE_RY_ASSEMBLESoapClient client = new ROLE_RY_ASSEMBLESoapClient("ROLE_RY_ASSEMBLESoap", AppConfig.Settings("RemoteAddress") + "MES/ROLE_RY_ASSEMBLE.asmx");
        public MES_RETURN_UI INSERT(MES_ROLE_RY_ASSEMBLE[] model, string ptoken)
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
