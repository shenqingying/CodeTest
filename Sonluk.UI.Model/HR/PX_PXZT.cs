using Sonluk.UI.Model.HR.PX_PXZTService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.HR
{
    public class PX_PXZT
    {
        private PX_PXZTSoapClient client = new PX_PXZTSoapClient("PX_PXZTSoap", AppConfig.Settings("RemoteAddress") + "HR/PX_PXZT.asmx");
        public MES_RETURN_UI INSERT_PXZT(HR_PX_PXZT model, string ptoken)
        {
            MES_RETURN mr = client.INSERT_PXZT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TID = mr.TID;
            return mrui;
        }
        public HR_PX_PXZT_SELECT SELECT_PXZT(HR_PX_PXZT model, string ptoken)
        {
            return client.SELECT_PXZT(model, ptoken);
        }
        public MES_RETURN_UI UPDATE_PXZT(HR_PX_PXZT model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE_PXZT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI INSERT_PXZT_FJ(HR_PX_PXZT model, string ptoken)
        {
            MES_RETURN mr = client.INSERT_PXZT_FJ(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_PX_PXZT_SELECT SELECT_PXZT_FJ(int PXZTID, string ptoken)
        {
            return client.SELECT_PXZT_FJ(PXZTID, ptoken);
        }
        public MES_RETURN_UI INSERT_PXZTMX(HR_PX_PXZT model, string ptoken)
        {
            MES_RETURN mr = client.INSERT_PXZTMX(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_PX_PXZT_SELECT SELECT_PXZTMX(HR_PX_PXZT model, string ptoken)
        {
            return client.SELECT_PXZTMX(model, ptoken);
        }
        public MES_RETURN_UI DELETE_PXZT(int PXZTID, string ptoken)
        {
            MES_RETURN mr = client.DELETE_PXZT(PXZTID, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI DELETE_PXZT_FJ(int FJID, string ptoken)
        {
            MES_RETURN mr = client.DELETE_PXZT_FJ(FJID, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI DELETE_PXZTMX(int PXZTMXID, string ptoken)
        {
            MES_RETURN mr = client.DELETE_PXZTMX(PXZTMXID, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_PX_PXZT_SELECT SELECT_PXZT_RY(HR_PX_PXZT model, string ptoken)
        {
            return client.SELECT_PXZT_RY(model, ptoken);
        }
        public MES_RETURN_UI PXZT_BMRY_INSERT(HR_PX_PXZT_BMRY model, string ptoken)
        {
            MES_RETURN mr = client.PXZT_BMRY_INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            mrui.TID = mr.TID;
            return mrui;
        }
        public MES_RETURN_UI PXZT_BMRY_UPDATE(HR_PX_PXZT_BMRY model, string ptoken)
        {
            MES_RETURN mr = client.PXZT_BMRY_UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public HR_PX_PXZT_BMRY_SELECT PXZT_BMRY_SELECT(HR_PX_PXZT_BMRY model, string ptoken)
        {
            return client.PXZT_BMRY_SELECT(model, ptoken);
        }
    }
}
