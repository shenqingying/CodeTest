using Sonluk.UI.Model.MSG.MSG_TYPEService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MSG
{
    public class MSG_TYPE
    {
        private MSG_TYPESoapClient client = new MSG_TYPESoapClient("MSG_TYPESoap", AppConfig.Settings("RemoteAddress") + "MSG/MSG_TYPE.asmx");

        public int Create(MSG_MSG_TYPE model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(MSG_MSG_TYPE model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public MSG_MSG_TYPE[] ReadByParam(MSG_MSG_TYPE model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int Delete(int MSGTYPEID, string ptoken)
        {
            return client.Delete(MSGTYPEID, ptoken);
        }




    }
}
