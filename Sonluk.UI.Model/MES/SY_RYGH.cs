using Sonluk.UI.Model.MES.SY_RYGHService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class SY_RYGH
    {
        private WS_MES_SY_RYGHSoapClient client = new WS_MES_SY_RYGHSoapClient("WS_MES_SY_RYGHSoap", AppConfig.Settings("RemoteAddress") + "MES/WS_MES_SY_RYGH.asmx");
        public MES_SY_RYGH_SELECT SELECT(MES_SY_RYGH model, string ptoken)
        {
            return client.SELECT(model, ptoken);
        }
        public MES_RETURN_UI INSERT(MES_SY_RYGH model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI UPDATE(MES_SY_RYGH model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_SY_RYGH_GS_SELECT SELECT_GS(MES_SY_RYGH_GS model, string ptoken)
        {
            return client.SELECT_GS(model, ptoken);
        }
    }
}
