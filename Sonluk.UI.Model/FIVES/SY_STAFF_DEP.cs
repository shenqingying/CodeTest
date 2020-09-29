using Sonluk.UI.Model.MODEL;
using Sonluk.UI.Model.S5.SY_STAFF_DEPService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.FIVES
{
    public class SY_STAFF_DEP
    {
        private SY_STAFF_DEPSoapClient client = new SY_STAFF_DEPSoapClient("SY_STAFF_DEPSoap", AppConfig.Settings("RemoteAddress") + "FIVES/SY_STAFF_DEP.asmx");

        public MES_RETURN_UI Create(FIVES_SY_STAFF_DEP model, string ptoken)
        {
            MES_RETURN mr = client.Create(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI Update(FIVES_SY_STAFF_DEP model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public FIVES_SY_STAFF_DEPList[] Read(FIVES_SY_STAFF_DEP model, string ptoken)
        {
            return client.Read(model, ptoken);
        }
        public FIVES_SY_STAFF_DEPList[] ReadByDJ(FIVES_SY_STAFF_DEP model, string ptoken)
        {
            return client.ReadByDJ(model, ptoken);
        }
        public MES_RETURN_UI Delete(FIVES_SY_STAFF_DEP model, string ptoken)
        {
            MES_RETURN mr = client.DELETE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI Update_All(FIVES_SY_STAFF_DEP[] model, int staffid, string ptoken)
        {
            MES_RETURN mr = client.Update_All(model, staffid, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
    }
}
