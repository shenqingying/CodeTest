using Sonluk.UI.Model.MES.PD_SCRWService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class PD_SCRW
    {
        private PD_SCRWSoapClient client = new PD_SCRWSoapClient("PD_SCRWSoap", AppConfig.Settings("RemoteAddress") + "MES/PD_SCRW.asmx");
        public SELECT_MES_PD_SCRW SELECT(MES_PD_SCRW model, string ptoken)
        {
            return client.SELECT(model, ptoken);
        }

        public MES_PD_SCRWANDPD_LIST_SELECT SELECT_SCRW_GD(MES_PD_SCRW model, string ptoken)
        {
            return client.SELECT_SCRW_GD(model, ptoken);
        }

        public MES_RETURN_UI DELETE(MES_PD_SCRW model, string ptoken)
        {
            MES_RETURN mr = client.DELETE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public MES_RETURN_UI INSERT_LIST(MES_PD_SCRW_LIST[] model, string ptoken)
        {
            MES_RETURN mr = client.INSERT_LIST(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public SELECT_MES_PD_SCRW SELECT_ZPQD(MES_PD_SCRW model, string ptoken)
        {
            return client.SELECT_ZPQD(model, ptoken);
        }

        public SELECT_MES_PD_SCRW UPDATE_FJTL(MES_PD_SCRW model, string ptoken)
        {
            return client.UPDATE_FJTL(model, ptoken);
        }

        public SELECT_MES_PD_SCRW UPDATE_FJCC(MES_PD_SCRW model, string ptoken)
        {
            return client.UPDATE_FJCC(model, ptoken);
        }

        public MES_RETURN_UI FJTL_VERIFY(MES_PD_TL model, string ptoken)
        {
            model.TLLB = 1;
            MES_RETURN mr = client.FJTL_VERIFY(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public SELECT_MES_PD_SCRW SELECT_LAST(MES_PD_SCRW model, string ptoken)
        {
            return client.SELECT_LAST(model, ptoken);
        }

        public MES_PD_SCRW_CCTH SELECT_ZXCCINFO(string RWBH, int BC, string ptoken)
        {
            return client.SELECT_ZXCCINFO(RWBH, BC, 1, ptoken);
        }
        public MES_PD_SCRW_CCTH SELECT_TH_BY_GDDH_SBBH(string RWBH, string ptoken)
        {
            return client.SELECT_ZXCCINFO(RWBH, 0, 3, ptoken);
        }
        public MES_RETURN_UI ZX_CC(MES_PD_SCRW_ZXCC_INSERT model, string ptoken)
        {
            MES_RETURN mr = client.ZX_CC(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.GC = mr.GC;
            mrui.TM = mr.TM;
            return mrui;
        }
        public MES_RETURN_UI ZX_CC_NOUPDATE_TIME(MES_PD_SCRW_ZXCC_INSERT model, string ptoken)
        {
            MES_RETURN mr = client.ZX_CC_NOUPDATE_TIME(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.GC = mr.GC;
            mrui.TM = mr.TM;
            return mrui;
        }
        public SELECT_MES_PD_SCRW_ZX_LIST SELECT_ZX_LIST(string RWBH, string ptoken)
        {
            return client.SELECT_ZX_LIST(RWBH, ptoken);
        }


        public MES_RETURN_UI DELETE_ZXCC(string TM, string ptoken)
        {
            MES_RETURN mr = client.DELETE_ZXCC(TM, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public MES_RETURN_UI UPDATE_SCRW(MES_PD_SCRW model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE_SCRW(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public MES_PD_SCRW_CCTH SELECT_CCTH_BB(string RWBH, int BC, string ptoken)
        {
            return client.SELECT_ZXCCINFO(RWBH, BC, 2, ptoken);
        }

        public SELECT_MES_PD_SCRW GET_RWBH_BY_ERPNO(MES_PD_SCRW_GET_BY_ERPNO model, string ptoken)
        {
            return client.GET_RWBH_BY_ERPNO(model, ptoken);
        }

        public SELECT_MES_PD_SCRW GET_RWBH_BY_TPM(MES_PD_SCRW_GET_BY_TPM model, string ptoken)
        {
            return client.GET_RWBH_BY_TPM(model, ptoken);
        }
        public MES_RETURN INSERT_BY_FJPD(MES_PD_SCRW model, string ptoken)
        {
            return client.INSERT_BY_FJPD(model, ptoken);
        }
        public SELECT_MES_PD_SCRW SELECT_BY_ROLE(MES_PD_SCRW model, string ptoken)
        {
            return client.SELECT_BY_ROLE(model, ptoken);
        }
        public MES_RETURN_UI DELETE_GZZX(string GC, string GZZXBH, int BC, string GDDH, string ZPRQ, string ptoken)
        {
            MES_RETURN mr = client.DELETE_GZZX(GC, GZZXBH, BC, GDDH, ZPRQ, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public SELECT_MES_PD_SCRW SELECT_BY_TM(MES_PD_SCRW_SELECT_BY_TM model, string ptoken)
        {
            return client.SELECT_BY_TM(model, ptoken);
        }
        public MES_PD_SCRW_SUM_SELECT SELECT_SUM(MES_PD_SCRW_SUM_LIST model, string ptoken)
        {
            return client.SELECT_SUM(model, ptoken);
        }
        public MES_SY_FJ_RWKB_SELECT SELECT_JDKB(MES_SY_FJ_RWKB model, string ptoken)
        {
            return client.SELECT_JDKB(model, ptoken);
        }
        public MES_RETURN_UI UPDATE_ALL(MES_PD_SCRW_UPDATE_IN model, int LB, string ptoken)
        {
            MES_RETURN mr = client.UPDATE_ALL(model, LB, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
    }
}
