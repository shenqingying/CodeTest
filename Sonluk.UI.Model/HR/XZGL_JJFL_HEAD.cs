using Sonluk.UI.Model.HR.XZGL_JJFL_HEADService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.HR
{
    public class XZGL_JJFL_HEAD
    {
        private WS_HR_XZGL_JJFL_HEADSoapClient client = new WS_HR_XZGL_JJFL_HEADSoapClient("WS_HR_XZGL_JJFL_HEADSoap", AppConfig.Settings("RemoteAddress") + "HR/WS_HR_XZGL_JJFL_HEAD.asmx");
        public MES_RETURN_UI INSERT(HR_XZGL_JJFL_HEAD model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TID = mr.TID;
            return mrui;
        }
        public MES_RETURN_UI UPDATE(HR_XZGL_JJFL_HEAD model, int LB, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, LB, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_XZGL_JJFL_HEAD_SELECT SELECT(HR_XZGL_JJFL_HEAD model, string ptoken)
        {
            return client.SELECT(model, ptoken);
        }
    }
}
