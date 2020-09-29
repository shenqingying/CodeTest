using Sonluk.UI.Model.HR.ADMINISTRATION_YHRYService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.HR
{
    public class ADMINISTRATION_YHRY
    {
        private WS_HR_ADMINISTRATION_YHRYSoapClient client = new WS_HR_ADMINISTRATION_YHRYSoapClient("WS_HR_ADMINISTRATION_YHRYSoap", AppConfig.Settings("RemoteAddress") + "HR/WS_HR_ADMINISTRATION_YHRY.asmx");
        public MES_RETURN_UI INSERT(HR_ADMINISTRATION_YHRY model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TID = mr.TID;
            return mrui;
        }
        public MES_RETURN_UI UPDATE(HR_ADMINISTRATION_YHRY model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_ADMINISTRATION_YHRY_SELECT SELECT(HR_ADMINISTRATION_YHRY model, string ptoken)
        {
            return client.SELECT(model, ptoken);
        }
    }
}
