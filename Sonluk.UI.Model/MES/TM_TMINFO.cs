using Sonluk.UI.Model.MES.TM_TMINFOService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class TM_TMINFO
    {
        private TM_TMINFOSoapClient client = new TM_TMINFOSoapClient("TM_TMINFOSoap", AppConfig.Settings("RemoteAddress") + "MES/TM_TMINFO.asmx");
        public SELECT_MES_TM_TMINFO_BYTM SELECT_BYTM(MES_TM_TMINFO model, int ISINSERT, string ptoken)
        {
            return client.SELECT_BYTM(model, ISINSERT, 1, ptoken);
        }

        public SELECT_MES_TM_TMINFO_BYTM SELECT_BYTM_YT(MES_TM_TMINFO model, int ISINSERT, string ptoken)
        {
            return client.SELECT_BYTM(model, ISINSERT, 2, ptoken);
        }
        public MES_TM_TMINFO_INSERT_RETURN INSERT(MES_TM_TMINFO_INSERT_GL model, int ISAUTOADD, string ptoken)
        {
            MES_TM_TMINFO_INSERT_RETURN rst = client.INSERT(model, ISAUTOADD, ptoken);
            return rst;
        }

        public SELECT_MES_TM_TMINFO_PRINT SELECT_BYID_CHILD(string GC, string TM, string ptoken)
        {
            return client.SELECT_BYID_CHILD(GC, TM, ptoken);
        }

        public SELECT_MES_TM_TMINFO_BYTM SELECT_TL_LAST(string RWBH, string ptoken)
        {
            return client.SELECT_TL_LAST(RWBH, ptoken);
        }

        public MES_RETURN_UI DELETE(string TM, string ptoken)
        {
            MES_RETURN mr = client.DELETE(TM, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI DELETE_LOG(MES_TM_TMINFO_DELETE_IN model, string ptoken)
        {
            MES_RETURN mr = client.DELETE_LOG(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public SELECT_MES_TM_TMINFO_BYTM SELECT_WLKCBS(MES_WLKCBS_GETWLZJ_IN model, string ptoken)
        {
            return client.SELECT_WLKCBS(model, ptoken);
        }
        public SELECT_MES_TM_TMINFO_BYTM SELECT(MES_TM_TMINFO model, string ptoken)
        {
            return client.SELECT(model, 0, ptoken);
        }
        public SELECT_MES_TM_TMINFO_BYTM SELECT_ALL(MES_TM_TMINFO model, string ptoken)
        {
            return client.SELECT_ALL(model, 0, ptoken);
        }

        public SELECT_MES_TM_TMINFO_BYTM SELECT_ZFDC(MES_TM_TMINFO model, string ptoken)
        {
            return client.SELECT(model, 1, ptoken);
        }
        public SELECT_MES_TM_TMINFO_BYTM SELECT_TPM(MES_TM_TMINFO model, string ptoken)
        {
            return client.SELECT(model, 2, ptoken);
        }

        public SELECT_MES_TM_TMINFO_BYTM SELECT_GLSELECT(MES_TM_TMINFO_LIST[] model, string ptoken)
        {
            return client.SELECT_GLSELECT(model, ptoken);
        }
        public SELECT_MES_TM_TMINFO_BYTM SELECT_GLSELECT_ALL(MES_TM_TMINFO_LIST[] model, string ptoken)
        {
            return client.SELECT_GLSELECT_ALL(model, ptoken);
        }

        public MES_RETURN_UI UPDATE(MES_TM_TMINFO model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, 1, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TM = mr.TM;
            mrui.TMSX = mr.TMSX;
            mrui.GC = mr.GC;
            return mrui;
        }
        public MES_RETURN_UI UPDATE_LB(MES_TM_TMINFO model, int LB, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, LB, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TM = mr.TM;
            mrui.TMSX = mr.TMSX;
            mrui.GC = mr.GC;
            return mrui;
        }
        public MES_RETURN_UI UPDATE_LIST_LB(MES_TM_TMINFO[] model, int LB, string ptoken)
        {
            MES_RETURN mr = client.UPDATE_LIST(model, LB, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TM = mr.TM;
            mrui.TMSX = mr.TMSX;
            mrui.GC = mr.GC;
            return mrui;
        }
        public MES_RETURN_UI UPDATE_CPZT(MES_TM_TMINFO[] model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE_CPZT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TM = mr.TM;
            mrui.TMSX = mr.TMSX;
            mrui.GC = mr.GC;
            return mrui;
        }
        public MES_RETURN_UI VERIFY_TPMTH(string OLDTPM, string NEWTPM, string ptoken)
        {
            MES_RETURN mr = client.VERIFY_TPMTH(OLDTPM, NEWTPM, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public MES_RETURN_UI UPDATE_ZFDC(MES_TM_TMINFO model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, 3, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TM = mr.TM;
            mrui.TMSX = mr.TMSX;
            mrui.GC = mr.GC;
            return mrui;
        }
        public SELECT_MES_TM_TMINFO_BYTM SELECT_BY_ROLE(MES_TM_TMINFO model, string ptoken)
        {
            return client.SELECT_BY_STAFFID(model, 0, ptoken);
        }
        public SELECT_MES_TM_TMINFO_BYTM SELECT_BY_KCDDLimit(MES_TM_TMINFO model, string ptoken)
        {
            return client.SELECT_BY_KCDDLimit(model, ptoken);
        }
        public SELECT_MES_TM_TMINFO_BYTM SELECT_ZFDC_BY_ROLE(MES_TM_TMINFO model, string ptoken)
        {
            return client.SELECT_BY_STAFFID(model, 1, ptoken);
        }
        public SELECT_MES_TM_TMINFO_BYTM SELECT_BY_UPDATEROLE(MES_TM_TMINFO_SELECT_BY_UPDATEROLE_IN model, string ptoken)
        {
            return client.SELECT_BY_UPDATEROLE(model, ptoken);
        }
        public MES_TM_TMINFO_SELECT_TL_GL_CC SELECT_TL_GL_CC(MES_TM_TMINFO model, string ptoken)
        {
            return client.SELECT_TL_GL_CC(model, ptoken);
        }
        public MES_TM_TMINFO_XCTMINFO GET_XCTMINFO_BY_TMLIST(MES_PD_TL_SELECT_REPORT_LIST[] model, string ptoken)
        {
            return client.GET_XCTMINFO_BY_TMLIST(model, ptoken);
        }
        public MES_RETURN_UI SELECT_TM_LASTTIME(MES_TM_TMINFO model, string ptoken)
        {
            MES_RETURN mr = client.SELECT_TM_LASTTIME(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TM = mr.TM;
            mrui.TMSX = mr.TMSX;
            mrui.GC = mr.GC;
            return mrui;
        }
        public MES_RETURN_UI INSERT_ONLY(MES_TM_TMINFO model, string ptoken)
        {
            MES_RETURN mr = client.INSERT_ONLY(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TM = mr.TM;
            mrui.TMSX = mr.TMSX;
            mrui.GC = mr.GC;
            return mrui;
        }
        public MES_RETURN_UI INSERT_ZS_WLKCBS(MES_TM_TMINFO_INSERT_GL model, string ptoken)
        {
            MES_RETURN mr = client.INSERT_ZS_WLKCBS(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TM = mr.TM;
            mrui.TMSX = mr.TMSX;
            mrui.GC = mr.GC;
            return mrui;
        }
        public MES_RETURN_UI DELETE_ZS_WLKCBS(MES_TM_TMINFO[] model, string ptoken)
        {
            MES_RETURN mr = client.DELETE_ZS_WLKCBS(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TM = mr.TM;
            mrui.TMSX = mr.TMSX;
            mrui.GC = mr.GC;
            return mrui;
        }
        public MES_RETURN_UI ZS_WLKCBS_MOVE(MES_TM_TMINFO[] model, string RKTEXT, string ptoken)
        {
            MES_RETURN mr = client.ZS_WLKCBS_MOVE(model, RKTEXT, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TM = mr.TM;
            mrui.TMSX = mr.TMSX;
            mrui.GC = mr.GC;
            return mrui;
        }
        public MES_RETURN_UI ZS_WLKCBS_CK(MES_TM_TMINFO[] model, int KHID, string JLMS, string ptoken)
        {
            MES_RETURN mr = client.ZS_WLKCBS_CK(model, KHID, JLMS, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TM = mr.TM;
            mrui.TMSX = mr.TMSX;
            mrui.GC = mr.GC;
            return mrui;
        }
        public MES_RETURN_UI ZS_FGDJ(MES_TM_TMINFO[] model, string JLMS, string ptoken)
        {
            MES_RETURN mr = client.ZS_FGDJ(model, JLMS, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TM = mr.TM;
            mrui.TMSX = mr.TMSX;
            mrui.GC = mr.GC;
            return mrui;
        }
        public MES_RETURN_UI ZS_THDJ(MES_TM_TMINFO[] model, int KHID, string JLMS, string ptoken)
        {
            MES_RETURN mr = client.ZS_THDJ(model, KHID, JLMS, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TM = mr.TM;
            mrui.TMSX = mr.TMSX;
            mrui.GC = mr.GC;
            return mrui;
        }
        public SELECT_MES_TM_TMINFO_BYTM SELECT_KC(MES_TM_TMINFO model, string ptoken)
        {
            return client.SELECT_KC_TT(model, ptoken);
        }
        public SELECT_MES_TM_TMINFO_BYTM SELECT_LIST(MES_TM_TMINFO_LIST[] model, MES_TM_TMINFO model1, string ptoken)
        {
            return client.SELECT_LIST(model, model1, ptoken);
        }
        public SELECT_MES_TM_TMINFO_BYTM SELECT_LIST_datatable(MES_TM_TMINFO_LIST[] model, MES_TM_TMINFO model1, string ptoken)
        {
            return client.SELECT_LIST_datatable(model, model1, ptoken);
        }
        public SELECT_MES_TM_TMINFO_BYTM SELECT_LB(MES_TM_TMINFO model, string ptoken)
        {
            return client.SELECT_LB(model, ptoken);
        }
        public MES_RETURN_UI UPDATE_CF(MES_TM_TMINFO model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE_CF(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TM = mr.TM;
            mrui.TMSX = mr.TMSX;
            mrui.GC = mr.GC;
            return mrui;
        }
        public SELECT_MES_TM_TMINFO_PRINT_LIST SELECT_PRINT_RKBS(string ptoken, string printinfo)
        {
            return client.SELECT_PRINT_RKBS(ptoken, printinfo, 0);
        }
    }
}
