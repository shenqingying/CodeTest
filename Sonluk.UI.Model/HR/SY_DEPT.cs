using Sonluk.UI.Model.HR.SY_DEPTService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.HR
{
    public class SY_DEPT
    {
        private SY_DEPTSoapClient client = new SY_DEPTSoapClient("SY_DEPTSoap", AppConfig.Settings("RemoteAddress") + "HR/SY_DEPT.asmx");
        public MES_RETURN_UI INSERT(HR_SY_DEPT model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_SY_DEPT_SELECT SELECT(HR_SY_DEPT model, string ptoken)
        {
            return client.SELECT(model, ptoken);
        }
        public HR_SY_DEPT_SELECT SELECT_LB(HR_SY_DEPT model, int LB, string ptoken)
        {
            return client.SELECT_LB(model, LB, ptoken);
        }
        public MES_RETURN_UI UPDATE(HR_SY_DEPT model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI DELETE(HR_SY_DEPT model, string ptoken)
        {
            MES_RETURN mr = client.DELETE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_SY_DEPT_SELECT SELECT_BY_ROLE(HR_SY_DEPT model, int LB, string ptoken)
        {
            return client.SELECT_BY_ROLE(model, LB, ptoken);
        }
        public HR_SY_DEPT_SELECT SELECT_RYCOUNT(int DEPTID, string ptoken)
        {
            return client.SELECT_RYCOUNT(DEPTID, ptoken);
        }
        public HR_SY_DEPT_SELECT SELECT_BY_ROLE_LD(HR_SY_DEPT model, string ptoken)
        {
            return client.SELECT_BY_ROLE_LD(model, ptoken);
        }
        public MES_RETURN_UI UPDATE_FID(int DEPTID, int FID, int STAFFID, string ptoken)
        {
            MES_RETURN mr = client.UPDATE_FID(DEPTID, FID, STAFFID, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
    }
}
