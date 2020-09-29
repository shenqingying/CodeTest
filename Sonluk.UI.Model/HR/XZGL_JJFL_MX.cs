using Sonluk.UI.Model.HR.XZGL_JJFL_MXService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.HR
{
    public class XZGL_JJFL_MX
    {
        private WS_HR_XZGL_JJFL_MXSoapClient client = new WS_HR_XZGL_JJFL_MXSoapClient("WS_HR_XZGL_JJFL_MXSoap", AppConfig.Settings("RemoteAddress") + "HR/WS_HR_XZGL_JJFL_MX.asmx");
        public MES_RETURN_UI INSERT(HR_XZGL_JJFL_MX model, DataTable RYLIST, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, RYLIST, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TID = mr.TID;
            return mrui;
        }
        public MES_RETURN_UI UPDATE(HR_XZGL_JJFL_MX model, int LB, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, LB, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_XZGL_JJFL_MX_SELECT SELECT(HR_XZGL_JJFL_MX model, string ptoken)
        {
            return client.SELECT(model, ptoken);
        }
    }
}
