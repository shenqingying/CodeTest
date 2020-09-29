using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sonluk.UI.Model.MES.SY_CHANGEINFOService;
using Sonluk.Utility;
//using Sonluk.UI.Model.MES.SY_CHANGEINFOService;
namespace Sonluk.UI.Model.MES
{
    public class SY_CHANGEINFO
    {
        private SY_CHANGEINFOSoapClient client = new SY_CHANGEINFOSoapClient("SY_CHANGEINFOSoap", AppConfig.Settings("RemoteAddress") + "MES/SY_CHANGEINFO.asmx");
        public MES_SY_CHANGEINFO_SELECT SELECT(MES_SY_CHANGEINFOLIST model, string ptoken)
        {
            return client.SELECT(model, ptoken);
        }
        
    }
}
