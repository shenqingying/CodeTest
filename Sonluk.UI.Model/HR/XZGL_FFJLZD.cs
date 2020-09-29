using Sonluk.UI.Model.HR.XZGL_FFJLZDService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.HR
{
    public class XZGL_FFJLZD
    {
        private WS_HR_XZGL_FFJLZDSoapClient client = new WS_HR_XZGL_FFJLZDSoapClient("WS_HR_XZGL_FFJLZDSoap", AppConfig.Settings("RemoteAddress") + "HR/WS_HR_XZGL_FFJLZD.asmx");
        public MES_RETURN_UI INSERT(HR_XZGL_FFJLZD model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI UPDATE(HR_XZGL_FFJLZD model, int LB, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, LB, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_XZGL_FFJLZD_SELECT SELECT(HR_XZGL_FFJLZD model, string ptoken)
        {
            return client.SELECT(model, ptoken);
        }
        public MES_RETURN_UI GS_FORMULA_VERIFY(string FORMULA, string ptoken)
        {
            MES_RETURN mr = client.GS_FORMULA_VERIFY(FORMULA, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_XZGL_FFJLZD_YYTABLE_SELECT SELECT_YYTABLE(HR_XZGL_FFJLZD_YYTABLE model, string ptoken)
        {
            return client.SELECT_YYTABLE(model, ptoken);
        }
        public HR_XZGL_FFJLZD_YYTABLEZD_SELECT SELECT_YYTABLEZD(HR_XZGL_FFJLZD_YYTABLEZD model, string ptoken)
        {
            return client.SELECT_YYTABLEZD(model, ptoken);
        }
        public MES_RETURN_UI INSERT_YYTABLEZD(HR_XZGL_FFJLZD_YYTABLEZD model, string ptoken)
        {
            MES_RETURN mr = client.INSERT_YYTABLEZD(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI UPDATE_YYTABLEZD(HR_XZGL_FFJLZD_YYTABLEZD model, int LB, string ptoken)
        {
            MES_RETURN mr = client.UPDATE_YYTABLEZD(model, LB, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
    }
}
