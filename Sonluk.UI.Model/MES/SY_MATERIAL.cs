using Sonluk.UI.Model.MES.SY_MATERIALService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class SY_MATERIAL
    {
        private SY_MATERIALSoapClient client = new SY_MATERIALSoapClient("SY_MATERIALSoap", AppConfig.Settings("RemoteAddress") + "MES/SY_MATERIAL.asmx");
        public MES_RETURN_UI INSERT(MES_SY_MATERIAL model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI DELETE(MES_SY_MATERIAL model, string ptoken)
        {
            MES_RETURN mr = client.DELETE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI UPDATE(MES_SY_MATERIAL model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_SY_MATERIAL_SELECT SELECT(MES_SY_MATERIAL model, string ptoken)
        {
            model.ISACTION = 0;
            return client.SELECT(model, ptoken);
        }
        public MES_SY_MATERIAL_SELECT SELECT_ACTION(MES_SY_MATERIAL model, string ptoken)
        {
            model.ISACTION = 1;
            return client.SELECT(model, ptoken);
        }
        public MES_SY_MATERIAL_SELECT SELECT_BY_GZZX(MES_SY_MATERIAL model, string ptoken)
        {
            return client.SELECT_BY_GZZX(model, ptoken);
        }
        public MES_SY_MATERIAL_DW_SELECT DW_SELECT(MES_SY_MATERIAL_DW model, string ptoken)
        {
            return client.DW_SELECT(model, ptoken);
        }
        public MES_SY_MATERIAL_SELECT SELECT_LB(MES_SY_MATERIAL model, string ptoken)
        {
            return client.SELECT_LB(model, ptoken);
        }
    }
}
