using Sonluk.UI.Model.MES.SY_XTBBService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class SY_XTBB
    {
        private SY_XTBBSoapClient client = new SY_XTBBSoapClient("SY_XTBBSoap", AppConfig.Settings("RemoteAddress") + "MES/SY_XTBB.asmx");
        public MES_RETURN_UI INSERT(MES_SY_XTBB model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI DELETE(int ID, string ptoken)
        {
            MES_RETURN mr = client.DELETE(ID, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_SY_XTBB_SELECT SELECT(MES_SY_XTBB model, string ptoken)
        {
            return client.SELECT(model, ptoken);
        }
        public MES_RETURN_UI UPDATE(MES_SY_XTBB model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
    }
}
