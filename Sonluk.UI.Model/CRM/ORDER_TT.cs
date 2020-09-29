using Sonluk.UI.Model.CRM.ORDER_TTService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class ORDER_TT
    {
        private ORDER_TTSoapClient client = new ORDER_TTSoapClient("ORDER_TTSoap", AppConfig.Settings("RemoteAddress") + "CRM/ORDER_TT.asmx");


        public int CreateTT(CRM_ORDER_TT model, string ptoken)
        {
            return client.CreateTT(model, ptoken);
        }
        public int CreateMX(CRM_ORDER_MX model, string ptoken)
        {
            return client.CreateMX(model, ptoken);
        }
        public int UpdateTT(CRM_ORDER_TT model, string ptoken)
        {
            return client.UpdateTT(model, ptoken);
        }
        public int UpdateTT_KHinfo(CRM_ORDER_TT model, string ptoken)
        {
            return client.UpdateTT_KHinfo(model, ptoken);
        }
        public int UpdateTT_BJ(CRM_ORDER_TT model, string ptoken)
        {
            return client.UpdateTT_BJ(model, ptoken);
        }
        public int UpdateMX(CRM_ORDER_MX model, string ptoken)
        {
            return client.UpdateMX(model, ptoken);
        }
        public int UpdateMX_WLinfo(CRM_ORDER_MX model, int STAFFID, string ptoken)
        {
            return client.UpdateMX_WLinfo(model, STAFFID, ptoken);
        }
        public int DeleteTT(int ORDERTTID, string which, string ptoken)
        {
            return client.DeleteTT(ORDERTTID, which, ptoken);
        }
        public int AddPrintCount(int ORDERTTID, string ptoken)
        {
            return client.AddPrintCount(ORDERTTID, ptoken);
        }
        public int DeleteMX(int ORDERMXID,int XGR, string ptoken)
        {
            return client.DeleteMX(ORDERMXID, XGR, ptoken);
        }
        public int DeleteMXbyFItem(CRM_ORDER_MX model, int STAFFID, string ptoken)
        {
            return client.DeleteMXbyFItem(model, STAFFID, ptoken);
        }
        public CRM_ORDER_TT ReadTTbyID(int ORDERTTID, string ptoken)
        {
            return client.ReadTTbyID(ORDERTTID, ptoken);
        }
        public CRM_ORDER_TT[] ReadTTbyParam(CRM_ORDER_TT model, int STAFFID, int forCopy, int isGun, string ptoken)
        {
            return client.ReadTTbyParam(model, STAFFID, forCopy, isGun, ptoken);
        }
        public CRM_ORDER_MX[] ReadMXbyParam(CRM_ORDER_MX model, string ptoken)
        {
            return client.ReadMXbyParam(model, ptoken);
        }
        public CRM_ORDER_MX[] ReadMXbyTTID(int ORDERTTID, string ptoken)
        {
            return client.ReadMXbyTTID(ORDERTTID, ptoken);
        }
        public int UpdateOrderIsactive(int ORDERTTID, int ISACTIVE, string ptoken)
        {
            return client.UpdateOrderIsactive(ORDERTTID, ISACTIVE, ptoken);
        }
        public int UpdateOrder_SAPORDER(CRM_ORDER_TT model, string ptoken)
        {
            return client.UpdateOrder_SAPORDER(model, ptoken);
        }
        public int UpdateOrder_LOCK(int ORDERTTID, int ISLOCK, string ptoken)
        {
            return client.UpdateOrder_LOCK(ORDERTTID, ISLOCK, ptoken);
        }
        public CRM_ORDER_MX ReadMXbyMXID(int ORDERMXID, string ptoken)
        {
            return client.ReadMXbyMXID(ORDERMXID, ptoken);
        }



    }
}
