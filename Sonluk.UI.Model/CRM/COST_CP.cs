using Sonluk.UI.Model.CRM.COST_CPService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_CP
    {
        private COST_CPSoapClient client = new COST_CPSoapClient("COST_CPSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_CP.asmx");

        public int Create(CRM_COST_CP model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_CP model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_COST_CP[] ReadByParam(CRM_COST_CP model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int Delete(int CPID, string ptoken)
        {
            return client.Delete(CPID, ptoken);
        }
        public CRM_COST_CP_YEARDATA ReportYEARData(int LKAYEARTTID, int ISACTIVE, string ptoken)
        {
            return client.ReportYEARData(LKAYEARTTID, ISACTIVE, ptoken);
        }
        public CRM_COST_CP_JXSReport[] JXSReport(CRM_COST_CP_JXSReport model, int STAFFID, string ptoken)
        {
            return client.JXSReport(model, STAFFID, ptoken);
        }


    }
}
