using Sonluk.UI.Model.MSG.MSG_SENDWAYService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MSG
{
    public class MSG_SENDWAY
    {
        private MSG_SENDWAYSoapClient client = new MSG_SENDWAYSoapClient("MSG_SENDWAYSoap", AppConfig.Settings("RemoteAddress") + "MSG/MSG_SENDWAY.asmx");

        public int Create(MSG_MSG_SENDWAY model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(MSG_MSG_SENDWAY model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public MSG_MSG_SENDWAY[] ReadByParam(MSG_MSG_SENDWAY model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int Delete(int SENDWAYID, int XGR, string ptoken)
        {
            return client.Delete(SENDWAYID, XGR, ptoken);
        }




    }
}
