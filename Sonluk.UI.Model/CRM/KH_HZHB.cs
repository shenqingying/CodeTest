using Sonluk.UI.Model.CRM.KH_HZHBService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class KH_HZHB
    {
        private KH_HZHBSoapClient client = new KH_HZHBSoapClient("KH_HZHBSoap", AppConfig.Settings("RemoteAddress") + "CRM/KH_HZHB.asmx");
       
        public int Create(CRM_KH_HZHB model, string ptoken)
        {
            return client.Create(model,ptoken);
        }
       
        public int SapDataSynchronization(string CRMID, string SAPSN, string ptoken)
        {
            return  client.SapDataSynchronization(CRMID,SAPSN, ptoken);
        }

        public CRM_KH_HZHBLIST[] Read(string SAPSN, string ptoken)
        {
            return client.Read(SAPSN,ptoken);
        }

        public SAP_HZHBList ReadSAPHZHB(string SAPSN, string ptoken)
        {
            return client.ReadSAPHZHB(SAPSN, 0, ptoken);
        }
        public CRM_KH_XSQYSJ ReadBySAPSN(string SAPSN, string ptoken)
        {
            return client.ReadBySAPSN(SAPSN, ptoken);
        }
        public SAP_HZHBList SyncSapRead(SAP_KH[] t_KH, int khlx, string ptoken)
        {
            return client.SyncSapRead(t_KH, khlx, ptoken);
        }

    }
}
