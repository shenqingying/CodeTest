using Sonluk.UI.Model.MODEL;
using Sonluk.UI.Model.S5.SY_RELATIONSHIPBINDService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.FIVES
{
    public class SY_RELATIONSHIPBIND
    {
        private SY_RELATIONSHIPBINDSoapClient client = new SY_RELATIONSHIPBINDSoapClient("SY_RELATIONSHIPBINDSoap", AppConfig.Settings("RemoteAddress") + "FIVES/SY_RELATIONSHIPBIND.asmx");
        public MES_RETURN_UI Create(FIVES_SY_RELATIONSHIPBIND model, string ptoken)
        {
            MES_RETURN mr = client.Create(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI Update(FIVES_SY_RELATIONSHIPBIND model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public FIVES_SY_RELATIONSHIPBINDList[] Read(FIVES_SY_RELATIONSHIPBIND model, string ptoken)
        {
            return client.Read(model, ptoken);
        }
        public MES_RETURN_UI Delete(FIVES_SY_RELATIONSHIPBIND model, string ptoken)
        {
            MES_RETURN mr = client.DELETE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI Delete_OBJ1(FIVES_SY_RELATIONSHIPBIND model, string ptoken)
        {
            MES_RETURN mr = client.Delete_OJB1(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI Delete_OBJ2(FIVES_SY_RELATIONSHIPBIND model, string ptoken)
        {
            MES_RETURN mr = client.Delete_OJB2(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
    }
}
