using Sonluk.UI.Model.CRM.COST_ZZFTTService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_ZZFTT
    {
        private COST_ZZFTTSoapClient client = new COST_ZZFTTSoapClient("COST_ZZFTTSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_ZZFTT.asmx");

        public int Create(CRM_COST_ZZFTT model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_ZZFTT model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_COST_ZZFTT[] ReadByParam(CRM_COST_ZZFTT model,int STAFFID, string ptoken)
        {
            return client.ReadByParam(model,STAFFID, ptoken);
        }
        public CRM_COST_ZZFTT[] Read_KA(CRM_COST_ZZFTT model,int STAFFID, string ptoken)
        {
            return client.Read_KA(model,STAFFID, ptoken);
        }
        public CRM_COST_ZZFTT[] Read_LKA(CRM_COST_ZZFTT model, int STAFFID, string ptoken)
        {
            return client.Read_LKA(model,STAFFID, ptoken);
        }
        public CRM_COST_ZZFTT[] ReadByCostitemid(CRM_COST_ZZFTT model, string ptoken)
        {
            return client.ReadByCostitemid(model, ptoken);
        }
        public CRM_COST_ZZFTT[] Read_LKAUnconnected(CRM_COST_ZZFTT model, string ptoken)
        {
            return client.Read_LKAUnconnected(model, ptoken);
        }
        public CRM_COST_ZZFTT[] Read_KAUnconnected(CRM_COST_ZZFTT model, string ptoken)
        {
            return client.Read_KAUnconnected(model, ptoken);
        }
       
        public int Delete(int TTID, string ptoken)
        {
            return client.Delete(TTID, ptoken);
        }
        public CRM_COST_ZZFTT[] Read_Unconnected(CRM_COST_ZZFTT model, string ptoken)
        {
            return client.Read_Unconnected(model, ptoken);
        }
        public CRM_COST_ZZFTT[] Read_Unconnected2(CRM_COST_ZZFTT model, string ptoken)
        {
            return client.Read_Unconnected2(model, ptoken);
        }
        public CRM_COST_ZZFTT[] ReadByTSCLF(CRM_COST_ZZFTT model, string ptoken)
        {
            return client.ReadByTSCLF(model, ptoken);
        }
    }
}
