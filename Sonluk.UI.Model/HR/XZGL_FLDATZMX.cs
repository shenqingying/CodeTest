using Sonluk.UI.Model.HR.XZGL_FLDATZMXService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.HR
{
    public class XZGL_FLDATZMX
    {
        private WS_HR_XZGL_FLDATZMXSoapClient client = new WS_HR_XZGL_FLDATZMXSoapClient("WS_HR_XZGL_FLDATZMXSoap", AppConfig.Settings("RemoteAddress") + "HR/WS_HR_XZGL_FLDATZMX.asmx");
        public HR_XZGL_FLDATZMX_SELECT_REPORT SELECT_REPORT(HR_XZGL_FLDATZMX model, string ptoken)
        {
            return client.SELECT_REPORT(model, ptoken);
        }
        public HR_XZGL_FLDATZMX_SELECT SELECT(HR_XZGL_FLDATZMX model, string ptoken)
        {
            return client.SELECT(model, ptoken);
        }
        public MES_RETURN_UI UPDATE(HR_XZGL_FLDATZMX model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, 2, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
    }
}
