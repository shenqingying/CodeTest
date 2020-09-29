using Sonluk.UI.Model.HR.XZGL_JJFL_HEARNAMEService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.HR
{
    public class XZGL_JJFL_HEARNAME
    {
        private WS_HR_XZGL_JJFL_HEARNAMESoapClient client = new WS_HR_XZGL_JJFL_HEARNAMESoapClient("WS_HR_XZGL_JJFL_HEARNAMESoap", AppConfig.Settings("RemoteAddress") + "HR/WS_HR_XZGL_JJFL_HEARNAME.asmx");
        public MES_RETURN_UI INSERT(HR_XZGL_JJFL_HEARNAME model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TID = mr.TID;
            return mrui;
        }
        public MES_RETURN_UI UPDATE(HR_XZGL_JJFL_HEARNAME model, int LB, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, LB, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_XZGL_JJFL_HEARNAME_SELECT SELECT(HR_XZGL_JJFL_HEARNAME model, string ptoken)
        {
            return client.SELECT(model, ptoken);
        }
    }
}
