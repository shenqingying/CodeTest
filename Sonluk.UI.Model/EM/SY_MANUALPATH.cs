using Sonluk.UI.Model.EM.SY_MANUALPATHService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.EM
{
    public class SY_MANUALPATH
    {
        private SY_MANUALPATHSoapClient client = new SY_MANUALPATHSoapClient("SY_MANUALPATHSoap", AppConfig.Settings("RemoteAddress") + "EM/SY_MANUALPATH.asmx");
        public MES_RETURN_UI Create(EM_SY_MANUALPATH model, string ptoken)
        {
            MES_RETURN mr = client.Create(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI Update(EM_SY_MANUALPATH model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public EM_SY_MANUALPATH[] Read(EM_SY_MANUALPATH model, string ptoken)
        {
            return client.Read(model, ptoken);
        }
        public MES_RETURN_UI Delete(int ID, string ptoken)
        {
            MES_RETURN mr = client.DELETE(ID, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public EM_SY_MANUALPATH_SELECT ReadBYTM(string tm, string token,int staffid)
        {
            // type   包装作业指导书
            EM_SY_MANUALPATH_SELECT rst = client.ReadBYTM(tm, token,staffid);
            return rst;
        }
    }
}
