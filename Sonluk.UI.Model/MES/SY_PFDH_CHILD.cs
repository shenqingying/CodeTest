using Sonluk.UI.Model.MES.SY_PFDH_CHILDService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class SY_PFDH_CHILD
    {
        private SY_PFDH_CHILDSoapClient client = new SY_PFDH_CHILDSoapClient("SY_PFDH_CHILDSoap", AppConfig.Settings("RemoteAddress") + "MES/SY_PFDH_CHILD.asmx");
        public MES_RETURN_UI INSERT(MES_SY_PFDH_CHILD model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI INSERT(MES_SY_PFDH_CHILD[] model, string ptoken)
        {
            MES_RETURN mr = client.INSERT_LIST(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI DELETE_WLH(MES_SY_PFDH_CHILD model, string ptoken)
        {
            MES_RETURN mr = client.DELETE(model, 1, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI DELETE_PFDH(MES_SY_PFDH_CHILD model, string ptoken)
        {
            MES_RETURN mr = client.DELETE(model, 2, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_SY_PFDH_CHILD_SELECT SELECT(MES_SY_PFDH_CHILD model, string ptoken)
        {
            return client.SELECT(model, ptoken);
        }
    }
}
