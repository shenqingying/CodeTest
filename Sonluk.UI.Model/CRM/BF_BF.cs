using Sonluk.UI.Model.CRM.BF_BFService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class BF_BF
    {
        private BF_BFSoapClient client = new BF_BFSoapClient("BF_BFSoap", AppConfig.Settings("RemoteAddress") + "CRM/BF_BF.asmx");
        public int Create_BFDJ(CRM_BF_BFDJ model, string ptoken)
        {

            return client.Create_BFDJ(model, ptoken);

           

        }
        
        public int Update_BFDJ(CRM_BF_BFDJ model, string ptoken)
        {

            return client.Update_BFDJ(model, ptoken);
           

        }
       
        public int Delete_BFDJ(int BFDJID, string ptoken)
        {

            return client.Delete_BFDJ(BFDJID, ptoken);
          

        }
      

        public int Create_BFJH(CRM_BF_BFJH model, string ptoken)
        {

            return client.Create_BFJH(model, ptoken);
          

        }
       
        public int Update_BFJH(CRM_BF_BFJH model, string ptoken)
        {

            return client.Update_BFJH(model, ptoken);
          

        }
      
        public int Delete_BFJH(int BFJHID, string ptoken)
        {

            return client.Delete_BFJH(BFJHID, ptoken);
           

        }

        //public CRM_BF_BFJHList[] Read_BFJH(CRM_BF_BFJH model, string ptoken)
        //{


        //    return client.Report_BFJH(model,ptoken);
           
        //}


        public CRM_BF_STAFFList[] Report_STAFF(CRM_BF_STAFFList model, string ptoken)
        {


            return client.Report_STAFF(model,ptoken);
           
        }
       
        public CRM_BF_KHList[] Report_KH(CRM_BF_KHList model, string ptoken)
        {
           
            return client.Report_KH(model,ptoken);
          

        }
        public CRM_BF_BFDJList[] Report_BFDJ(CRM_BF_BFDJList model, string ptoken)
        {


            return client.Report_BFDJ(model,ptoken);
           

        }

        public CRM_BF_BFDJ ReadByBFDJID(int BFDJID, string ptoken)
        {

            return client.ReadByBFDJID(BFDJID,ptoken);
            ;

        }

        public CRM_BF_REPORTSUMMARY[] Report_Summary(CRM_BF_ReportParam model, string ptoken)
        {

            return client.Report_Summary(model,ptoken);
          

        }
       
        public CRM_BF_REPORTDETAIL[] Report_Detail(CRM_BF_ReportParam model, string ptoken)
        {

            return client.Report_Detail(model,ptoken);
           

        }
        public CRM_BF_BFJHList[] ReadByParams(int BFLX, string BFJHMC, string FROMDATE, string TODATE,int STAFFID, string ptoken)
        {

            return client.ReadByParams(BFLX, BFJHMC, FROMDATE, TODATE,STAFFID,ptoken);
          

        }

    
        public CRM_BF_BFJH Read_BFJDByID(int BFJHID, string ptoken)
        {

            return client.Read_BFJDByID(BFJHID,ptoken);
          

        }
        public CRM_BF_BFDJList[] Read(CRM_BF_BFDJ_PARAMS model,int isGun, string ptoken)
        {

            return client.Read(model, isGun, ptoken);
           

        }
        public CRM_KHDJ_REPORT_SUMMARY[] ReadKHBF_BFDJ_SUMMARY(CRM_KHDJ_REPORT_PARAMS model, string ptoken)
        {

            return client.ReadKHBF_BFDJ_SUMMARY(model, ptoken);
          
        }
       
        public CRM_KHDJ_REPORT_DETAIL[] ReadKHBF_BFDJ_DETAIL(CRM_KHDJ_REPORT_PARAMS model, string ptoken)
        {

            return client.ReadKHBF_BFDJ_DETAIL(model,ptoken);
          
            
        }
        public CRM_BF_REPORT_BYSTAFF_SUMMARYTOTAL[] ReadKHBF_ReportByStaff_SummaryTotal(CRM_BF_REPORT_BYSTAFF_PARAMS model, string ptoken)
        {

            return client.ReadKHBF_ReportByStaff_SummaryTotal(model, ptoken);


        }
        public CRM_BF_REPORT_BYSTAFF_SUMMARY[] ReadKHBF_ReportByStaff_Summary(CRM_BF_REPORT_BYSTAFF_PARAMS model, string ptoken)
        {

            return client.ReadKHBF_ReportByStaff_Summary(model, ptoken);


        }
        public CRM_BF_BFDJList[] ReadKHBF_ReportByStaff_Detail(CRM_BF_REPORT_BYSTAFF_PARAMS model, string ptoken)
        {

            return client.ReadKHBF_ReportByStaff_Detail(model, ptoken);


        }
        public DataTable ReadKHBF_ReportByDate_Summary(CRM_BF_REPORT_BYSTAFF_PARAMS model, string ptoken)
        {
            return client.ReadKHBF_ReportByDate_Summary(model, ptoken);
        }
    }
}
