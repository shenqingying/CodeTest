using Sonluk.UI.Model.MES.BAT_SPECS_PERFORService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class BAT_SPECS_PERFOR
    {
        private BAT_SPECS_PERFORSoapClient client = new BAT_SPECS_PERFORSoapClient("BAT_SPECS_PERFORSoap", AppConfig.Settings("RemoteAddress") + "MES/BAT_SPECS_PERFOR.asmx");

        public MES_RETURN_UI COVER_LIST(MES_DCDXNSZ_SELECT model, String token)
        {
            MES_RETURN mr = client.COVER_LIST(model, token);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public MES_RETURN_UI MCOVER_LIST(MES_DCDXNSZ_SELECT model, String token)
        {
            MES_RETURN mr = client.MCOVER_LIST(model, token);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public MES_RETURN_UI COVER(MES_DCDXNSZ model, String token)
        {
            MES_RETURN mr = client.COVER(model, token);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public MES_DCDXNSZ_SELECT SELECT(MES_DCDXNSZ_SEARCH model, String token)
        {
            return client.SELECT(model, token);
        }

        public MES_RETURN_UI INSERT(MES_DCDXNSZ model, String token)
        {
            MES_RETURN mr = client.INSERT(model, token);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public MES_RETURN_UI UPDATE(MES_DCDXNSZ model, String token)
        {
            MES_RETURN mr = client.UPDATE(model, token);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public MES_RETURN_UI DELETE(int RI, String token)
        {
            MES_RETURN mr = client.DELETE(RI, token);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
    }
}
