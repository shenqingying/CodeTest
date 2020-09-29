using Sonluk.UI.Model.MES.PMM_MOULDService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class PMM_MOULD
    {
        private PMM_MOULDSoapClient client = new PMM_MOULDSoapClient("PMM_MOULDSoap", AppConfig.Settings("RemoteAddress") + "MES/PMM_MOULD.asmx");

        public MES_PMM_MOULD_SELECT SELECT(MES_PMM_MOULD model, int STAFFID, string token)
        {
            return client.SELECT(model, token, STAFFID);
        }
        public MES_PMM_MOULD_SELECT SELECT_ALL(MES_PMM_MOULD model, string token)
        {
            return client.SELECT_ALL(model, token);
        }

        public MES_RETURN_UI INSERT(MES_PMM_MOULD model, int STAFFID, string token)
        {
            MES_RETURN mr = client.INSERT(model, token, STAFFID);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public MES_RETURN_UI UPDATE(MES_PMM_MOULD model, int STAFFID, string token)
        {
            MES_RETURN mr = client.UPDATE(model, token, STAFFID);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public MES_RETURN_UI DELETE(string MID, int STAFFID, string token)
        {
            MES_RETURN mr = client.DELETE(MID, token, STAFFID);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
    }
}
