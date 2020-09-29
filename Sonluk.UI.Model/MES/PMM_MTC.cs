using Sonluk.UI.Model.MES.PMM_MTCService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class PMM_MTC
    {
        private PMM_MTCSoapClient client = new PMM_MTCSoapClient("PMM_MTCSoap", AppConfig.Settings("RemoteAddress") + "MES/PMM_MTC.asmx");

        public MES_PMM_MTC_SELECT SELECT(MES_PMM_MTC model, string token)
        {
            return client.SELECT(model, token);
        }

        public MES_RETURN_UI INSERT(MES_PMM_MTC model, string token)
        {
            MES_RETURN mr = client.INSERT(model, token);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TID = mr.TID;
            return mrui;
        }

        public MES_RETURN_UI UPDATE_SAVE(MES_PMM_MTC model, string token)
        {
            MES_RETURN mr = client.UPDATE_SAVE(model, token);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public MES_RETURN_UI UPDATE_START(MES_PMM_MTC model, string token)
        {
            MES_RETURN mr = client.UPDATE_START(model, token);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public MES_RETURN_UI UPDATE_BACK(MES_PMM_MTC model, string token)
        {
            MES_RETURN mr = client.UPDATE_BACK(model, token);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public MES_RETURN_UI UPDATE_MM(MES_PMM_MTC model, string token)
        {
            MES_RETURN mr = client.UPDATE_MM(model, token);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public MES_RETURN_UI UPDATE_WT(MES_PMM_MTC model, string token)
        {
            MES_RETURN mr = client.UPDATE_WT(model, token);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public MES_RETURN_UI UPDATE_QC(MES_PMM_MTC model, string token)
        {
            MES_RETURN mr = client.UPDATE_QC(model, token);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public MES_RETURN_UI UPDATE_TEC(MES_PMM_MTC model, string token)
        {
            MES_RETURN mr = client.UPDATE_TEC(model, token);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public MES_RETURN_UI UPDATE_CFMBACK(MES_PMM_MTC model, string token)
        {
            MES_RETURN mr = client.UPDATE_CFMBACK(model, token);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public MES_RETURN_UI DELETE(MES_PMM_MTC model, string token)
        {
            MES_RETURN mr = client.DELETE(model, token);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
    }
}
