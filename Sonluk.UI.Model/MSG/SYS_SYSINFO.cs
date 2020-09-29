using Sonluk.UI.Model.MSG.SYS_SYSINFOService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MSG
{
    public class SYS_SYSINFO
    {
        private SYS_SYSINFOSoapClient client = new SYS_SYSINFOSoapClient("SYS_SYSINFOSoap", AppConfig.Settings("RemoteAddress") + "MSG/SYS_SYSINFO.asmx");

        public int Create(MSG_SYS_SYSINFO model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(MSG_SYS_SYSINFO model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public MSG_SYS_SYSINFO[] ReadByParam(MSG_SYS_SYSINFO model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int Delete(int SYSID, int XGR, string ptoken)
        {
            return client.Delete(SYSID, XGR, ptoken);
        }



    }
}
