using Sonluk.UI.Model.MES.RIGHT_ROLEService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class RIGHT_ROLE
    {
        private RIGHT_ROLESoapClient client = new RIGHT_ROLESoapClient("RIGHT_ROLESoap", AppConfig.Settings("RemoteAddress") + "MES/RIGHT_ROLE.asmx");
        public MES_RIGHT_ROLE SELECT(int STAFFID, int RGROUPID, string ptoken)
        {
            return client.SELECT(STAFFID, RGROUPID, ptoken);
        }
        public MES_RIGHT_ROLE SELECT_ALL(int STAFFID, int RGROUPID, string ptoken)
        {
            return client.SELECT_ALL(STAFFID, RGROUPID, ptoken);
        }
    }
}
