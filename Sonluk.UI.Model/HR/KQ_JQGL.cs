using Sonluk.UI.Model.HR.KQ_JQGLService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.HR
{
    public class KQ_JQGL
    {
        private WS_HR_KQ_JQGLSoapClient client = new WS_HR_KQ_JQGLSoapClient("WS_HR_KQ_JQGLSoap", AppConfig.Settings("RemoteAddress") + "HR/WS_HR_KQ_JQGL.asmx");
        public MES_RETURN_UI INSERT(HR_KQ_JQGL model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TID = mr.TID;
            return mrui;
        }
        public MES_RETURN_UI UPDATE(HR_KQ_JQGL model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, 2, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI DELETE(HR_KQ_JQGL model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, 1, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_KQ_JQGL_SELECT SELECT(HR_KQ_JQGL model, string ptoken)
        {
            return client.SELECT(model, ptoken);
        }
    }
}
