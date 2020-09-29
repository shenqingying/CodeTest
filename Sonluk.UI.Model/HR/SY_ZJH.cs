using Sonluk.UI.Model.HR.SY_ZJHService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.HR
{
    public class SY_ZJH
    {
        private SY_ZJHSoapClient client = new SY_ZJHSoapClient("SY_ZJHSoap", AppConfig.Settings("RemoteAddress") + "HR/SY_ZJH.asmx");
        public HR_SY_ZJH_SELECT SELECT(HR_SY_ZJH model, string ptoken)
        {
            return client.SELECT(model, ptoken);
        }
        public MES_RETURN_UI UPDATE(HR_SY_ZJH model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI INSERT(HR_SY_ZJH model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TID = mr.TID;
            return mrui;
        }
        public MES_RETURN_UI DELETE(int ZJHID, string ptoken)
        {
            MES_RETURN mr = client.DELETE(ZJHID, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_SY_ZJH_LAY_SELECT SELECT_ZJH_LAY(int ZJHID, string GS, string ptoken)
        {
            return client.SELECT_ZJH_LAY(ZJHID, GS, ptoken);
        }
        public MES_RETURN_UI INSERT_ZJH_LAY(HR_SY_ZJH_LAY model, string ptoken)
        {
            MES_RETURN mr = client.INSERT_ZJH_LAY(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI DELETE_ZJH_LAY(int ZJHID, string ptoken)
        {
            MES_RETURN mr = client.DELETE_ZJH_LAY(ZJHID, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_SY_ZJH_LAY_SELECT SELECT_ZJH_ROLE_LAY(int STAFFID, string ptoken)
        {
            return client.SELECT_ZJH_ROLE_LAY(STAFFID, ptoken);
        }
        public MES_RETURN_UI INSERT_ZJH_ROLE_LAY(HR_SY_ZJH_LAY model, string ptoken)
        {
            MES_RETURN mr = client.INSERT_ZJH_ROLE_LAY(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI DELETE_ZJH_ROLE_LAY(int STAFFID, string ptoken)
        {
            MES_RETURN mr = client.DELETE_ZJH_ROLE_LAY(STAFFID, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_SY_ZJH_LAY_SELECT SELECT_BY_ROLE(int STAFFID, string GS, string ptoken)
        {
            return client.SELECT_BY_ROLE(STAFFID, GS, ptoken);
        }
    }
}
