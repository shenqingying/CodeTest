using Sonluk.UI.Model.MODEL;
using Sonluk.UI.Model.S5.STAFF_DEPService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.FIVES
{
    public class STAFF_DEP
    {
        private STAFF_DEPSoapClient client = new STAFF_DEPSoapClient("STAFF_DEPSoap", AppConfig.Settings("RemoteAddress") + "FIVES/STAFF_DEP.asmx");
        public MES_RETURN_UI Create(FIVES_STAFF_DEP model, string ptoken)
        {
            MES_RETURN mr = client.Create(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI Update(FIVES_STAFF_DEP model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public FIVES_STAFF_DEP[] Read(FIVES_STAFF_DEP model, string ptoken)
        {
            return client.Read(model, ptoken);
        }
        public MES_RETURN_UI Delete(FIVES_STAFF_DEP model, string ptoken)
        {
            MES_RETURN mr = client.DELETE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
    }
}
