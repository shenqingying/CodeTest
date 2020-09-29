using Sonluk.UI.Model.CRM.BC_CHTTService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class BC_CHTT
    {
        private BC_CHTTSoapClient client = new BC_CHTTSoapClient("BC_CHTTSoap", AppConfig.Settings("RemoteAddress") + "CRM/BC_CHTT.asmx");

        public int Modify(string ptoken)
        {
            return client.Modify(ptoken);
        }
        public int SelectMXIDbyDXM(string DXM, string ptoken)
        {
            return client.SelectMXIDbyDXM(DXM, ptoken);
        }
        public string SelectKUNAGbyTTID(int PMCHTTID, string ptoken)
        {
            return client.SelectKUNAGbyTTID(PMCHTTID, ptoken);
        }
        public CRM_BC_CHMX[] SelectCHMXbyDXM(string DXM, string TPM, string ptoken)
        {
            return client.SelectCHMXbyDXM(DXM, TPM, ptoken);
        }
        public CRM_BC_CHMX[] ReadMXbyParam(CRM_BC_CHMX model, string ptoken)
        {
            return client.ReadMXbyParam(model, ptoken);
        }
        public CRM_BC_CHMX[] ReadDXMbyTPM(string TPM, string ptoken)
        {
            return client.ReadDXMbyTPM(TPM, ptoken);
        }

    }
}
