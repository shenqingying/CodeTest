using Sonluk.UI.Model.CRM.COST_KAXSService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_KAXS
    {
        private COST_KAXSSoapClient client = new COST_KAXSSoapClient("COST_KAXSSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_KAXS.asmx");

        public int Create(CRM_COST_KAXS model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_KAXS model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_COST_KAXS[] ReadByParam(CRM_COST_KAXS model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public CRM_COST_KAXS_Report_MXFH[] Report_MXFH(CRM_COST_KAXS_Report_MXFH model, string ptoken)
        {
            return client.Report_MXFH(model, ptoken);
        }
        public CRM_COST_KAXSReportMX[] Report_MX(CRM_COST_KAXSReportMX model, string ptoken)
        {
            return client.Report_MX(model, ptoken);
        }
        public CRM_COST_KAXS[] Report(CRM_COST_KAXS model, string ptoken)
        {
            return client.Report(model, ptoken);
        }
        public CRM_COST_KAXSReportKP[] Report_KP(CRM_COST_KAXSReportKP model, string ptoken)
        {
            return client.Report_KP(model, ptoken);
        }
        public CRM_COST_KAXSReportFH[] Report_FH(CRM_COST_KAXSReportFH model, string ptoken)
        {
            return client.Report_FH(model, ptoken);
        }
        public int Delete(int KAXSID, string ptoken)
        {
            return client.Delete(KAXSID, ptoken);
        }
        public CRM_COST_KAXSReport_Compare[] Report_Compare(CRM_COST_KAXSReport_Compare model, string ptoken)
        {
            return client.Report_Compare(model, ptoken);
        }
    }
}
