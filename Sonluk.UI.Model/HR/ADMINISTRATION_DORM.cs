using Sonluk.UI.Model.HR.ADMINISTRATION_DORMService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.HR
{
    public class ADMINISTRATION_DORM
    {
        private WS_HR_ADMINISTRATION_DORMSoapClient client = new WS_HR_ADMINISTRATION_DORMSoapClient("WS_HR_ADMINISTRATION_DORMSoap", AppConfig.Settings("RemoteAddress") + "HR/WS_HR_ADMINISTRATION_DORM.asmx");
        public MES_RETURN_UI INSERT(HR_ADMINISTRATION_DORM_DORM model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TID = mr.TID;
            return mrui;
        }
        public MES_RETURN_UI UPDATE(HR_ADMINISTRATION_DORM_DORM model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_ADMINISTRATION_DORM_DORM_SELECT SELECT(HR_ADMINISTRATION_DORM_DORM model, string ptoken)
        {
            return client.SELECT(model, ptoken);
        }

        public MES_RETURN_UI LIVE_INSERT(HR_ADMINISTRATION_DORM_LIVE model, string ptoken)
        {
            MES_RETURN mr = client.LIVE_INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TID = mr.TID;
            return mrui;
        }
        public MES_RETURN_UI LIVE_UPDATE(HR_ADMINISTRATION_DORM_LIVE model, string ptoken)
        {
            MES_RETURN mr = client.LIVE_UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_ADMINISTRATION_DORM_LIVE_SELECT LIVE_SELECT(HR_ADMINISTRATION_DORM_LIVE model, string ptoken)
        {
            return client.LIVE_SELECT(model, ptoken);
        }

        public MES_RETURN_UI ROOM_INSERT(HR_ADMINISTRATION_DORM_ROOM model, string ptoken)
        {
            MES_RETURN mr = client.ROOM_INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TID = mr.TID;
            return mrui;
        }
        public MES_RETURN_UI ROOM_UPDATE(HR_ADMINISTRATION_DORM_ROOM model, string ptoken)
        {
            MES_RETURN mr = client.ROOM_UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_ADMINISTRATION_DORM_ROOM_SELECT ROOM_SELECT(HR_ADMINISTRATION_DORM_ROOM model, string ptoken)
        {
            return client.ROOM_SELECT(model, ptoken);
        }
    }
}
