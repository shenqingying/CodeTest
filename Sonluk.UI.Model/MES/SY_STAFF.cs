using Sonluk.UI.Model.MES.SY_STAFFService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class SY_STAFF
    {
        private SY_STAFFSoapClient client = new SY_STAFFSoapClient("SY_STAFFSoap", AppConfig.Settings("RemoteAddress") + "MES/SY_STAFF.asmx");
        public MES_SY_STAFF_SELECT SELECT(MES_SY_STAFF model, string ptoken)
        {
            return client.SELECT(model, ptoken);
        }
        public MES_RETURN_UI UPDATE_STAFFPW(int STAFFID, string OLDPW, string NEWPW, string ptoken)
        {
            MES_RETURN mr = client.UPDATE_STAFFPW(STAFFID, OLDPW, NEWPW, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
    }
}
