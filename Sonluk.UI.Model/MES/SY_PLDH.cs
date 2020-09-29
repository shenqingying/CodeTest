using Sonluk.UI.Model.MES.SY_PLDHService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class SY_PLDH
    {
        private SY_PLDHSoapClient client = new SY_PLDHSoapClient("SY_PLDHSoap", AppConfig.Settings("RemoteAddress") + "MES/SY_PLDH.asmx");
        public MES_SY_PLDH_SELECT SELECT_LIST(MES_SY_PLDH model, string ptoken)
        {
            return client.SELECT_LIST(model, ptoken);
        }
        public MES_SY_PLDH_SELECT SELECT(MES_SY_PLDH model, string ptoken)
        {
            return client.SELECT(model, ptoken);
        }
        public MES_RETURN_UI PLDH_SBBH_INSERT(MES_SY_PLDH_SBBH model, string ptoken)
        {
            MES_RETURN mr = client.PLDH_SBBH_INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI PLDH_SBBH_UPDATE(MES_SY_PLDH_SBBH model, string ptoken)
        {
            MES_RETURN mr = client.PLDH_SBBH_UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_SY_PLDH_SBBH_SELECT PLDH_SBBH_SELECT(MES_SY_PLDH_SBBH model, string ptoken)
        {
            return client.PLDH_SBBH_SELECT(model, ptoken);
        }
        public MES_RETURN_UI INSERT_PLDH_PH(MES_SY_PLDH_PH model, string ptoken)
        {
            MES_RETURN mr = client.INSERT_PLDH_PH(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_SY_PLDH_PH_SELECT SELECT_PLDH_PH(MES_SY_PLDH_PH model, string ptoken)
        {
            return client.SELECT_PLDH_PH(model, ptoken);
        }
        public MES_SY_PLDH_PH_SELECT SELECT_PLDH_PH_LB(MES_SY_PLDH_PH model, string ptoken)
        {
            return client.SELECT_PLDH_PH_LB(model, ptoken);
        }
        public MES_RETURN_UI INSERT(MES_SY_PLDH model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.GC = mr.GC;
            mrui.BH = mr.BH;
            return mrui;
        }
        public MES_RETURN_UI UPDATE(MES_SY_PLDH model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
    }
}
