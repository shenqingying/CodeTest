using Sonluk.UI.Model.MSG.SYS_STAFFService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MSG
{
    public class SYS_STAFF
    {
        private SYS_STAFFSoapClient client = new SYS_STAFFSoapClient("SYS_STAFFSoap", AppConfig.Settings("RemoteAddress") + "MSG/SYS_STAFF.asmx");

        public int Create(MSG_SYS_STAFF model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(MSG_SYS_STAFF model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public MSG_SYS_STAFF[] ReadByParam(MSG_SYS_STAFF model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int Delete(int ID, int XGR, string ptoken)
        {
            return client.Delete(ID, XGR, ptoken);
        }
        public int DeleteBySYSID(int SYSID, int XGR, string ptoken)
        {
            return client.DeleteBySYSID(SYSID, XGR, ptoken);
        }




    }
}
