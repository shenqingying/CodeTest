using Sonluk.UI.Model.MES.ZS_SY_JLService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class ZS_SY_JL
    {
        private WS_MES_ZS_SY_JLSoapClient client = new WS_MES_ZS_SY_JLSoapClient("WS_MES_ZS_SY_JLSoap", AppConfig.Settings("RemoteAddress") + "MES/WS_MES_ZS_SY_JL.asmx");
        public MES_RETURN_UI INSERT(MES_ZS_SY_JL model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI UPDATE(MES_ZS_SY_JL model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI INSERT_MX(MES_ZS_SY_JL_MX model, string ptoken)
        {
            MES_RETURN mr = client.INSERT_MX(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TID = mr.TID;
            return mrui;
        }
        public MES_ZS_SY_JL_MX_SELECT SELECT_MX(MES_ZS_SY_JL_MX model, string ptoken)
        {
            return client.SELECT_MX(model, ptoken);
        }
        public MES_RETURN_UI INSERT_QJQXJL(MES_ZS_SY_JL_QJQXJL model, MES_ZS_SY_JL_QJQXJLMX[] model2, string ptoken)
        {
            MES_RETURN mr = client.INSERT_QJQXJL(model, model2, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_ZS_SY_JL_SELECT SELECT_QJQXJL(MES_ZS_SY_JL_QJQXJL model, string ptoken)
        {
            return client.SELECT_QJQXJL(model, ptoken);
        }
        public MES_RETURN_UI UPDATE_QJQXJL(MES_ZS_SY_JL_QJQXJL model, MES_ZS_SY_JL_QJQXJLMX[] model2, string ptoken)
        {
            MES_RETURN mr = client.UPDATE_QJQXJL(model, model2, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
    }
}
