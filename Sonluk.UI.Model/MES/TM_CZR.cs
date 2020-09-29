using Sonluk.UI.Model.MES.TM_CZRService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class TM_CZR
    {
        private TM_CZRSoapClient client = new TM_CZRSoapClient("TM_CZRSoap", AppConfig.Settings("RemoteAddress") + "MES/TM_CZR.asmx");
        public MES_RETURN_UI INSERT(MES_TM_CZR model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_TM_CZR_SELECT_CZR_NOW SELECT_CZR_NOW(MES_TM_CZR model, string ptoken)
        {
            return client.SELECT_CZR_NOW(model, ptoken);
        }
        public MES_RETURN_UI UPDATE_LEAVE(int ID, string ptoken)
        {
            MES_RETURN mr = client.UPDATE_LEAVE(ID, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;

            return mrui;
        }

        public MES_RETURN UPDATE_GW(MES_TM_CZR model, string ptoken)
        {
            return client.UPDATE_GW(model, ptoken);
        }

        public MES_SY_CZR_BYGH GET_RYNAME(string GH, string ptoken)
        {
            return client.GET_RYNAME(GH, ptoken);
        }


    }
}
