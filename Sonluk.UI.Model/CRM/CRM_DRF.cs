using Sonluk.UI.Model.CRM.CRM_DRFService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class CRM_DRF
    {
        private CRM_DRFSoapClient client = new CRM_DRFSoapClient("CRM_DRFSoap", AppConfig.Settings("RemoteAddress") + "CRM/CRM_DRF.asmx");
        public byte[] DownloadPDF(string path, string ptoken)
        {
            return client.downloadPDF(path);
        }
        public CRM_DRF_RETURNMSG status(int account)
        {
            return client.status(account);
        }
        public CRM_DRF_RETURNMSG setAuth(string auth, int account)
        {
            return client.setAuth(auth, account);
        }
        public byte[] SCREENSHOT(int shotlb)
        {
            return client.SCREENSHOT(shotlb);
        }
        public CRM_ORDER_DRF_USER_SELECT SELECT_USER_SYNC(CRM_ORDER_DRF_USER model, string ptoken)
        {
            return client.SELECT_USER_SYNC(model, ptoken);
        }
    }
}
