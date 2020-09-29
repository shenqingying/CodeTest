using Sonluk.UI.Model.PS.NetWorkService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.PS
{
    public class NetWork
    {
        private NetWorkSoapClient client = new NetWorkSoapClient("NetWorkSoap", AppConfig.Settings("RemoteAddress") + "PS/NetWork.asmx");
        public NetworkRead read(string aufnr, string ptoken)
        {
            return client.read(aufnr, ptoken);
        }

        public string StaffINFO(string INITS, string ptoken)
        {
            return client.StaffINFO(INITS, ptoken);
        }

        public string confirm(Ps_work ps_work, Ps_staff ps_staff, string ptoken)
        {
            return client.confirm(ps_work, ps_staff, ptoken);
        }

        public PS_ZPSFUG_Q_LJSJ NetWork_READ_main(string AUFNR, string ptoken)
        {
            return client.NetWork_READ_main(AUFNR, ptoken);
        }

        public PS_wlXX[] readwlXX(string MATNR, string MAKTX, string ptoken)
        {
            return client.readwlXX(MATNR, MAKTX, ptoken);
        }
    }
}
