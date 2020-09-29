using Sonluk.UI.Model.MES.ZS_QJ_QJJLService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class ZS_QJ_QJJL
    {
        private WS_MES_ZS_QJ_QJJLSoapClient client = new WS_MES_ZS_QJ_QJJLSoapClient("WS_MES_ZS_QJ_QJJLSoap", AppConfig.Settings("RemoteAddress") + "MES/WS_MES_ZS_QJ_QJJL.asmx");
        public MES_RETURN_UI INSERT_QJSB(MES_ZS_QJ_QJSB model, string ptoken)
        {
            MES_RETURN mr = client.INSERT_QJSB(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_ZS_QJ_QJSB_SELECT SELECT_QJSB(MES_ZS_QJ_QJSB model, string ptoken)
        {
            return client.SELECT_QJSB(model, ptoken);
        }
        public MES_RETURN_UI INSERT_ERRORJL(MES_ZS_QJ_ERRORJL model, string ptoken)
        {
            MES_RETURN mr = client.INSERT_ERRORJL(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_ZS_QJ_ERRORJL_SELECT SELECT_ERRORJL(MES_ZS_QJ_ERRORJL model, string ptoken)
        {
            return client.SELECT_ERRORJL(model, ptoken);
        }
    }
}
