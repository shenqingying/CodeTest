using Sonluk.UI.Model.MES.BAT_QLTYService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class BAT_QLTY
    {
        private BAT_QLTYSoapClient client = new BAT_QLTYSoapClient("BAT_QLTYSoap", AppConfig.Settings("RemoteAddress") + "MES/BAT_QLTY.asmx");

        public MES_ZLRBB_SELECT SELECT(MES_ZLRBB_SEARCH model, String token)
        {
            return client.SELECT(model, token);
        }

        public MES_ZLRBB_SELECT SELECT_SUM(MES_ZLRBB_SEARCH model, String token)
        {
            return client.SELECT_SUM(model, token);
        }

        public MES_ZLRBB_SELECT TMARK_SELECT_SUM(MES_ZLRBB_SEARCH model, String token)
        {
            return client.TMARK_SELECT_SUM(model, token);
        }

        public MES_RETURN_UI COVER(MES_ZLRBB model, int STAFFID, String token)
        {
            MES_RETURN mr = client.COVER(model, STAFFID, token);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public MES_RETURN_UI COVER_TMARK(MES_ZLRBB model, int STAFFID, String token)
        {
            MES_RETURN mr = client.COVER_TMARK(model, STAFFID, token);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public MES_RETURN_UI ACTION(int RI, String token)
        {
            MES_RETURN mr = client.ACTION(RI, token);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public MES_RETURN_UI DELETE(int RI, int STAFFID, String token)
        {
            MES_RETURN mr = client.DELETE(RI, STAFFID, token);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public MES_RETURN_UI DELETE_TMARK(int RI, String token)
        {
            MES_RETURN mr = client.DELETE_TMARK(RI, token);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_SELECTOfMES_ZLRBB_STAFF STAFF_SELECT(MES_ZLRBB_STAFF model, String token)
        {
            return client.STAFF_SELECT(model, token);
        }
    }
}
