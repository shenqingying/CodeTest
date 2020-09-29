using Sonluk.UI.Model.HR.XZGL_FFJLService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.HR
{
    public class XZGL_FFJL
    {
        private WS_HR_XZGL_FFJLSoapClient client = new WS_HR_XZGL_FFJLSoapClient("WS_HR_XZGL_FFJLSoap", AppConfig.Settings("RemoteAddress") + "HR/WS_HR_XZGL_FFJL.asmx");
        public MES_RETURN_UI INSERT(HR_XZGL_FFJL model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TID = mr.TID;
            return mrui;
        }
        public HR_XZGL_FFJL_SELECT SELECT(HR_XZGL_FFJL model, int LB, string ptoken)
        {
            return client.SELECT(model, LB, ptoken);
        }
        public MES_RETURN_UI UPDATE(HR_XZGL_FFJL model, int LB, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, LB, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TID = mr.TID;
            return mrui;
        }
        public MES_RETURN_UI ZQMONTH_UPDATE(HR_XZGL_FFJL model, string ptoken)
        {
            MES_RETURN mr = client.ZQMONTH_UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TID = mr.TID;
            return mrui;
        }
        public HR_XZGL_FFJL_SELECT ZQMONTH_SELECT(HR_XZGL_FFJL model, string ptoken)
        {
            return client.ZQMONTH_SELECT(model, ptoken);
        }
        public HR_XZGL_FFJL_SELECT ZQMONTH_SELECT_LB(HR_XZGL_FFJL model, string ptoken)
        {
            return client.ZQMONTH_SELECT_LB(model, ptoken);
        }
    }
}
