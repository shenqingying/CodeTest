using Sonluk.UI.Model.CRM.COST_PSFService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class COST_PSF
    {
        private COST_PSFSoapClient client = new COST_PSFSoapClient("COST_PSFSoap", AppConfig.Settings("RemoteAddress") + "CRM/COST_PSF.asmx");

        public int Create(CRM_COST_PSF model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(CRM_COST_PSF model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_COST_PSF[] ReadByParam(CRM_COST_PSF model, int STAFFID, string ptoken)
        {
            return client.ReadByParam(model, STAFFID, ptoken);
        }
        public CRM_COST_PSF[] ReportWLGS(CRM_COST_PSF model, string ptoken)
        {
            return client.ReportWLGS(model, ptoken);
        }
        public CRM_COST_PSF[] ReportJXS(CRM_COST_PSF model, string ptoken)
        {
            return client.ReportJXS(model, ptoken);
        }
        public CRM_COST_PSF[] Read_Unconnected(CRM_COST_PSF model, string ptoken)
        {
            return client.Read_Unconnected(model, ptoken);
        }
        public int Delete(int PSFID, string ptoken)
        {
            return client.Delete(PSFID, ptoken);
        }
        public int AddPrintCount(int PSFID, string ptoken)
        {
            return client.AddPrintCount(PSFID, ptoken);
        }




    }
}
