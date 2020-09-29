using Sonluk.UI.Model.MES.MES_TPMService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class MES_TPM
    {
        private MES_TPMSoapClient client = new MES_TPMSoapClient("MES_TPMSoap", AppConfig.Settings("RemoteAddress") + "MES/MES_TPM.asmx");
        public ZBCFUN_TPINFO_INSERT INSERT_TPM(ZSL_BCS025 model, string IV_COUNT)
        {
            return client.INSERT_TPM(model, IV_COUNT);
        }
        public ZBCFUN_TPINFO_INSERT DELETE_TPM(string IV_TPNO)
        {
            return client.DELETE_TPM(IV_TPNO);
        }
        public ZBCFUN_TPINFO_INSERT UPDATE_TPM(ZSL_BCS025 model)
        {
            string IV_FCODE = "1";
            List<ZSL_BCT012> model_IT_TPYD = new List<ZSL_BCT012>();
            return client.UPDATE_TPM(model, model_IT_TPYD.ToArray(), IV_FCODE, "", "");
        }
        public ZBCFUN_TPINFO_INSERT UPDATE_TPYD(ZSL_BCT012[] IT_TPYD, string IV_LGORT, string IV_WERKS)
        {
            string IV_FCODE = "2";
            ZSL_BCS025 model = new ZSL_BCS025();
            return client.UPDATE_TPM(model, IT_TPYD, IV_FCODE, IV_LGORT, IV_WERKS);
        }
        public ZBCFUN_TPINFO_SELECT SELECT_TPM(ZSL_BCS025 model)
        {
            return client.SELECT_TPM(model);
        }
        public ZBCFUN_TP_ZHM_GL INSERT_TP_WZHM(ZSL_BCT011 IT_TPZHNO, ZSL_BCT012[] IT_TPZHNO_GL)
        {
            string IV_FCODE = "1";
            return client.INSERT_TP_ZHM(IV_FCODE, IT_TPZHNO, IT_TPZHNO_GL);
        }
        public ZBCFUN_TP_ZHM_GL INSERT_TP_ZHM(ZSL_BCT011 IT_TPZHNO, ZSL_BCT012[] IT_TPZHNO_GL)
        {
            string IV_FCODE = "2";
            return client.INSERT_TP_ZHM(IV_FCODE, IT_TPZHNO, IT_TPZHNO_GL);
        }
        public ZBCFUN_TP_ZHM_GL SELECT_TP_ZHNOa(string TPZHNO, string CJRQKS, string CJRQJS, string CJRNAME)
        {
            string IV_FCODE = "1";
            return client.SELECT_TP_ZHM(IV_FCODE, TPZHNO, CJRQKS, CJRQJS, CJRNAME);
        }
        public ZBCFUN_TP_ZHM_GL SELECT_TP_ZHNOb(string TPZHNO)
        {
            string IV_FCODE = "2";
            return client.SELECT_TP_ZHM(IV_FCODE, TPZHNO, "", "", "");
        }
        public ZBCFUN_TP_ZHM_GL DELETE_TP_TPNO(string TPZHNO)
        {
            string IV_FCODE = "1";
            ZSL_BCT012 model = new ZSL_BCT012();
            return client.DELETE_TP_ZHM(model, IV_FCODE, TPZHNO);
        }
        public ZBCFUN_TP_ZHM_GL DELETE_TP_TPZHNO(ZSL_BCT012 model)
        {
            string IV_FCODE = "2";
            string TPZHNO = "";
            return client.DELETE_TP_ZHM(model, IV_FCODE, TPZHNO);
        }
        public ZBCFUN_TP_RKBS_GL INSERT_TP_RKBS(ZSL_BCT010[] IT_TPNO_GL)
        {
            return client.INSERT_TP_RKBS(IT_TPNO_GL);
        }
        public ZBCFUN_TP_RKBS_GL SELECT_TP_RKBS(string TPNO)
        {
            return client.SELECT_TP_RKBS(TPNO);
        }
        public ZBCFUN_TP_RKBS_GL DELETE_TP_RKBS(ZSL_BCT010 IS_TPNO_GL)
        {
            return client.DELETE_TP_RKBS(IS_TPNO_GL);
        }
        public MES_SY_TPM_SYNC_SELECT SELECT_TPM_SYNC(MES_SY_TPM_SYNC model, string ptoken)
        {
            return client.SELECT_TPM_SYNC(model, ptoken);
        }
    }
}
