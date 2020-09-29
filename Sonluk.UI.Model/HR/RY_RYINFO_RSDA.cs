using Sonluk.UI.Model.HR.RY_RYINFO_RSDAService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.HR
{
    public class RY_RYINFO_RSDA
    {
        private RY_RYINFO_RSDASoapClient client = new RY_RYINFO_RSDASoapClient("RY_RYINFO_RSDASoap", AppConfig.Settings("RemoteAddress") + "HR/RY_RYINFO_RSDA.asmx");
        public HR_RY_JYJL_SELECT JYJL_SELECT(HR_RY_JYJL model, string ptoken)
        {
            return client.JYJL_SELECT(model, ptoken);
        }
        public MES_RETURN_UI JYJL_INSERT(HR_RY_JYJL model, string ptoken)
        {
            MES_RETURN mr = client.JYJL_INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI JYJL_UPDATE(HR_RY_JYJL model, string ptoken)
        {
            MES_RETURN mr = client.JYJL_UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI JYJL_DELETE(int EDUID, string ptoken)
        {
            MES_RETURN mr = client.JYJL_DELETE(EDUID, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_RY_GRJL_SELECT GRJL_SELECT(HR_RY_GRJL model, string ptoken)
        {
            return client.GRJL_SELECT(model, ptoken);
        }
        public MES_RETURN_UI GRJL_INSERT(HR_RY_GRJL model, string ptoken)
        {
            MES_RETURN mr = client.GRJL_INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI GRJL_UPDATE(HR_RY_GRJL model, string ptoken)
        {
            MES_RETURN mr = client.GRJL_UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI GRJL_DELETE(int GRJLID, string ptoken)
        {
            MES_RETURN mr = client.GRJL_DELETE(GRJLID, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_RY_HOMEGX_SELECT HOMEGX_SELECT(HR_RY_HOMEGX model, string ptoken)
        {
            return client.HOMEGX_SELECT(model, ptoken);
        }
        public MES_RETURN_UI HOMEGX_INSERT(HR_RY_HOMEGX model, string ptoken)
        {
            MES_RETURN mr = client.HOMEGX_INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI HOMEGX_UPDATE(HR_RY_HOMEGX model, string ptoken)
        {
            MES_RETURN mr = client.HOMEGX_UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI HOMEGX_DELETE(int JTGXID, string ptoken)
        {
            MES_RETURN mr = client.HOMEGX_DELETE(JTGXID, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI GSGL_INSERT(HR_RY_GSGL model, string ptoken)
        {
            MES_RETURN mr = client.GSGL_INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_RY_GSGL_SELECT GSGL_SELECT(HR_RY_GSGL model, string ptoken)
        {
            return client.GSGL_SELECT(model, ptoken);
        }
        public MES_RETURN_UI GSGL_UPDATE(HR_RY_GSGL model, string ptoken)
        {
            MES_RETURN mr = client.GSGL_UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI GSGL_DELETE(int GSID, string ptoken)
        {
            MES_RETURN mr = client.GSGL_DELETE(GSID, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI WJGL_INSERT(HR_RY_WJGL model, string ptoken)
        {
            MES_RETURN mr = client.WJGL_INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_RY_WJGL_SELECT WJGL_SELECT(HR_RY_WJGL model, string ptoken)
        {
            return client.WJGL_SELECT(model, ptoken);
        }
        public MES_RETURN_UI WJGL_UPDATE(HR_RY_WJGL model, string ptoken)
        {
            MES_RETURN mr = client.WJGL_UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI WJGL_DELETE(int WJID, string ptoken)
        {
            MES_RETURN mr = client.WJGL_DELETE(WJID, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI HT_INSERT(HR_RY_HT model, string ptoken)
        {
            MES_RETURN mr = client.HT_INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_RY_HT_SELECT HT_SELECT(HR_RY_HT model, string ptoken)
        {
            return client.HT_SELECT(model, ptoken);
        }
        public MES_RETURN_UI HT_UPDATE(HR_RY_HT model, string ptoken)
        {
            MES_RETURN mr = client.HT_UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI HT_UPDATE_HTQCS(HR_RY_HT model, string ptoken)
        {
            MES_RETURN mr = client.HT_UPDATE_HTQCS(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI HT_DELETE(int HTID, string ptoken)
        {
            MES_RETURN mr = client.HT_DELETE(HTID, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI ZC_INSERT(HR_RY_ZC model, string ptoken)
        {
            MES_RETURN mr = client.ZC_INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_RY_ZC_SELECT ZC_SELECT(HR_RY_ZC model, string ptoken)
        {
            return client.ZC_SELECT(model, ptoken);
        }
        public HR_RY_ZC_SELECT RY_ZC_SELECT(HR_RY_ZC model, string ptoken)
        {
            return client.RY_ZC_SELECT(model, ptoken);
        }
        public MES_RETURN_UI ZC_UPDATE(HR_RY_ZC model, string ptoken)
        {
            MES_RETURN mr = client.ZC_UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI ZC_DELETE(int ZCID, string ptoken)
        {
            MES_RETURN mr = client.ZC_DELETE(ZCID, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI WBZW_INSERT(HR_RY_WBZW model, string ptoken)
        {
            MES_RETURN mr = client.WBZW_INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_RY_WBZW_SELECT WBZW_SELECT(HR_RY_WBZW model, string ptoken)
        {
            return client.WBZW_SELECT(model, ptoken);
        }
        public MES_RETURN_UI WBZW_UPDATE(HR_RY_WBZW model, string ptoken)
        {
            MES_RETURN mr = client.WBZW_UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI WBZW_DELETE(int WBZWID, string ptoken)
        {
            MES_RETURN mr = client.WBZW_DELETE(WBZWID, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
    }
}
