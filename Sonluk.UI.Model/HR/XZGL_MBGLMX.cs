using Sonluk.UI.Model.HR.XZGL_MBGLMXService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.HR
{
    public class XZGL_MBGLMX
    {
        private WS_HR_XZGL_MBGLMXSoapClient client = new WS_HR_XZGL_MBGLMXSoapClient("WS_HR_XZGL_MBGLMXSoap", AppConfig.Settings("RemoteAddress") + "HR/WS_HR_XZGL_MBGLMX.asmx");
        public MES_RETURN_UI INSERT(HR_XZGL_MBGLMX model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI UPDATE(HR_XZGL_MBGLMX model, int LB, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, LB, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_XZGL_MBGLMX_SELECT SELECT(HR_XZGL_MBGLMX model, string ptoken)
        {
            return client.SELECT(model, ptoken);
        }
        public HR_XZGL_MBGLMX_SELECT SELECT_LAY(HR_XZGL_MBGLMX model, string ptoken)
        {
            return client.SELECT_LAY(model, ptoken);
        }
    }
}
