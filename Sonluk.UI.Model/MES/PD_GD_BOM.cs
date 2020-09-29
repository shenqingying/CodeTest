using Sonluk.UI.Model.MES.PD_GD_BOMService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class PD_GD_BOM
    {
        private PD_GD_BOMSoapClient client = new PD_GD_BOMSoapClient("PD_GD_BOMSoap", AppConfig.Settings("RemoteAddress") + "MES/PD_GD_BOM.asmx");
        public MES_RETURN_UI INSERT(MES_PD_GD_BOM model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI DELETE_GDDH(MES_PD_GD_BOM model, string ptoken)
        {
            MES_RETURN mr = client.DELETE(model, 1, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_PD_GD_BOM_SELECT SELECT(MES_PD_GD_BOM model, string ptoken)
        {
            return client.SELECT(model, ptoken);
        }
    }
}
