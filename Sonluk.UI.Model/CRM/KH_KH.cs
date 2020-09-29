using Sonluk.UI.Model.CRM.KH_KHService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class KH_KH
    {
        private KH_KHSoapClient client = new KH_KHSoapClient("KH_KHSoap", AppConfig.Settings("RemoteAddress") + "CRM/KH_KH.asmx");


        public int Create(CRM_KH_KH KH_S, string ptoken)
        {
            return client.Create(KH_S, ptoken);
        }
        public int Update(CRM_KH_KH KH_S, string ptoken, bool isKHID)
        {
            return client.Update(KH_S, ptoken, isKHID);
        }
        public int UpdateSFCS(CRM_KH_KH KH, string ptoken)
        {
            return client.UpdateSFCS(KH, ptoken);
        }
        public CRM_KH_KH[] Read(CRM_KH_KH keywords, string ptoken)
        {
            return client.ReadByParmas(keywords, ptoken);
        }
        public CRM_KH_KHList Read(int KHID, string ptoken)
        {
            return client.ReadByID(KHID, ptoken);
        }
        public int Delete(int KHID, string ptoken)
        {
            return client.Delete(KHID, ptoken);
        }
        public CRM_KH_KHList[] Report(CRM_Report_KHModel model, int STAFFID, string ptoken)
        {
            return client.Report(model, STAFFID, ptoken);
        }
        public CRM_KH_KHList[] Report_PLUS(CRM_Report_KHModel model, int STAFFID, string ptoken)
        {
            return client.Report_PLUS(model, STAFFID, ptoken);
        }
        public CRM_KH_KH_Report_ZDWDList[] Report_ZDWD(CRM_KH_KH_Report_ZDWD model, int STAFFID, string ptoken)
        {
            return client.Report_ZDWD(model, STAFFID, ptoken);
        }

        public CRM_KH_KH_Report_LKAList[] Report_LKA(CRM_KH_KH_Report_LKA model, int STAFFID, int RightOn, string ptoken)
        {
            return client.Report_LKA(model, STAFFID, RightOn, ptoken);
        }
        public string[] ReadXSZZ(string ptoken)
        {
            return client.ReadXSZZ(ptoken);
        }
        public CRM_KH_BankList[] Blank_Report(int SFID, int CSID, string ptoken)
        {
            return client.Blank_Report(SFID, CSID, ptoken);
        }

        public CRM_KH_KH ReadByCRMID(string CRMID, string ptoken)
        {

            return client.ReadByCRMID(CRMID, ptoken);


        }
        public CRM_KH_KH_INFO[] ReadBF_KHList(CRM_KH_KH_PARAM model, string ptoken)
        {

            return client.ReadBF_KHList(model, ptoken);

        }
        public SAP_KH[] ReadKHForSap(int STAFFID, string ptoken)
        {

            return client.ReadKHForSap(STAFFID, ptoken);

        }
        public CRM_KH_KHList[] ReadBySTAFFID(int STAFFID, string ptoken)
        {
            return client.ReadBySTAFFID(STAFFID, ptoken);
        }
        public CRM_KH_KH ReadJXSByKHID(int KHID, string ptoken)
        {
            return client.ReadJXSByKHID(KHID, ptoken);
        }
        public CRM_KH_KH[] ReadByJXS(CRM_KH_KH model, string ptoken)
        {
            return client.ReadByJXS(model, ptoken);
        }

        public CRM_KH_KHList[] ReadUser_KH(CRM_Report_KHModel model, string ptoken)
        {
            return client.ReadUser_KH(model, ptoken);
        }
        public CRM_KH_KH[] ReadSDFbyPKH(string SAPSN, string ptoken)
        {
            return client.ReadSDFbyPKH(SAPSN, ptoken);
        }
        public CRM_KH_KH ReadBySAPSN(string SAPSN, string ptoken)
        {
            return client.ReadBySAPSN(SAPSN, ptoken);
        }
        public CRM_KH_KHList[] ReadKHAcount(CRM_Report_KHModel model, string ptoken)
        {
            return client.ReadKHAcount(model, ptoken);
        }

    }
}
