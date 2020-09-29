using Sonluk.UI.Model.HR.DA_DAINFOService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.HR
{
    public class DA_DAINFO
    {
        private DA_DAINFOSoapClient client = new DA_DAINFOSoapClient("DA_DAINFOSoap", AppConfig.Settings("RemoteAddress") + "HR/DA_DAINFO.asmx");
        public MES_RETURN_UI INSERT_DADM(HR_DA_DADM model, string ptoken)
        {
            MES_RETURN mr = client.INSERT_DADM(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_DA_DADM_SELECT SELECT_DADM(HR_DA_DADM model, string ptoken)
        {
            return client.SELECT_DADM(model, ptoken);
        }
        public MES_RETURN_UI UPDATE_DADM(HR_DA_DADM model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE_DADM(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI DELETE_DADM(int DADMID, string ptoken)
        {
            MES_RETURN mr = client.DELETE_DADM(DADMID, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI INSERT_DAINFO(HR_DA_DAINFO model, string ptoken)
        {
            MES_RETURN mr = client.INSERT_DAINFO(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TMSX = mr.TMSX;
            return mrui;
        }
        public HR_DA_DAINFO_SELECT SELECT_DAINFO(HR_DA_DAINFO model, string ptoken)
        {
            return client.SELECT_DAINFO(model, ptoken);
        }
        public MES_RETURN_UI UPDATE_DAINFO(HR_DA_DAINFO model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE_DAINFO(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI DELETE_DAINFO(int DAID, string ptoken)
        {
            MES_RETURN mr = client.DELETE_DAINFO(DAID, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI INSERT_DAJYJL(HR_DA_DAJYJL model, string ptoken)
        {
            MES_RETURN mr = client.INSERT_DAJYJL(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TMSX = mr.TMSX;
            return mrui;
        }
        public HR_DA_DAJYJL_SELECT SELECT_DAJYJL(HR_DA_DAJYJL model, string ptoken)
        {
            return client.SELECT_DAJYJL(model, ptoken);
        }
        public MES_RETURN_UI UPDATE_DAJYJL(HR_DA_DAJYJL model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE_DAJYJL(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
    }
}
