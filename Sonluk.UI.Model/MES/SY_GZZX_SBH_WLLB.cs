using Sonluk.UI.Model.MES.SY_GZZX_SBH_WLLBService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class SY_GZZX_SBH_WLLB
    {
        private SY_GZZX_SBH_WLLBSoapClient client = new SY_GZZX_SBH_WLLBSoapClient("SY_GZZX_SBH_WLLBSoap", AppConfig.Settings("RemoteAddress") + "MES/SY_GZZX_SBH_WLLB.asmx");

        public MES_RETURN_UI INSERT(MES_SY_GZZX_SBH_WLLB model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI INSERT_LIST(MES_SY_GZZX_SBH_WLLB[] model, string ptoken)
        {
            MES_RETURN mr = client.INSERT_LIST(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI DELETE(MES_SY_GZZX_SBH_WLLB model, string ptoken)
        {
            MES_RETURN mr = client.DELETE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_SY_GZZX_SBH_WLLB_SELECT SELECT(MES_SY_GZZX_SBH_WLLB model, string ptoken)
        {
            return client.SELECT(model, ptoken);
        }
        public MES_SY_GZZX_SBH_WLLB_SELECT SELECT_LAY(string SBBH, string ptoken)
        {
            return client.SELECT_LAY(SBBH, ptoken);
        }
    }
}
