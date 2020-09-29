using Sonluk.UI.Model.MES.SY_GZZX_SBHService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class SY_GZZX_SBH
    {
        private SY_GZZX_SBHSoapClient client = new SY_GZZX_SBHSoapClient("SY_GZZX_SBHSoap", AppConfig.Settings("RemoteAddress") + "MES/SY_GZZX_SBH.asmx");

        public MES_RETURN_UI INSERT(MES_SY_GZZX_SBH model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
            //return client.INSERT(model,ptoken);
        }
        public MES_RETURN_UI DELETE(string SBBH, string ptoken)
        {
            MES_RETURN mr = client.DELETE(SBBH, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
            //return client.DELETE(ID, ptoken);
        }
        public MES_RETURN_UI UPDATE(MES_SY_GZZX_SBH model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
            //return client.UPDATE(model, ptoken);
        }
        public MES_SY_GZZX_SBH[] SELECT(MES_SY_GZZX_SBH model, string ptoken)
        {
            model.ISACTION = 1;
            return client.SELECT(model, ptoken);
        }

        public MES_SY_GZZX_SBH[] SELECT_ALL(MES_SY_GZZX_SBH model, string ptoken)
        {
            model.ISACTION = 0;
            return client.SELECT(model, ptoken);
        }
        public MES_SY_GZZX_SBH[] SELECT_BY_STAFFID(MES_SY_GZZX_SBH model, string ptoken)
        {
            return client.SELECT_BY_STAFFID(model, ptoken);
        }
        public MES_PD_TL_TD_SELECT SELECT_BY_TDNO(MES_PD_TL_TD model, string ptoken)
        {
            return client.SELECT_BY_TDNO(model, ptoken);
        }
        public MES_RETURN_UI INSERT_BY_TDNO(MES_PD_TL_TD model, string ptoken)
        {
            MES_RETURN mr = client.INSERT_BY_TDNO(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI DELETE_BY_TDNO(string TDNO, string ptoken)
        {
            MES_RETURN mr = client.DELETE_BY_TDNO(TDNO, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI UPDATE_BY_TDNO(MES_PD_TL_TD model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE_BY_TDNO(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_SY_GZZX_SBH_SELECT SELECT_BY_FSBBH(MES_SY_GZZX_SBH model, string ptoken)
        {
            model.LB = 1;
            return client.SELECT_LB(model, ptoken);
        }
        public MES_SY_GZZX_SBH_SELECT SELECT_LB(MES_SY_GZZX_SBH model, string ptoken)
        {
            return client.SELECT_LB(model, ptoken);
        }
    }
}
