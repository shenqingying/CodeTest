using Sonluk.UI.Model.MES.SY_SCDATE_THService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class SY_SCDATE_TH
    {
        private SY_SCDATE_THSoapClient client = new SY_SCDATE_THSoapClient("SY_SCDATE_THSoap", AppConfig.Settings("RemoteAddress") + "MES/SY_SCDATE_TH.asmx");
        public MES_RETURN_UI INSERT(MES_SY_SCDATE_TH[] model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public MES_RETURN_UI UPDATE(MES_SY_SCDATE_TH model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, 1, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public MES_RETURN_UI DELETE(MES_SY_SCDATE_TH model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, 2, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public MES_SY_SCDATE_TH_SELECT SELECT(MES_SY_SCDATE_TH_SELECT_IN model, int LB, string ptoken)
        {
            return client.SELECT(model, LB, ptoken);
        }
        public MES_SY_SCDATE_TH_SELECT SELECT_BY_ROLE(MES_SY_SCDATE_TH_SELECT_IN model, int LB, string ptoken)
        {
            return client.SELECT_BY_ROLE(model, LB, ptoken);
        }
    }
}
