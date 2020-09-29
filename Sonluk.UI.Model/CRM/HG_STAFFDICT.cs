using Sonluk.UI.Model.CRM.HG_STAFFDICTService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class HG_STAFFDICT
    {
        private HG_STAFFDICTSoapClient client = new HG_STAFFDICTSoapClient("HG_STAFFDICTSoap", AppConfig.Settings("RemoteAddress") + "CRM/HG_STAFFDICT.asmx");

        public int Create(CRM_HG_STAFFDICT model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public CRM_HG_STAFFDICT[] ReadByParam(CRM_HG_STAFFDICT model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int Delete(int STAFFID, int DICID, string ptoken)
        {
            return client.Delete(STAFFID, DICID, ptoken);
        }


    }
}
