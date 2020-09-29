using Sonluk.UI.Model.MES.ROLE_CKService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class ROLE_CK
    {
        private ROLE_CKSoapClient client = new ROLE_CKSoapClient("ROLE_CKSoap", AppConfig.Settings("RemoteAddress") + "MES/ROLE_CK.asmx");
        public MES_RETURN_UI INSERT(MES_ROLE_CK[] model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
            //return client.INSERT(model, ptoken);
        }
        public MES_RETURN_UI DELETE(int ROLEID, string ptoken)
        {
            MES_RETURN mr = client.DELETE(ROLEID, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
            //return client.DELETE(ROLEID, ptoken);
        }
        public MES_ROLE_CK_LIST SELECT(int ROLEID, string ptoken)
        {
            return client.SELECT(ROLEID, ptoken);
        }
    }
}
