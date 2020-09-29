using Sonluk.UI.Model.HR.RY_RYINFOService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.HR
{
    public class RY_RYINFO
    {
        private RY_RYINFOSoapClient client = new RY_RYINFOSoapClient("RY_RYINFOSoap", AppConfig.Settings("RemoteAddress") + "HR/RY_RYINFO.asmx");
        public HR_RY_RYINFO_SELECT INSERT(HR_RY_RYINFO model, string ptoken)
        {
            return client.INSERT(model, ptoken);
        }
        public HR_RY_RYINFO_SELECT SELECT(HR_RY_RYINFO model, string ptoken)
        {
            return client.SELECT(model, ptoken);
        }
        public MES_RETURN_UI UPDATE(HR_RY_RYINFO model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI UPDATE_ALL(HR_RY_RYINFO model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE_ALL(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI UPDATE_PIC(HR_RY_RYINFO model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE_PIC(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI UPDATE_CHECK(HR_RY_RYINFO model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE_CHECK(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI UPDATE_YGTYPE(HR_RY_RYINFO[] model, int YGTYPE, int ZZZT, string ptoken)
        {
            MES_RETURN mr = client.UPDATE_YGTYPE(model, YGTYPE, ZZZT, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI UPDATE_DEPT(HR_RY_RYINFO[] model, int DEPT, int GSBM, string ptoken)
        {
            MES_RETURN mr = client.UPDATE_DEPT(model, DEPT, GSBM, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI UPDATE_JOBS(HR_RY_RYINFO[] model, int JOBS, string ptoken)
        {
            MES_RETURN mr = client.UPDATE_JOBS(model, JOBS, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI UPDATE_QUIT(HR_RY_RYINFO model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE_QUIT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI UPDATE_CHANGEINFO(HR_RY_RYINFO_CHANGEINFO model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE_CHANGEINFO(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI UPDATE_ISINGH(HR_RY_RYINFO model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE_ISINGH(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI UPDATE_DUTYNAME(HR_RY_RYINFO model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE_DUTYNAME(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_RY_RYINFO_SELECT SELECT_GSGL(HR_RY_RYINFO model, string ptoken)
        {
            return client.SELECT_GSGL(model, ptoken);
        }
        public HR_RY_RYINFO_SELECT SELECT_WJGL(HR_RY_RYINFO model, string ptoken)
        {
            return client.SELECT_WJGL(model, ptoken);
        }
        public HR_RY_RYINFO_SELECT SELECT_WBZW(HR_RY_RYINFO model, string ptoken)
        {
            return client.SELECT_WBZW(model, ptoken);
        }
        public MES_RETURN_UI INSERT_RONGY(HR_RY_RONGY model, string ptoken)
        {
            MES_RETURN mr = client.INSERT_RONGY(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TID = mr.TID;
            return mrui;
        }
        public HR_RY_RONGY_SELECT SELECT_RONGY(HR_RY_RONGY model, string ptoken)
        {
            return client.SELECT_RONGY(model, ptoken);
        }
        public MES_RETURN_UI UPDATE_RONGY(HR_RY_RONGY model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE_RONGY(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI INSERT_RONGY_RYID(int RONGYID, int RYID, string ptoken)
        {
            MES_RETURN mr = client.INSERT_RONGY_RYID(RONGYID, RYID, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI DELETE_RONGY(int RONGYID, string ptoken)
        {
            MES_RETURN mr = client.DELETE_RONGY(RONGYID, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI DELETE_RONGY_RYID(int RONGYID, string ptoken)
        {
            MES_RETURN mr = client.DELETE_RONGY_RYID(RONGYID, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_RY_RONGY_SELECT SELECT_RONGY_RYID(int RYID, string ptoken)
        {
            return client.SELECT_RONGY_RYID(RYID, ptoken);
        }
        public MES_RETURN_UI INSERT_RONGY_FILE(HR_RY_RONGY model, string ptoken)
        {
            MES_RETURN mr = client.INSERT_RONGY_FILE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_RY_RONGY_SELECT SELECT_RONGY_FILE(int RONGYID, string ptoken)
        {
            return client.SELECT_RONGY_FILE(RONGYID, ptoken);
        }
        public MES_RETURN_UI DELETE_RONGY_FILE(int RYFILEID, string ptoken)
        {
            MES_RETURN mr = client.DELETE_RONGY_FILE(RYFILEID, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_RY_RYINFO_SELECT SELECT_LB(HR_RY_RYINFO model, int LB, string ptoken)
        {
            return client.SELECT_LB(model, LB, ptoken);
        }
        public HR_RY_LZINFO_SELECT SELECT_LZINFO(HR_RY_RYINFO model, string ptoken)
        {
            return client.SELECT_LZINFO(model, ptoken);
        }
        public HR_RY_CHANGEINFO_SELECT SELECT_RY_CHANGEINFO(HR_RY_RYINFO_CHANGEINFO model, string ptoken)
        {
            return client.SELECT_RY_CHANGEINFO(model, ptoken);
        }
        public MES_RETURN_UI UPDATE_LB(HR_RY_RYINFO model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE_LB(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
    }
}
