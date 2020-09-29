using Sonluk.UI.Model.CRM.BC_FXCHService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class BC_FXCH
    {
        private BC_FXCHSoapClient client = new BC_FXCHSoapClient("BC_FXCHSoap", AppConfig.Settings("RemoteAddress") + "CRM/BC_FXCH.asmx");

        public int TTCreate(CRM_BC_FXCHTT model, string ptoken)
        {
            return client.TTCreate(model, ptoken);
        }
        public int MXCreate(CRM_BC_FXCHMX model, string ptoken)
        {
            return client.MXCreate(model, ptoken);
        }
        public int TTDelete(int FXCHTTID, string ptoken)
        {
            return client.TTDelete(FXCHTTID, ptoken);
        }
        public int MXDelete(int FXCHMXID, string ptoken)
        {
            return client.MXDelete(FXCHMXID, ptoken);
        }
        public CRM_BC_FXCHTTList[] ReadTTbyParam(CRM_BC_FXCHParam model, string ptoken)
        {
            return client.ReadTTbyParam(model, ptoken);
        }
        public CRM_BC_FXCHMX[] ReadMXbyTTID(int FXCHTTID, string ptoken)
        {
            return client.ReadMXbyTTID(FXCHTTID, ptoken);
        }
        public CRM_BC_FXCHMX[] ReadMXbyParam(CRM_BC_FXCHMX model, string ptoken)
        {
            return client.ReadMXbyParam(model, ptoken);
        }
        public int ReadCountByDXM(string DXM, string TPM, string ptoken)
        {
            return client.ReadCountByDXM(DXM, TPM, ptoken);
        }
        public int Verify_IfHaveKHRight(int STAFFID, string CRMID, string ptoken)
        {
            return client.Verify_IfHaveKHRight(STAFFID, CRMID, ptoken);
        }
        public int Verify_IfHaveCHRight(int STAFFID, string DXM, string TPM, string ptoken)
        {
            return client.Verify_IfHaveCHRight(STAFFID, DXM, TPM, ptoken);
        }
        public CRM_BC_FXCHTTList ReadTTbyTTID(int FXCHTTID, string ptoken)
        {
            return client.ReadTTbyTTID(FXCHTTID, ptoken);
        }
        public CRM_BC_FXCHTTList[] Report(CRM_BC_FXCHParam model, string ptoken)
        {
            return client.Report(model, ptoken);
        }
        public int MXDeleteByDXM(string DXM, string ptoken)
        {
            return client.MXDeleteByDXM(DXM, ptoken);
        }


    }
}
