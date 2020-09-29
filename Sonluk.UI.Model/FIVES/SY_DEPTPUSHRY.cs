using Sonluk.UI.Model.MODEL;
using Sonluk.UI.Model.S5.SY_DEPTPUSHRYService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.FIVES
{
    public class SY_DEPTPUSHRY
    {
        private SY_DEPTPUSHRYSoapClient client = new SY_DEPTPUSHRYSoapClient("SY_DEPTPUSHRYSoap", AppConfig.Settings("RemoteAddress") + "FIVES/SY_DEPTPUSHRY.asmx");
        public MES_RETURN_UI Create(FIVES_SY_DEPTPUSHRY model, string ptoken)
        {
            MES_RETURN mr = client.Create(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public FIVES_SY_DEPTPUSHRY[] Read(FIVES_SY_DEPTPUSHRY model, string ptoken)
        {
            return client.Read(model, ptoken);
        }
        public MES_RETURN_UI Delete(FIVES_SY_DEPTPUSHRY model, string ptoken)
        {
            MES_RETURN mr = client.DELETE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
    }
}
