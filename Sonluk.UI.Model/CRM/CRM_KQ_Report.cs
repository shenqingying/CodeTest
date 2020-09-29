using Sonluk.UI.Model.CRM.CRM_KQ_ReportService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class CRM_KQ_Report
    {
        private CRM_KQ_ReportSoapClient client = new CRM_KQ_ReportSoapClient("CRM_KQ_ReportSoap", AppConfig.Settings("RemoteAddress") + "CRM/CRM_KQ_Report.asmx");

        public CRM_KQ_COLLECTList[] CRM_KQ_REPORT_SUMMARY(int STAFFID,int DEPID,int STAFFLX, string STAFFNAME, string STAFFNO, string beginTime, string endTime,int OnlyQQ, string ptoken)
        {

            return client.CRM_KQ_REPORT_SUMMARY(STAFFID,DEPID,STAFFLX, STAFFNAME, STAFFNO, beginTime, endTime,OnlyQQ, ptoken);
           
        }
        public CRM_KQ_YGQJList[] CRM_KQ_Detail_QJ(int STAFFID, string Begintime, string Endtime, string ptoken)
        {

            return client.CRM_KQ_Detail_QJ(STAFFID, Begintime, Endtime,ptoken);
           

        }
      
        public CRM_KQ_CCTTList[] CRM_KQ_Detail_CC(int STAFFID, string Begintime, string Endtime, string ptoken)
        {

            return client.CRM_KQ_Detail_CC(STAFFID, Begintime, Endtime, ptoken);
           

        }
      
        public CRM_KQ_YCKQSM[] CRM_KQ_Detail_YC(int STAFFID, string Begintime, string Endtime, string ptoken)
        {

            return client.CRM_KQ_Detail_YC(STAFFID, Begintime, Endtime, ptoken);
           

        }
      
        public CRM_KQ_QDList[] CRM_KQ_Detail_QD(int STAFFID, string Begintime, string Endtime, string ptoken)
        {

            return client.CRM_KQ_Detail_QD(STAFFID, Begintime, Endtime, ptoken);
            

        }
       
        public CRM_KQ_QQList[] CRM_KQ_Detail_QQ(int STAFFID, string Begintime, string Endtime, string ptoken)
        {

            return client.CRM_KQ_Detail_QQ(STAFFID, Begintime, Endtime, ptoken);
          

        }
    }
}
