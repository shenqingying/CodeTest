using Sonluk.UI.Model.MES.MES_WLKCBSService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class MES_WLKCBS
    {
        private MES_WLKCBSSoapClient client = new MES_WLKCBSSoapClient("MES_WLKCBSSoap", AppConfig.Settings("RemoteAddress") + "MES/MES_WLKCBS.asmx");

        public ZBCFUN_PURBS_READ GET_WLPZ(ZSL_BCS303_CT IS_PURCT, string ptoken)
        {
            return client.GET_WLPZ(IS_PURCT, ptoken);
        }
        public ZBCFUN_PURBS_READ GET_WLPZ_ZJ(ZSL_BCS303_BS IS_PURBS, string ptoken)
        {
            return client.GET_WLPZ_ZJ(IS_PURBS, ptoken);
        }
        public ZBCFUN_PURBS_READ INSERT_TM_WLPZ(ZSL_BCS303_BS[] model, int INSERTLB, string ptoken)
        {
            return client.INSERT_TM_WLPZ(model, INSERTLB, ptoken);
        }
    }
}
