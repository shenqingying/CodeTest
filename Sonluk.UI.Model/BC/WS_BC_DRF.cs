using Sonluk.UI.Model.BC.WS_BC_DRFService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.BC
{
    public class WS_BC_DRF
    {
        private WS_BC_DRFSoapClient client = new WS_BC_DRFSoapClient("WS_BC_DRFSoap", AppConfig.Settings("RemoteAddress") + "BC/WS_BC_DRF.asmx");

        public ZBCFUN_DRFDD_CRT_RETURN ZBCFUN_DRFDD_CRT(ZSL_BCS111 IS_HEADDATA, ZSL_BCS112[] IT_ITEMDATA, string ptoken)
        {
            return client.ZBCFUN_DRFDD_CRT(IS_HEADDATA, IT_ITEMDATA, ptoken);
        }
        public MES_RETURN_UI ZBCFUN_DRFDD_CHK(ZSL_BCS111 IS_HEADDATA, string ptoken)
        {
            MES_RETURN data = client.ZBCFUN_DRFDD_CHK(IS_HEADDATA, ptoken);
            MES_RETURN_UI dataui = new MES_RETURN_UI();
            dataui.TYPE = data.TYPE;
            dataui.MESSAGE = data.MESSAGE;
            return dataui;
        }
        public ZBCFUN_DRFDD_DT_RETURN ZBCFUN_DRFDD_DT(ZSL_BCS113[] IT_ORDERDATA, string ptoken)
        {
            return client.ZBCFUN_DRFDD_DT(IT_ORDERDATA, ptoken);
        }




    }
}
