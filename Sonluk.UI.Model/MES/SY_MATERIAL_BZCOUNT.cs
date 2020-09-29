using Sonluk.UI.Model.MES.SY_MATERIAL_BZCOUNTservice;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class SY_MATERIAL_BZCOUNT
    {
        private SY_MATERIAL_BZCOUNTSoapClient client = new SY_MATERIAL_BZCOUNTSoapClient("SY_MATERIAL_BZCOUNTSoap", AppConfig.Settings("RemoteAddress") + "MES/SY_MATERIAL_BZCOUNT.asmx");
        public MES_RETURN_UI INSERT(MES_SY_MATERIAL_BZCOUNT model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI DELETE(MES_SY_MATERIAL_BZCOUNT model, string ptoken)
        {
            MES_RETURN mr = client.DELETE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI UPDATE(MES_SY_MATERIAL_BZCOUNT model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_SY_MATERIAL_BZCOUNT_SELECT SELECT(MES_SY_MATERIAL_BZCOUNT model, string ptoken)
        {
            return client.SELECT(model, ptoken);
        }
        public MES_SY_MATERIAL_BZCOUNT_SELECT SELECT_LB(MES_SY_MATERIAL_BZCOUNT model, string ptoken)
        {
            return client.SELECT_LB(model, ptoken);
        }
    }
}
