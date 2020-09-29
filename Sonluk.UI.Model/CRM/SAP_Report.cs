using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sonluk.Utility;
using Sonluk.UI.Model.CRM.SAP_ReportService;

namespace Sonluk.UI.Model.CRM
{
    public class SAP_Report
    {
        private SAP_ReportSoapClient client = new SAP_ReportSoapClient("SAP_ReportSoap", AppConfig.Settings("RemoteAddress") + "CRM/SAP_Report.asmx");

        public SAP_Invoice[] Invoice(int STAFFID, SAP_Invoice_Param model, string ptoken)
        {
            return client.Invoice(STAFFID, model, ptoken);
        }
        public SAP_ReportInfo[] AC(string customer, string dateStart, string dateEnd, string ptoken)
        {
            return client.AC(customer, dateStart, dateEnd, ptoken);
        }
        public SAP_ReportInfo[] SHFH(string customer, string dateStart, string dateEnd, string ptoken)
        {
            return client.SHFH(customer, dateStart, dateEnd, ptoken);
        }
        public SAP_ReportInfo[] ZKMX(string customer, string dateStart, string dateEnd, string ptoken)
        {
            return client.ZKMX(customer, dateStart, dateEnd, ptoken);
        }
        public string SAP_CPFL(string I_MATNR, string ptoken)
        {
            return client.SAP_CPFL(I_MATNR, ptoken);
        }
        public SAP_RWJDInfo SAP_RWJD(string customer, string year, string dateStart, string dateEnd, string ptoken)
        {
            return client.SAP_RWJD(customer, year, dateStart, dateEnd, ptoken);
        }
        public SAP_RWXSInfo SAP_RWXS(string customer, string dateStart, string dateEnd, string ptoken)
        {
            return client.SAP_RWXS(customer, dateStart, dateEnd, ptoken);
        }
        public SAP_RWJD2Info SAP_RWJD2(string customer, string dateStart, string dateEnd, string[] MATNR, string ptoken)
        {
            return client.SAP_RWJD2(customer, dateStart, dateEnd, MATNR, ptoken);
        }
        public ZSD_JXSKP[] GET_JXSKP(string STARTDATE, string ENDDATE, ZSD_JXSKP[] data, string ptoken)
        {
            return client.GET_JXSKP(STARTDATE, ENDDATE, data, ptoken);
        }

    }
}
