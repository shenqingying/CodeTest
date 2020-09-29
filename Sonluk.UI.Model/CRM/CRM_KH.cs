using Sonluk.UI.Model.CRM;
using Sonluk.UI.Model.CRM.CRM_KHService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class CRM_KH
    {
        private CRM_KHSoapClient client = new CRM_KHSoapClient("CRM_KHSoap", AppConfig.Settings("RemoteAddress") + "CRM/CRM_KH.asmx");
        public int InsertKH_KH(CRM_KH_KH KH_S)          //新增客户信息
        {
            return client.InsertKH_KH(KH_S);
        }
        public CRM_KH_KH[] SelectKH_KH(string id)       //
        {
            return client.SelectKH_KH(id);
        }
        public string SelectKH_KHForKHLXandMC(int KHLX, string mc, int MCLC)       //查询上级客户
        {
            return client.SelectKH_KHForKHLXandMC(KHLX, mc,MCLC);
        }

        public int ModifyKH_KH(CRM_KH_KH KH_S)          //修改客户信息
        {
            return client.ModifyKH_KH(KH_S);
        }
        public string SelectKHReportWithReportModel(CRM_Report_KHModel model)       //查询客户列表
        {
            return client.SelectReportWithReportModel(model);
        }

        public int InsertKH_KHQTXX(CRM_KH_KHQTXX model) // 新增客户其他信息
        {
            return client.InsertKH_KHQTXX(model);
        }
        public string SelectKH_KHQTXX(int KHID, int XXLB, int ISACTIVE) //查询客户其他信息
        {
            return client.SelectKH_KHQTXX(KHID, XXLB, ISACTIVE);
        }

        public int InsertClXX(CRM_KH_KHQTXX model, int GSDX, string ml)
        {
            return client.InsertClXX(model, GSDX, ml);
        }
    }
}
