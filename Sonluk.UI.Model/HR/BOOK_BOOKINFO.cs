using Sonluk.UI.Model.HR.BOOK_BOOKINFOService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.HR
{
    public class BOOK_BOOKINFO
    {
        private BOOK_BOOKINFOSoapClient client = new BOOK_BOOKINFOSoapClient("BOOK_BOOKINFOSoap", AppConfig.Settings("RemoteAddress") + "HR/BOOK_BOOKINFO.asmx");
        public MES_RETURN_UI INSERT_BOOKINFO(HR_BOOK_BOOKINFO model, string ptoken)
        {
            MES_RETURN mr = client.INSERT_BOOKINFO(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_BOOK_BOOKINFO_SELECT SELECT_BOOKINFO(HR_BOOK_BOOKINFO model, string ptoken)
        {
            return client.SELECT_BOOKINFO(model, ptoken);
        }
        public MES_RETURN_UI UPDATE_BOOKINFO(HR_BOOK_BOOKINFO model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE_BOOKINFO(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI LOGOUT_BOOKINFO(HR_BOOK_BOOKINFO model, string ptoken)
        {
            MES_RETURN mr = client.LOGOUT_BOOKINFO(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI JY_BOOK(HR_BOOK_BOOKINFO model, string ptoken)
        {
            MES_RETURN mr = client.JY_BOOK(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI GH_BOOK(HR_BOOK_BOOKINFO model, string ptoken)
        {
            MES_RETURN mr = client.GH_BOOK(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_BOOK_BOOKINFO_SELECT SELECT_BOOK_LOOK(HR_BOOK_BOOKINFO model, string ptoken)
        {
            return client.SELECT_BOOK_LOOK(model, ptoken);
        }
        public HR_BOOK_BOOKINFO_SELECT SELECT_BOOK_LOOK_JY(HR_BOOK_BOOKINFO model, string ptoken)
        {
            return client.SELECT_BOOK_LOOK_JY(model, ptoken);
        }
    }
}
