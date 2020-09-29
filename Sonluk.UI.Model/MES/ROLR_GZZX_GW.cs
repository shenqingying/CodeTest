using Sonluk.UI.Model.MES.ROLR_GZZX_GWService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class ROLR_GZZX_GW
    {
        private ROLR_GZZX_GWSoapClient client = new ROLR_GZZX_GWSoapClient("ROLR_GZZX_GWSoap", AppConfig.Settings("RemoteAddress") + "MES/ROLR_GZZX_GW.asmx");

        public MES_RETURN_UI INSERT(MES_ROLR_GZZX_GW[] model, string ptoken)
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
         

        public MES_ROLR_GZZX_GW_LIST SELECT(int ROLEID, string ptoken)
        {
            return client.SELECT(ROLEID, ptoken);
        }
    }
}
