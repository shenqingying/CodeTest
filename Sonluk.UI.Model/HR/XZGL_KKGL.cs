using Sonluk.UI.Model.HR.XZGL_KKGLService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.HR
{
    public class XZGL_KKGL
    {
        private WS_HR_XZGL_KKGLSoapClient client = new WS_HR_XZGL_KKGLSoapClient("WS_HR_XZGL_KKGLSoap", AppConfig.Settings("RemoteAddress") + "HR/WS_HR_XZGL_KKGL.asmx");
        public MES_RETURN_UI INSERT(HR_XZGL_KKGL model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TID = mr.TID;
            return mrui;
        }
        public MES_RETURN_UI AUTOINSERT(HR_XZGL_KKGL model, string ptoken)
        {
            MES_RETURN mr = client.AUTOINSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TID = mr.TID;
            return mrui;
        }
        public MES_RETURN_UI UPDATE(HR_XZGL_KKGL model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, 2, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI DELETE(HR_XZGL_KKGL model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, 1, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_XZGL_KKGL_SELECT SELECT(HR_XZGL_KKGL model, string ptoken)
        {
            return client.SELECT(model, ptoken);
        }
    }
}
