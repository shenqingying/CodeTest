using Sonluk.UI.Model.CRM.BC_PMLISTService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class BC_PMLIST
    {
        private BC_PMLISTSoapClient client = new BC_PMLISTSoapClient("BC_PMLISTSoap", AppConfig.Settings("RemoteAddress") + "CRM/BC_PMLIST.asmx");


        public int Create(CRM_BC_PMLIST model, string ptoken)
        {

            return client.Create(model, ptoken);
        }
        public CRM_BC_PMLIST[] SelectByModel(CRM_BC_PMLIST model, string BEGIN_DATE, string END_DATE, string ptoken)
        {

            return client.SelectByModel(model, BEGIN_DATE, END_DATE, ptoken);
        }
        public CRM_BC_PMLISTList[] SelectGD(CRM_BC_PMLIST model, string BEGIN_DATE, string END_DATE, string ptoken)
        {

            return client.SelectGD(model, BEGIN_DATE, END_DATE, ptoken);
        }
        public CRM_BC_PMLISTList[] SelectByGD(string AUFNR, string ptoken)
        {

            return client.SelectByGD(AUFNR, ptoken);
        }
        public CRM_BC_PMLISTList[] SelectByGDandParam(CRM_BC_PMLIST model, string BEGIN_DATE, string END_DATE, string ptoken)
        {
            return client.SelectByGDandParam(model, BEGIN_DATE, END_DATE, ptoken);
        }
        public CRM_BC_PMLISTList SelectByDXM(string DXM, string ptoken)
        {

            return client.SelectByDXM(DXM, ptoken);
        }
        public CRM_BC_PMLISTList[] SelectOtherBigByDXM(string DXM, string ptoken)
        {
            return client.SelectOtherBigByDXM(DXM, ptoken);
        }
        public int Delete(int PMID, string ptoken)
        {

            return client.Delete(PMID, ptoken);
        }
        public int DeleteByGD(string AUFNR, string ptoken)
        {
            return client.DeleteByGD(AUFNR, ptoken);
        }
        public int UpdatePM(string ptoken)
        {
            return client.UpdatePM(ptoken);
        }
        public CRM_BC_PMLIST[] SelectMATNRbyCHARGandPM(CRM_BC_PMLIST model, string ptoken)
        {
            return client.SelectMATNRbyCHARGandPM(model, ptoken);
        }
        public CRM_BC_KH[] SelectKHbyMCP(CRM_BC_PMLIST model, string ptoken)
        {
            return client.SelectKHbyMCP(model, ptoken);
        }
        public CRM_BC_KH[] SelectKHbyDXM(CRM_BC_PMLIST model, string ptoken)
        {
            return client.SelectKHbyDXM(model, ptoken);
        }
        public CRM_BC_KH[] SelectKHbyNHM(CRM_BC_CHMX model, string ptoken)
        {
            return client.SelectKHbyNHM(model, ptoken);
        }
        public int Create_WLM(CRM_BC_WLM_TEMP model, string ptoken)
        {
            return client.Create_WLM(model, ptoken);
        }
        public int Delete_WLM(string ptoken)
        {
            return client.Delete_WLM(ptoken);
        }
        public int Modify_WLM(string ptoken)
        {
            return client.Modify_WLM(ptoken);
        }

    }
}
