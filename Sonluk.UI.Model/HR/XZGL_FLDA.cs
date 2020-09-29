using Sonluk.UI.Model.HR.XZGL_FLDAService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.HR
{
    public class XZGL_FLDA
    {
        private WS_HR_XZGL_FLDASoapClient client = new WS_HR_XZGL_FLDASoapClient("WS_HR_XZGL_FLDASoap", AppConfig.Settings("RemoteAddress") + "HR/WS_HR_XZGL_FLDA.asmx");
        public MES_RETURN_UI INSERT(HR_XZGL_FLDA model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI UPDATE(HR_XZGL_FLDA model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, 2, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI DELETE(HR_XZGL_FLDA model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, 1, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI UPDATE_LB(HR_XZGL_FLDA model, int LB, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, LB, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_XZGL_FLDA_SELECT SELECT(HR_XZGL_FLDA model, string ptoken)
        {
            return client.SELECT(model, ptoken);
        }
    }
}
