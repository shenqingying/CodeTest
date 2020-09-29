using Sonluk.UI.Model.CRM.CRM_PENGDINGService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class CRM_PENGING
    {
        private CRM_PENDINGSoapClient client = new CRM_PENDINGSoapClient("CRM_PENDINGSoap", AppConfig.Settings("RemoteAddress") + "CRM/CRM_PENDING.asmx");

        public CRM_PENDING_SUMMARY[] Read_Summary(int STAFFID, string ptoken)
        {

            return client.Read_Summary(STAFFID, ptoken);
         

        }
        public CRM_PENDING_DETAIL[] Read_Detail(int STAFFID, int SummaryID, string ptoken)
        {
            return client.Read_Detail(STAFFID, SummaryID, ptoken);
        }
    }
}
