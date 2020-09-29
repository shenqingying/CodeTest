using Sonluk.UI.Model.HR.XZGL_MBGLService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.HR
{
    public class XZGL_MBGL
    {
        private WS_HR_XZGL_MBGLSoapClient client = new WS_HR_XZGL_MBGLSoapClient("WS_HR_XZGL_MBGLSoap", AppConfig.Settings("RemoteAddress") + "HR/WS_HR_XZGL_MBGL.asmx");
        public MES_RETURN_UI INSERT(HR_XZGL_MBGL model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TID = mr.TID;
            return mrui;
        }
        public MES_RETURN_UI UPDATE(HR_XZGL_MBGL model, int LB, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, LB, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_XZGL_MBGL_SELECT SELECT(HR_XZGL_MBGL model, string ptoken)
        {
            return client.SELECT(model, ptoken);
        }
        public MES_RETURN_UI SELECT_YYCOUNT(HR_XZGL_MBGL model, string ptoken)
        {
            MES_RETURN mr = client.SELECT_YYCOUNT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TID = mr.TID;
            return mrui;
        }
    }
}
