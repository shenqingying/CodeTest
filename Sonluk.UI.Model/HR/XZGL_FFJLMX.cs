using Sonluk.UI.Model.HR.XZGL_FFJLMXService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.HR
{
    public class XZGL_FFJLMX
    {
        private WS_HR_XZGL_FFJLMXSoapClient client = new WS_HR_XZGL_FFJLMXSoapClient("WS_HR_XZGL_FFJLMXSoap", AppConfig.Settings("RemoteAddress") + "HR/WS_HR_XZGL_FFJLMX.asmx");
        public MES_RETURN_UI INSERT(HR_XZGL_FFJLMX model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TID = mr.TID;
            return mrui;
        }
        public MES_RETURN_UI UPDATE(HR_XZGL_FFJLMX model, int LB, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, LB, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TID = mr.TID;
            return mrui;
        }
        public HR_XZGL_FFJLMX_SELECT SELECT(HR_XZGL_FFJLMX model, int LB, string ptoken)
        {
            return client.SELECT(model, LB, ptoken);
        }
        public MES_RETURN_UI FORMULA_JS(HR_XZGL_FFJLMX model, int LB, string ptoken)
        {
            MES_RETURN mr = client.FORMULA_JS(model, LB, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TID = mr.TID;
            return mrui;
        }
        public MES_RETURN_UI FORMULA_JS_TZ(HR_XZGL_FFJLMX model, int LB, string ptoken)
        {
            MES_RETURN mr = client.FORMULA_JS_TZ(model, LB, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TID = mr.TID;
            return mrui;
        }
        public MES_RETURN_UI AUTO_ADD_TO_FFJLMX_OTHER(HR_XZGL_FFJLMX model, int LB, string ptoken)
        {
            MES_RETURN mr = client.AUTO_ADD_TO_FFJLMX_OTHER(model, LB, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TID = mr.TID;
            return mrui;
        }
        public HR_XZGL_FFJLMX_SELECT SELECT_GSREPORT(HR_XZGL_FFJLMX model, string ptoken)
        {
            return client.SELECT_GSREPORT(model, ptoken);
        }
        public HR_XZGL_FFJLMX_SELECT SELECT_FFMXREPORT(HR_XZGL_FFJLMX model, string ptoken)
        {
            return client.SELECT_FFMXREPORT(model, ptoken);
        }
        public HR_XZGL_FFJLMX_SELECT SELECT_GZXJSDREPORT(HR_XZGL_FFJLMX model, string ptoken)
        {
            return client.SELECT_GZXJSDREPORT(model, ptoken);
        }
        public HR_XZGL_FFJLMX_SELECT SELECT_FFMXGZDREPORT(HR_XZGL_FFJLMX model, string ptoken)
        {
            return client.SELECT_FFMXGZDREPORT(model, ptoken);
        }
        public HR_XZGL_FFJLMX_SELECT SELECT_FFMXGZHZREPORT(HR_XZGL_FFJLMX model, string ptoken)
        {
            return client.SELECT_FFMXGZHZREPORT(model, ptoken);
        }
        public HR_XZGL_FFJLMX_SELECT SELECT_FFMXTXFREPORT(HR_XZGL_FFJLMX model, int LB, string ptoken)
        {
            return client.SELECT_FFMXTXFREPORT(model, LB, ptoken);
        }
        public HR_XZGL_FFJLMX_SELECT SELECT_GUOSHUIREPORT(HR_XZGL_FFJLMX model, string ptoken)
        {
            return client.SELECT_GUOSHUIREPORT(model, ptoken);
        }
    }
}
