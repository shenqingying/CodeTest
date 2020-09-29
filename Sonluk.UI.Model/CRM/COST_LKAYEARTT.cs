using Sonluk.UI.Model.CRM.COST_LKAYEARTTService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_LKAYEARTT
    {
        private COST_LKAYEARTTSoapClient client = new COST_LKAYEARTTSoapClient("COST_LKAYEARTTSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_LKAYEARTT.asmx");

        public int Create(CRM_COST_LKAYEARTT model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_LKAYEARTT model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public int UpdateStatus(CRM_COST_LKAYEARTT model, string ptoken)
        {
            return client.UpdateStatus(model, ptoken);
        }
        public CRM_COST_LKAYEARTT[] ReadByParam(CRM_COST_LKAYEARTT model, int STAFFID, string ptoken)
        {
            return client.ReadByParam(model, STAFFID, ptoken);
        }
        public int Delete(int LKAYEARTTID, string ptoken)
        {
            return client.Delete(LKAYEARTTID, ptoken);
        }
        public int Verify(CRM_COST_LKAYEARTT model, string ptoken)
        {
            return client.Verify(model, ptoken);
        }
        public CRM_COST_LKAYEARTT_JXS[] ReportJXS(int LKAYEARTTID, string ptoken)
        {
            return client.ReportJXS(LKAYEARTTID, ptoken);
        }
        public CRM_COST_LKAYearReport[] Report_TaiZhang(CRM_COST_LKAYearReport model, string ptoken)
        {
            return client.Report_TaiZhang(model, ptoken);
        }
        public CRM_COST_LKAYEARTT_Report[] Report(CRM_COST_LKAYEARTT_Report model, string ptoken)
        {
            return client.Report(model,  ptoken);
        }
    }
}
