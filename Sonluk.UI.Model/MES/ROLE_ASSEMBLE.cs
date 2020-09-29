using Sonluk.UI.Model.MES.ROLE_ASSEMBLEService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class ROLE_ASSEMBLE
    {
        private ROLE_ASSEMBLESoapClient client = new ROLE_ASSEMBLESoapClient("ROLE_ASSEMBLESoap", AppConfig.Settings("RemoteAddress") + "MES/ROLE_ASSEMBLE.asmx");

        public MES_RETURN_UI INSERT(MES_ROLE_ASSEMBLE model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
            //return client.INSERT(model, ptoken);
        }

        public MES_RETURN_UI UPDATE(MES_ROLE_ASSEMBLE model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
            //return client.UPDATE(model, ptoken);
        }

        public MES_ROLE_ASSEMBLE_SELECT SELECT(MES_ROLE_ASSEMBLE model, string ptoken)
        {
            return client.SELECT(model, ptoken);
        }

        public MES_ROLE_ASSEMBLE_SELECT SELECT_LB(MES_ROLE_ASSEMBLE model, string ptoken)
        {
            return client.SELECT_LB(model, ptoken);
        }

        public MES_RETURN_UI DELETE(int ID, string ptoken)
        {
            MES_RETURN mr = client.DELETE(ID, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
            //return client.DELETE(ID, ptoken);
        }
        public MES_ROLE_ASSEMBLE_JS_LAY_SELECT SELECT_JS_LAY(int STAFFID, string ptoken)
        {
            return client.SELECT_JS_LAY(STAFFID, ptoken);
        }
        public MES_ROLE_ASSEMBLE_LAY_SELECT SELECT_LAY(int STAFFID, int ROLELB, string ptoken)
        {
            return client.SELECT_LAY(STAFFID, ROLELB, ptoken);
        }
        public MES_RETURN_UI INSERT_JS(MES_ROLE_ASSEMBLE_JS_LAY[] model, string ptoken)
        {
            MES_RETURN mr = client.INSERT_JS(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI DELETE_JS(int STAFFID, string ptoken)
        {
            MES_RETURN mr = client.DELETE_JS(STAFFID, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
    }
}
