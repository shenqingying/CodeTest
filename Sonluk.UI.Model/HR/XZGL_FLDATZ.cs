using Sonluk.UI.Model.HR.XZGL_FLDATZService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.HR
{
    public class XZGL_FLDATZ
    {
        private WS_HR_XZGL_FLDATZSoapClient client = new WS_HR_XZGL_FLDATZSoapClient("WS_HR_XZGL_FLDATZSoap", AppConfig.Settings("RemoteAddress") + "HR/WS_HR_XZGL_FLDATZ.asmx");
        public MES_RETURN_UI AUTOINSERT(HR_XZGL_FLDATZ model, string ptoken)
        {
            MES_RETURN mr = client.AUTOINSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_XZGL_FLDATZ_SELECT SELECT_REPORT(HR_XZGL_FLDATZ model, string ptoken)
        {
            return client.SELECT_REPORT(model, ptoken);
        }
        public MES_RETURN_UI DELETE(HR_XZGL_FLDATZ model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, 1, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI AUTO_ADD_TO_FFJLMX(HR_XZGL_FLDATZ model, string ptoken)
        {
            MES_RETURN mr = client.AUTO_ADD_TO_FFJLMX(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TID = mr.TID;
            return mrui;
        }
    }
}
