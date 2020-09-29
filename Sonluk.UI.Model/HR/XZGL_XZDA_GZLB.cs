using Sonluk.UI.Model.HR.XZGL_XZDA_GZLBService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.HR
{
    public class XZGL_XZDA_GZLB
    {
        private WS_HR_XZGL_XZDA_GZLBSoapClient client = new WS_HR_XZGL_XZDA_GZLBSoapClient("WS_HR_XZGL_XZDA_GZLBSoap", AppConfig.Settings("RemoteAddress") + "HR/WS_HR_XZGL_XZDA_GZLB.asmx");
        public MES_RETURN_UI INSERT(HR_XZGL_XZDA_GZLB model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI UPDATE(HR_XZGL_XZDA_GZLB model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, 2, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI DELETE(HR_XZGL_XZDA_GZLB model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, 1, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_XZGL_XZDA_GZLB_SELECT SELECT(HR_XZGL_XZDA_GZLB model, string ptoken)
        {
            return client.SELECT(model, ptoken);
        }
    }
}
