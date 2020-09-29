using Sonluk.UI.Model.MES.PD_TL_ERRORService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class PD_TL_ERROR
    {
        private PD_TL_ERRORSoapClient client = new PD_TL_ERRORSoapClient("PD_TL_ERRORSoap", AppConfig.Settings("RemoteAddress") + "MES/PD_TL_ERROR.asmx");
        public MES_PD_TL_ERROR_SELECT SELECT(MES_PD_TL_ERROR model, string ptoken)
        {
            return client.SELECT(model, ptoken);
        }
    }
}
