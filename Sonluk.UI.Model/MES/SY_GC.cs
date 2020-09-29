using Sonluk.UI.Model.MES.SY_GCService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class SY_GC
    {
        private SY_GCSoapClient client = new SY_GCSoapClient("SY_GCSoap", AppConfig.Settings("RemoteAddress") + "MES/SY_GC.asmx");
        public MES_SY_GC[] read(MES_SY_GC model, string ptoken)
        {
            return client.read(model, ptoken);
        }

        public MES_RETURN_UI delete(string GC, string ptoken)
        {
            MES_RETURN mr = client.delete(GC, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public MES_RETURN_UI UPDATE(MES_SY_GC model, string ptoken)
        {
            //return client.UPDATE(model, ptoken);
            MES_RETURN mr = client.UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI insert(MES_SY_GC model, string ptoken)
        {
            //return client.insert(model, ptoken);
            MES_RETURN mr = client.insert(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_SY_GC[] SELECT_BY_ROLE(MES_SY_GC model, string ptoken)
        {
            return client.SELECT_BY_ROLE(model, ptoken);
        }
        public MES_SY_GC_LAY_SELECT SELECT_LAY(int STAFFID, string ptoken)
        {
            return client.SELECT_LAY(STAFFID, ptoken);
        }
        public MES_SY_GC[] SELECT_ALLUSER()
        {
            MES_SY_GC model = new MES_SY_GC();
            model.ISACTION = 1;
            return client.SELECT_ALLUSER(model);
        }

    }
}
