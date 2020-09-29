using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sonluk.UI.Model.CRM.SAP_ORDERService;
using Sonluk.Utility;

namespace Sonluk.UI.Model.CRM
{
    public class SAP_ORDER
    {
        private SAP_ORDERSoapClient client = new SAP_ORDERSoapClient("SAP_ORDERSoap", AppConfig.Settings("RemoteAddress") + "CRM/SAP_ORDER.asmx");

        public SAP_CompanyInfo[] ShipToParty(string customer, string salesOrganization, string distributionChannel, string division, string ptoken)
        {
            return client.ShipToParty(customer, salesOrganization, distributionChannel, division, ptoken);
        }
        public decimal SAP_Price(string serialNumber, string customer, string salesOrganization, string distributionChannel, string ptoken)
        {
            return client.SAP_Price(serialNumber, customer, salesOrganization, distributionChannel, ptoken);
        }
        public SAP_DiscountInfo[] SAP_Discount(string customer, string ptoken)
        {
            return client.SAP_Discount(customer, ptoken);
        }
        public decimal SAP_Balance(string customer, string ptoken)
        {
            return client.SAP_Balance(customer, ptoken);
        }
        public string Create(SAP_SOInfo node, string ptoken)
        {
            return client.Create(node, ptoken);
        }
        public MaterialUnitInfo[] UnitConversion(string material, string unit, string ptoken)
        {
            return client.UnitConversion(material, unit, ptoken);
        }

    }
}
