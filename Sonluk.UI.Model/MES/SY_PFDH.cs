using Sonluk.UI.Model.MES.SY_PFDHService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class SY_PFDH
    {
        private SY_PFDHSoapClient client = new SY_PFDHSoapClient("SY_PFDHSoap", AppConfig.Settings("RemoteAddress") + "MES/SY_PFDH.asmx");
        public ZBCFUN_ZJLOT_PRT GET_ZJINFO_INIT(ZSL_BCT304_CT model, string ptoken)
        {
            return client.GET_ZJINFO_INIT(model, ptoken);
        }

        public ZBCFUN_ZJLOT_PRT GET_ZJINFO_BYPLDH(ZSL_BCT304_CT model, string ptoken)
        {
            return client.GET_ZJINFO_BYPLDH(model, ptoken);
        }

        public MES_RETURN_UI ZJ_CC(ZSL_BCT304_CT model, string ptoken)
        {
            MES_RETURN mr = client.ZJ_CC(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.GC = mr.GC;
            mrui.TM = mr.TM;
            return mrui;
        }

        public MES_RETURN_UI UPDATE(MES_SY_PFDH model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public MES_RETURN_UI INSERT(MES_SY_PFDH model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public MES_RETURN_UI DELETE(MES_SY_PFDH model, string ptoken)
        {
            MES_RETURN mr = client.DELETE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public MES_SY_PFDH_LIST SELECT(MES_SY_PFDH model, string ptoken)
        {
            return client.SELECT(model, ptoken);
        }
    }
}
