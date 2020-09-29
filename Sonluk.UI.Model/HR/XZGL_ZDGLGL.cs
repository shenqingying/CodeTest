using Sonluk.UI.Model.HR.XZGL_ZDGLGLService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.HR
{
    public class XZGL_ZDGLGL
    {
        private WS_HR_XZGL_ZDGLGLSoapClient client = new WS_HR_XZGL_ZDGLGLSoapClient("WS_HR_XZGL_ZDGLGLSoap", AppConfig.Settings("RemoteAddress") + "HR/WS_HR_XZGL_ZDGLGL.asmx");
        public MES_RETURN_UI INSERT(HR_XZGL_ZDGLGL model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TID = mr.TID;
            return mrui;
        }
        public MES_RETURN_UI UPDATE(HR_XZGL_ZDGLGL model, int LB, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, LB, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_XZGL_ZDGLGL_SELECT SELECT(HR_XZGL_ZDGLGL model, string ptoken)
        {
            return client.SELECT(model, ptoken);
        }
        public MES_RETURN_UI FORMULA_VERIFY_GLZD(string FORMULA, int LB, string ptoken)
        {
            MES_RETURN mr = client.FORMULA_VERIFY_GLZD(FORMULA, LB, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
    }
}
