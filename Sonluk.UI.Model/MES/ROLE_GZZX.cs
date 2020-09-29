using Sonluk.UI.Model.MES.ROLE_GZZXService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class ROLE_GZZX
    {
        private ROLE_GZZXSoapClient client = new ROLE_GZZXSoapClient("ROLE_GZZXSoap", AppConfig.Settings("RemoteAddress") + "MES/ROLE_GZZX.asmx");
        public MES_RETURN_UI INSERT(MES_SY_GZZX_LAY[] model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
            //return client.INSERT(model, ptoken);
        }
        public MES_RETURN_UI DELETE(int ROLEID, string ptoken)
        {
            MES_RETURN mr = client.DELETE(ROLEID, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
            //return client.DELETE(ROLEID, ptoken);
        }
        public MES_ROLE_GZZX_SELECT_BYROLEID SELECT_BYROLEID(int ROLEID, string ptoken)
        {
            return client.SELECT_BYROLEID(ROLEID, ptoken);
        }
    }
}
