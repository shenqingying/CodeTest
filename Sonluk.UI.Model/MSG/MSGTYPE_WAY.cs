using Sonluk.UI.Model.MSG.MSGTYPE_WAYService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MSG
{
    public class MSGTYPE_WAY
    {
        private MSGTYPE_WAYSoapClient client = new MSGTYPE_WAYSoapClient("MSGTYPE_WAYSoap", AppConfig.Settings("RemoteAddress") + "MSG/MSGTYPE_WAY.asmx");

        public int Create(MSG_MSGTYPE_WAY model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public MSG_MSGTYPE_WAY[] ReadByParam(MSG_MSGTYPE_WAY model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int Delete(MSG_MSGTYPE_WAY model, string ptoken)
        {
            return client.Delete(model, ptoken);
        }
        public int DeleteByTYPEID(int TYPEID, string ptoken)
        {
            return client.DeleteByTYPEID(TYPEID, ptoken);
        }



    }
}
