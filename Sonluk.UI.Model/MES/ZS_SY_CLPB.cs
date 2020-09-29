using Sonluk.UI.Model.MES.ZS_SY_CLPBService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class ZS_SY_CLPB
    {
        private WS_MES_ZS_SY_CLPBSoapClient client = new WS_MES_ZS_SY_CLPBSoapClient("WS_MES_ZS_SY_CLPBSoap", AppConfig.Settings("RemoteAddress") + "MES/WS_MES_ZS_SY_CLPB.asmx");
        public MES_RETURN_UI INSERT(MES_ZS_SY_CLPB model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_ZS_SY_CLPB_SELECT SELECT(MES_ZS_SY_CLPB model, string ptoken)
        {
            return client.SELECT(model, ptoken);
        }
        public MES_RETURN_UI UPDATE(MES_ZS_SY_CLPB model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI INSERT_WL(MES_ZS_SY_CLPB_WL model, string ptoken)
        {
            MES_RETURN mr = client.INSERT_WL(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_ZS_SY_CLPB_WL_SELECT SELECT_WL(MES_ZS_SY_CLPB_WL model, string ptoken)
        {
            return client.SELECT_WL(model, ptoken);
        }
        public MES_RETURN_UI UPDATE_WL(MES_ZS_SY_CLPB_WL model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE_WL(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
    }
}
