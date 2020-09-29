using Sonluk.UI.Model.MSG.SEND_INFOService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MSG
{
    public class SEND_INFO
    {
        private SEND_INFOSoapClient client = new SEND_INFOSoapClient("SEND_INFOSoap", AppConfig.Settings("RemoteAddress") + "MSG/SEND_INFO.asmx");

        public int Create(MSG_SEND_INFO model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(MSG_SEND_INFO model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public MSG_SEND_INFO[] ReadByParam(MSG_SEND_INFO model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int Delete(int INFOID, string ptoken)
        {
            return client.Delete(INFOID, ptoken);
        }
        public string AutoCheck()
        {
            return client.AutoCheck();
        }



    }
}
