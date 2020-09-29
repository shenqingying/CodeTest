using Sonluk.UI.Model.MES.MES_MMService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class MES_MM
    {
        private MES_MMSoapClient client = new MES_MMSoapClient("MES_MMSoap", AppConfig.Settings("RemoteAddress") + "MES/MES_MM.asmx");
        public MES_SY_MATERIAL_INSERT_LIST GET_WLXXBYGROUP(string IV_WERKS, string WLGROUP, string MATNR, string FCODE, string ptoken)
        {
            return client.GET_WLXXBYGROUP(IV_WERKS, WLGROUP, MATNR, FCODE, ptoken);
        }
    }
}
