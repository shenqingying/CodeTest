using Sonluk.UI.Model.MES.SY_DCXH_COUNTService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class SY_DCXH_COUNT
    {
        private SY_DCXH_COUNTSoapClient client = new SY_DCXH_COUNTSoapClient("SY_DCXH_COUNTSoap", AppConfig.Settings("RemoteAddress") + "MES/SY_DCXH_COUNT.asmx");
        public MES_SY_DCXH_COUNT_SELECT SELECT(MES_SY_DCXH_COUNT model, string ptoken)
        {
            return client.SELECT(model, ptoken);
        }
        public MES_RETURN INSERT(MES_SY_DCXH_COUNT model, string ptoken)
        {
            return client.INSERT(model, ptoken);
        }
        public MES_RETURN UPDATE(MES_SY_DCXH_COUNT model, string ptoken)
        {
            return client.UPDATE(model, ptoken);
        }
        public MES_RETURN DELETE(MES_SY_DCXH_COUNT model, string ptoken)
        {
            return client.DELETE(model, ptoken);
        }
        public MES_SY_DCXH_COUNT_SELECT SELECT_LB(MES_SY_DCXH_COUNT model, string ptoken)
        {
            return client.SELECT_LB(model, ptoken);
        }
    }
}
