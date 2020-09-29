using Sonluk.UI.Model.MES.TM_ZFDCMXService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class TM_ZFDCMX
    {
        private TM_ZFDCMXSoapClient client = new TM_ZFDCMXSoapClient("TM_ZFDCMXSoap", AppConfig.Settings("RemoteAddress") + "MES/TM_ZFDCMX.asmx");
        public MES_RETURN_UI INSERT(MES_TM_ZFDCMX model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_TM_ZFDCMX_SELECT SELECT(string TM, string ptoken)
        {
            return client.SELECT(TM, ptoken);
        }
        public MES_RETURN_UI DELETE(MES_TM_ZFDCMX model, string ptoken)
        {
            MES_RETURN mr = client.DELETE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
    }
}
