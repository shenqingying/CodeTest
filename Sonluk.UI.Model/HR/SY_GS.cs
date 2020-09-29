using Sonluk.UI.Model.HR.SY_GSService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.HR
{
    public class SY_GS
    {
        private SY_GSSoapClient client = new SY_GSSoapClient("SY_GSSoap", AppConfig.Settings("RemoteAddress") + "HR/SY_GS.asmx");
        public MES_RETURN_UI INSERT(HR_SY_GS model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_SY_GS_SELECT SELECT(HR_SY_GS model, string ptoken)
        {
            return client.SELECT(model, ptoken);
        }
        public MES_RETURN_UI UPDATE(HR_SY_GS model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI DELETE(HR_SY_GS model, string ptoken)
        {
            MES_RETURN mr = client.DELETE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI UPDATE_YYZZ(HR_SY_GS model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE_YYZZ(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_SY_GS_LAY_SELECT SELECT_GS_ROLE_LAY(int STAFFID, string ptoken)
        {
            return client.SELECT_GS_ROLE_LAY(STAFFID, ptoken);
        }
        public MES_RETURN_UI INSERT_GS_ROLE_LAY(HR_SY_GS_LAY model, string ptoken)
        {
            MES_RETURN mr = client.INSERT_GS_ROLE_LAY(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI DELETE_GS_ROLE_LAY(int STAFFID, string ptoken)
        {
            MES_RETURN mr = client.DELETE_GS_ROLE_LAY(STAFFID, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_SY_GS_SELECT SELECT_BY_ROLE(int STAFFID, string ptoken)
        {
            return client.SELECT_BY_ROLE(STAFFID, ptoken);
        } 
    }
}
