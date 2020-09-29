using Sonluk.UI.Model.HR.KQ_JQGLMXService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.HR
{
    public class KQ_JQGLMX
    {
        private WS_HR_KQ_JQGLMXSoapClient client = new WS_HR_KQ_JQGLMXSoapClient("WS_HR_KQ_JQGLMXSoap", AppConfig.Settings("RemoteAddress") + "HR/WS_HR_KQ_JQGLMX.asmx");
        public MES_RETURN_UI INSERT(HR_KQ_JQGLMX model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI UPDATE(HR_KQ_JQGLMX model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, 2, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI DELETE(HR_KQ_JQGLMX model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, 1, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_KQ_JQGLMX_SELECT SELECT(HR_KQ_JQGLMX model, string ptoken)
        {
            return client.SELECT(model, ptoken);
        }
        public HR_KQ_JQGLMX_SELECT SELECT_REPORT(HR_KQ_JQGLMX model, int LB, string ptoken)
        {
            return client.SELECT_REPORT(model, LB, ptoken);
        }
        public MES_RETURN_UI AUTO_ADD_TO_FFJLMX(HR_KQ_JQGLMX model, string ptoken)
        {
            MES_RETURN mr = client.AUTO_ADD_TO_FFJLMX(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
    }
}
