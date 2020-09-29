using Sonluk.UI.Model.MES.MM_CKService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class MM_CK
    {
        private MM_CKSoapClient client = new MM_CKSoapClient("MM_CKSoap", AppConfig.Settings("RemoteAddress") + "MES/MM_CK.asmx");
        public MES_RETURN_UI INSERT(MES_MM_CK model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI UPDATE_SYNC(MES_MM_CK model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE_SYNC(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_MM_CK_SELECT SELECT(MES_MM_CK model, string ptoken)
        {
            model.ISACTION = 0;
            return client.SELECT(model, ptoken);
        }

        public MES_MM_CK_SELECT SELECT_USER(MES_MM_CK model, string ptoken)
        {
            model.ISACTION = 1;
            return client.SELECT(model, ptoken);
        }
        public MES_MM_CK_SELECT SELECT_BY_STAFFID(MES_MM_CK model, string ptoken)
        {
            return client.SELECT_BY_STAFFID(model, ptoken);
        }
        public MES_MM_CK_SELECT SELECT_BY_ROLE_ASSEMBLE(MES_MM_CK model, string ptoken)
        {
            return client.SELECT_BY_ROLE_ASSEMBLE(model, ptoken);
        }
    }
}
