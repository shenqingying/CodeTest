using Sonluk.UI.Model.MES.PD_GDService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class PD_GD
    {
        private PD_GDSoapClient client = new PD_GDSoapClient("PD_GDSoap", AppConfig.Settings("RemoteAddress") + "MES/PD_GD.asmx");

        public MES_RETURN_UI INSERT(MES_PD_GD model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public ZBCFUN_GDLIST_READ SAP_GET_GDLIST(string IV_WERKS, string IV_GZZX, string IV_WLDL, string IV_AUFNR, string LOW, string HIGH, string ptoken)
        {
            return client.SAP_GET_GDLIST(IV_WERKS, IV_GZZX, IV_WLDL, IV_AUFNR, LOW, HIGH, ptoken);
        }

        public ZBCFUN_GDJGXX_READ SAP_GET_GDJGXX(string RWBH, string ZPRQ, string GC, string ptoken)
        {
            return client.SAP_GET_GDJGXX(RWBH, ZPRQ, GC, ptoken);
        }

        public SELECT_MES_PD_GD SELECT(MES_PD_GD model, string ptoken)
        {
            return client.SELECT(model, ptoken);
        }


        public MES_RETURN_UI INSERT_FROM_SAP_GD(ZSL_BCST024_PO[] model, string ptoken)
        {
            MES_RETURN mr = client.INSERT_FROM_SAP_GD(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
            //return client.INSERT_FROM_SAP_GD(model,ptoken);
        }


        public MES_RETURN_UI UPDATE(MES_PD_GD model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public MES_RETURN_UI DELETE(MES_PD_GD model, string ptoken)
        {
            MES_RETURN mr = client.DELETE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI INSERT_BY_MES(MES_PD_GD model, string ptoken)
        {
            MES_RETURN mr = client.INSERT_BY_MES(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.BH = mr.BH;
            return mrui;
        }

        public MES_RETURN_UI INSERT_BY_SAPGDLIST(string IV_WERKS, string IV_GZZX, string IV_AUFNR, string LOW, string HIGH, int JLR, string ptoken)
        {
            MES_RETURN mr = client.INSERT_BY_SAPGDLIST(IV_WERKS, IV_GZZX, IV_AUFNR, LOW, HIGH, JLR, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public SELECT_MES_PD_GD SELECT_BY_PFDH(MES_PD_GD_SELECT_BY_PFDH model, string ptoken)
        {
            return client.SELECT_BY_PFDH(model, ptoken);
        }

        public ZBCFUN_GDJGXX_READ get_GDJGXX_BYERPNO(string IV_AUFNR, string ptoken)
        {
            return client.get_GDJGXX_BYERPNO(IV_AUFNR, ptoken);
        }
        public ZBCFUN_CPBZ_READ get_CPBZ_READ(string IV_TPM, string ptoken)
        {
            return client.get_CPBZ_READ(IV_TPM, ptoken);
        }
        public SELECT_MES_PD_GD SELECT_BY_STAFFID(MES_PD_GD model, string ptoken)
        {
            return client.SELECT_BY_STAFFID(model, ptoken);
        }
        public MES_PD_GD_GDJD_SELECT SELECT_GDJD(MES_PD_GD_GDJD_IMPORT model, string ptoken)
        {
            return client.SELECT_GDJD(model, ptoken);
        }
        public SELECT_MES_PD_GD SELECT_BY_ERPNO_SYNC(MES_PD_GD model, string ptoken)
        {
            return client.SELECT_BY_ERPNO_SYNC(model, ptoken);
        }
        public ZBCFUN_GDJGXX_READ get_GDJGXX_BYERPNO_GC(string IV_WERKS, string IV_AUFNR, string ptoken)
        {
            return client.get_GDJGXX_BYERPNO_GC(IV_WERKS,IV_AUFNR, ptoken);
        }
    }
}
