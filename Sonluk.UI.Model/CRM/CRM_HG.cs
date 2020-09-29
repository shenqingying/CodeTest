using Sonluk.UI.Model.CRM.CRM_HGService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class CRM_HG
    {
        private CRM_HGSoapClient client = new CRM_HGSoapClient("CRM_HGSoap", AppConfig.Settings("RemoteAddress") + "CRM/CRM_HG.asmx");
        public CRM_HG_DICT[] SelectHG_DICTwithTYPEID(int typeID, int fid)
        {
            return client.SelectHG_DICTwithTYPEID(typeID,fid);
        }
    }
}
