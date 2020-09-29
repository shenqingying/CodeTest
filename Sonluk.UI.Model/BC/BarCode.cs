using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sonluk.UI.Model.BC.BarCodeService;
using Sonluk.Utility;

namespace Sonluk.UI.Model.BC
{
    public class BarCode
    {
        private BarCodeSoapClient client = new BarCodeSoapClient("BarCodeSoap", AppConfig.Settings("RemoteAddress") + "BC/BarCode.asmx");

        public Byte[] CreateBarCode(string code, string format, int width, int height, int pure)
        {
            return client.CreateBarCode(code, format, width, height, pure);
        }

        public string ZBCFUN_TBM_ZFTH(string srwlm, string tgwlm, string fcode)
        {
            return client.ZBCFUN_TBM_ZFTH(srwlm, tgwlm, fcode);
        }

        public ZSL_BCS007 ZBCFUN_MAT_GET(string matnr)
        {
            return client.ZBCFUN_MAT_GET(matnr);
        }

        public PickingtaskInfo ZBCFUN_CKGDP_DISPLAY(string IV_CJRQ, string IV_LGNUM)
        {
            return client.ZBCFUN_CKGDP_DISPLAY(IV_CJRQ, IV_LGNUM);
        }

        public ScreenInfo ScreenInfoRead(int ID)
        {
            return client.ScreenInfoRead(ID);
        }

        public int ScreenInfoUpdate(ScreenInfo node)
        {
            return client.ScreenInfoUpdate(node);
        }

        public IList<ScreenInfo> ScreenInfoRead()
        {
            return client.ScreenInfoReadALL();
        }

        public IList<ZSL_BCS107> ZBCFUN_LTPM_READ(string IV_LGNUM, string IV_JPD, string IV_CJRQ_S, string IV_CJRQ_E, string IV_VBELN)
        {
            return client.ZBCFUN_LTPM_READ(IV_LGNUM, IV_JPD, IV_CJRQ_S, IV_CJRQ_E, IV_VBELN);
        }

        public List<ZSL_BCS107> PickingListREAD(string IV_LGNUM, string IV_JPD, string IV_CJRQ_S, string IV_CJRQ_E, string IV_VBELN)
        {
            return client.PickingListREAD(IV_LGNUM, IV_JPD, IV_CJRQ_S, IV_CJRQ_E, IV_VBELN).ToList();
        }
        public MODEL_ZBCFUN_MAT_GET GET_ZBCFUN_MAT_GET(string IV_DATUM, string IV_MTART, string IV_MATNR, string IV_ZSBS, string ptoken)
        {
            return client.GET_ZBCFUN_MAT_GET(IV_DATUM, IV_MTART, IV_MATNR, IV_ZSBS, ptoken);
        }
        public MODEL_ZBCFUN_TM_READ GET_ZBCFUN_TM_READ(string IV_AUFNR, string IV_KZBEW, string ptoken)
        {
            return client.GET_ZBCFUN_TM_READ(IV_AUFNR, IV_KZBEW, ptoken);
        }
        public MODEL_ZBCFUN_THLOG_READ GET_ZBCFUN_THLOG_READ(string ptoken)
        {
            return client.GET_ZBCFUN_THLOG_READ(ptoken);
        }
        public MODEL_ZBCFUN_DLV_GET GET_ZBCFUN_DLV_GET(string IV_DATE, string ptoken)
        {
            return client.GET_ZBCFUN_DLV_GET(IV_DATE, ptoken);
        }
        public MODEL_ZBCFUN_DLV_GET GET_ZBCFUN_DLV_GET_CRM(string IV_DATE, string IV_SYS, string ptoken)
        {
            return client.GET_ZBCFUN_DLV_GET_CRM(IV_DATE, IV_SYS, ptoken);
        }
        public MODEL_ZBCFUN_CUS_GET GET_ZBCFUN_CUS_GET(string ptoken)
        {
            return client.GET_ZBCFUN_CUS_GET(ptoken);
        }
        public MODEL_ZBCFUN_ORT_GET GET_ZBCFUN_ORT_GET(string ptoken)
        {
            return client.GET_ZBCFUN_ORT_GET(ptoken);
        }
        public MODEL_ZBCFUN_DLV_GET GET_ZBCFUN_DLV_GET2(string KHmodeldata, string ptoken)
        {
            return client.GET_ZBCFUN_DLV_GET2(KHmodeldata, ptoken);
        }
        public MODEL_ZBCFUN_POITEM_READ GET_ZBCFUN_POITEM_READ(string IV_EBELN, string IV_EBELP, string ptoken)
        {
            return client.GET_ZBCFUN_POITEM_READ(IV_EBELN, IV_EBELP, ptoken);
        }
        public ZSL_BCST100 GET_ZBCFUN_PO_RECEIPT(string IV_CKDJH, string IV_KZBEW, string ptoken)
        {
            return client.GET_ZBCFUN_PO_RECEIPT(IV_CKDJH, IV_KZBEW, ptoken);
        }
        public MODEL_ZBCFUN_JHD_READ JHD_READ(string VBELN, string ptoken)
        {
            return client.JHD_READ(VBELN, ptoken);
        }
        public MES_RETURN JHD_UPDATE(ZSL_BCT110[] model, int STAFFID, string ptoken)
        {
            return client.JHD_UPDATE(model, STAFFID, ptoken);
        }
        public MODEL_ZBCFUN_JHZ_READ JHZ_READ(MODEL_ZBCFUN_JHZ_READ model, string ptoken)
        {
            return client.JHZ_READ(model, ptoken);
        }
    }
}
