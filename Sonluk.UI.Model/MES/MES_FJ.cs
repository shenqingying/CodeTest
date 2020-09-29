using Sonluk.UI.Model.MES.MES_FJService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class MES_FJ
    {
        private MES_FJSoapClient client = new MES_FJSoapClient("MES_FJSoap", AppConfig.Settings("RemoteAddress") + "MES/MES_FJ.asmx");
        public ZBCFUN_XFPC_READ SELECT_XFPC_BY_XFCD(int XFCD, string ptoken)
        {
            return client.SELECT_XFPC_BY_XFCD(XFCD, ptoken);
        }
        public ZBCFUN_XFPC_READ SELECT_PC(string GC, string WLH, string ptoken)
        {
            return client.SELECT_PC(GC, WLH, ptoken);
        }
    }
}
