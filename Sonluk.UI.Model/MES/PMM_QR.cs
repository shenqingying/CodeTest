using Sonluk.UI.Model.MES.PMM_QRService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class PMM_QR
    {
        private PMM_QRSoapClient client = new PMM_QRSoapClient("PMM_QRSoap", AppConfig.Settings("RemoteAddress") + "MES/PMM_QR.asmx");

        public MES_PMM_QR_SELECT QLTY_SELECT(MES_PMM_QR model, string token)
        {
            return client.QLTY_SELECT(model, token);
        }

        public MES_RETURN_UI QLTY_INSERT(MES_PMM_QR model, int STAFFID, string token)
        {
            MES_RETURN mr = client.QLTY_INSERT(model, STAFFID, token);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public MES_RETURN_UI QLTY_UPDATE(MES_PMM_QR model, int STAFFID, string token)
        {
            MES_RETURN mr = client.QLTY_UPDATE(model, STAFFID, token);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public MES_RETURN_UI QLTY_DELETE(int QID, int STAFFID, string token)
        {
            MES_RETURN mr = client.QLTY_DELETE(QID, STAFFID, token);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public MES_PMM_QR_SELECT REP_SELECT(MES_PMM_QR model, string token)
        {
            return client.REP_SELECT(model, token);
        }

        public MES_RETURN_UI REP_INSERT(MES_PMM_QR model, int STAFFID, string token)
        {
            MES_RETURN mr = client.REP_INSERT(model, STAFFID, token);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public MES_RETURN_UI REP_UPDATE(MES_PMM_QR model, int STAFFID, string token)
        {
            MES_RETURN mr = client.REP_UPDATE(model, STAFFID, token);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public MES_RETURN_UI REP_DELETE(int RID, int STAFFID, string token)
        {
            MES_RETURN mr = client.REP_DELETE(RID, STAFFID, token);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public MES_PMM_QR_SELECT QR_SELECT_BY_QCODE(int QID, string token)
        {
            return client.QR_SELECT_BY_QCODE(QID, token);
        }

        public MES_RETURN_UI QR_COVER(MES_PMM_QR model, string token)
        {
            MES_RETURN mr = client.QR_COVER(model, token);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public MES_RETURN_UI QR_DELETE(MES_PMM_QR model, string token)
        {
            MES_RETURN mr = client.QR_DELETE(model, token);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
    }
}
