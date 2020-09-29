using Sonluk.UI.Model.MES.SY_GZZXService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class SY_GZZX
    {
        private SY_GZZXSoapClient client = new SY_GZZXSoapClient("SY_GZZXSoap", AppConfig.Settings("RemoteAddress") + "MES/SY_GZZX.asmx");

        public MES_RETURN_UI INSERT(MES_SY_GZZX model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public MES_RETURN_UI DELETE(MES_SY_GZZX model, string ptoken)
        {
            MES_RETURN mr = client.DELETE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
            //return client.DELETE(ID, ptoken);
        }

        public MES_RETURN_UI UPDATE(MES_SY_GZZX model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
            //return client.UPDATE(model, ptoken);
        }

        public MES_SY_GZZX[] SELECT(MES_SY_GZZX model, string ptoken)
        {
            model.ISACTION = 0;
            return client.SELECT(model, ptoken);
        }

        public MES_SY_GZZX[] SELECT_USER(MES_SY_GZZX model, string ptoken)
        {
            model.ISACTION = 1;
            return client.SELECT(model, ptoken);
        }

        public MES_SY_GZZX[] SELECT_BY_ROLE(MES_SY_GZZX model, string ptoken)
        {
            return client.SELECT_BY_ROLE(model, ptoken);
        }

        public MES_SY_GZZX_GW_LIST SELECT_GZZX_GW(MES_SY_GZZX model, string ptoken)
        {
            return client.SELECT_GZZX_GW(model, ptoken);
        }
        public MES_SY_GZZX[] SELECT_LB(MES_SY_GZZX model, string ptoken)
        {
            model.ISACTION = 0;
            return client.SELECT_LB(model, ptoken);
        }
    }
}
