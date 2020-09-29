using Sonluk.UI.Model.EM.SY_MANUALBBService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.EM
{
    public class SY_MANUALBB
    {
        private SY_MANUALBBSoapClient client = new SY_MANUALBBSoapClient("SY_MANUALBBSoap", AppConfig.Settings("RemoteAddress") + "EM/SY_MANUALBB.asmx");
        public MES_RETURN_UI Create(EM_SY_MANUALBB model, string ptoken)
        {
            MES_RETURN mr = client.Create(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI Update(EM_SY_MANUALBB model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public EM_SY_MANUALBB[] Read(EM_SY_MANUALBB model, string ptoken)
        {
            return client.Read(model, ptoken);
        }
        public MES_RETURN_UI Delete(int ID, string ptoken)
        {
            MES_RETURN mr = client.DELETE(ID, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
    }
}
