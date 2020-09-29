using Sonluk.UI.Model.CRM.MSG_NOTICETTService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class MSG_NOTICE
    {
        private MSG_NOTICESoapClient client = new MSG_NOTICESoapClient("MSG_NOTICESoap", AppConfig.Settings("RemoteAddress") + "CRM/MSG_NOTICE.asmx");

        public int CreateTT(CRM_MSG_NOTICETT model, string ptoken)
        {
            return client.CreateTT(model, ptoken);
        }
        public int CreateMX(CRM_MSG_NOTICEMX model, string ptoken)
        {
            return client.CreateMX(model, ptoken);
        }
        public CRM_MSG_NOTICETTList[] ReadTT(CRM_MSG_NOTICETTParam model, string ptoken)
        {
            return client.ReadTT(model, ptoken);
        }
        public CRM_MSG_NOTICETTList ReadTTbyTTID(int NOTICETTID, string ptoken)
        {
            return client.ReadTTbyTTID(NOTICETTID, ptoken);
        }
        public CRM_MSG_NOTICEMXList_KH[] ReadMXbyTTID_KH(int NOTICETTID, string ptoken)
        {
            return client.ReadMXbyTTID_KH(NOTICETTID, ptoken);
        }
        public CRM_MSG_NOTICEMXList_STAFF[] ReadMXbyTTID_STAFF(int NOTICETTID, string ptoken)
        {
            return client.ReadMXbyTTID_STAFF(NOTICETTID, ptoken);
        }
        public int UpdateTT(CRM_MSG_NOTICETT model, string ptoken)
        {
            return client.UpdateTT(model, ptoken);
        }
        public int UpdateIsactive(int NOTICETTID, int ISACTIVE, string ptoken)
        {
            return client.UpdateIsactive(NOTICETTID, ISACTIVE, ptoken);
        }
        public int UpdateMX(CRM_MSG_NOTICEMX model, string ptoken)
        {
            return client.UpdateMX(model, ptoken);
        }
        public int DeleteTT(int NOTICETTID, string ptoken)
        {
            return client.DeleteTT(NOTICETTID, ptoken);
        }
        public int DeleteMX(int NOTICEMXID, string ptoken)
        {
            return client.DeleteMX(NOTICEMXID, ptoken);
        }
        public CRM_MSG_NOTICETTList[] ReadBySTAFFID(int STAFFID, int USERLX, string ptoken)
        {
            return client.ReadBySTAFFID(STAFFID, USERLX, ptoken);
        }
        public int AddCount(int NOTICETTID, int USERID, string ptoken)
        {
            return client.AddCount(NOTICETTID, USERID, ptoken);
        }
        public CRM_MSG_NOTICEMX[] ReadMXbyParam(CRM_MSG_NOTICEMX model, string ptoken)
        {
            return client.ReadMXbyParam(model, ptoken);
        }


    }
}
