using Sonluk.UI.Model.CRM.WX_OPENIDService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class WX_OPENID
    {
        private WX_OPENIDSoapClient client = new WX_OPENIDSoapClient("WX_OPENIDSoap", AppConfig.Settings("RemoteAddress") + "CRM/WX_OPENID.asmx");
        public int Create(CRM_WX_OPENID model, string USE, string ptoken)
        {

            return client.Create(model, USE, ptoken);



        }

        public int Update(CRM_WX_OPENID model, string ptoken)
        {

            return client.Update(model, ptoken);


        }
        public int DeleteByID(int ID, string ptoken)
        {
            return client.DeleteByID(ID, ptoken);
        }
        public int Delete(CRM_WX_OPENID model, string ptoken)
        {

            return client.Delete(model, ptoken);


        }
        public CRM_WX_OPENID[] ReadByParam(CRM_WX_OPENID model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public CRM_WX_OPENIDList[] ReadBySTAFFParam(CRM_WX_OPENIDList model, string ptoken)
        {
            return client.ReadBySTAFFParam(model, ptoken);
        }
        public CRM_WX_OPENIDList[] ReadByORDERTTID(int ORDERTTID, string ptoken)
        {
            return client.ReadByORDERTTID(ORDERTTID, ptoken);
        }
        public WX_MSG_RETURN SendMSG(int STAFFID, WX_MSG WXMSG, string SYS, string TYPE)
        {
            return client.SendMSG(STAFFID, WXMSG, SYS, TYPE);
        }
    }
}
