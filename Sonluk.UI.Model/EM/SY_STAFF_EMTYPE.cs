using Sonluk.UI.Model.EM.SY_STAFF_EMTYPEService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.EM
{
    public class SY_STAFF_EMTYPE
    {
        private SY_STAFF_EMTYPESoapClient client = new SY_STAFF_EMTYPESoapClient("SY_STAFF_EMTYPESoap", AppConfig.Settings("RemoteAddress") + "EM/SY_STAFF_EMTYPE.asmx");
        public MES_RETURN_UI Create(EM_SY_STAFF_EMTYPE model, string ptoken)
        {
            MES_RETURN mr = client.Create(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI Update(EM_SY_STAFF_EMTYPE model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public EM_SY_STAFF_EMTYPE[] Read(EM_SY_STAFF_EMTYPE model, string ptoken)
        {
            return client.Read(model, ptoken);
        }
        public MES_RETURN_UI Delete(EM_SY_STAFF_EMTYPE model, string ptoken)
        {
            MES_RETURN mr = client.DELETE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public EM_SY_EMTYPE_LAY_SELECT SELECT_EMTYPE_ROLE(int STAFFID, string ptoken)
        {
            return client.SELECT_EMTYPE_ROLE(STAFFID, ptoken);
        }
    }
}
