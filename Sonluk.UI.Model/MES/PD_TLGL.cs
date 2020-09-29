using Sonluk.UI.Model.MES.PD_TLGLService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class PD_TLGL
    {
        private PD_TLGLSoapClient client = new PD_TLGLSoapClient("PD_TLGLSoap", AppConfig.Settings("RemoteAddress") + "MES/PD_TLGL.asmx");
        public MES_RETURN_UI DELETE(MES_PD_TL_DELETE_IN model, string ptoken)
        {
            MES_RETURN mr = client.DELETE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public MES_PD_TL_SELECT SELECT(MES_PD_TL model, string ptoken)
        {
            return client.SELECT(model, ptoken);
        }

        public MES_RETURN_UI UPDATE_TLTMTH(MES_PD_TL_UPDATE_TLTMTH_IN model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE_TLTMTH(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI INSERT(MES_PD_TL model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_PD_TL_SELECT_REPORT SELECT_REPORT(MES_PD_TL_IN_SELECT_REPORT model, string ptoken)
        {
            return client.SELECT_REPORT(model, ptoken);
        }
    }
}
