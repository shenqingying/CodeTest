using Sonluk.UI.Model.MES.SY_TYPEMXService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class SY_TYPEMX
    {
        private SY_TYPEMXSoapClient client = new SY_TYPEMXSoapClient("SY_TYPEMXSoap", AppConfig.Settings("RemoteAddress") + "MES/SY_TYPEMX.asmx");
        public MES_SY_TYPEMXLIST[] SELECT(MES_SY_TYPEMX model, string ptoken)
        {
            return client.SELECT(model, ptoken);
        }

        public MES_RETURN_UI INSERT(MES_SY_TYPEMX model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
            //return client.INSERT(model, ptoken);
        }

        public MES_RETURN_UI UPDATE(MES_SY_TYPEMX model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
            //return client.UPDATE(model, ptoken);
        }

        public MES_RETURN_UI DELETE(int ID, string ptoken)
        {
            MES_RETURN mr = client.DELETE(ID, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
            //return client.DELETE(ID, ptoken);
        }
        public MES_SY_TYPEMXLIST[] SELECT_SBFL_BY_GZZX(string GC, string GZZXBH, string ptoken)
        {
            return client.SELECT_SBFL_BY_GZZX(GC, GZZXBH, ptoken);
        }
        public MES_SY_TYPEMXLIST[] SELECT_NOPTOKEN(MES_SY_TYPEMX model)
        {
            return client.SELECT_NOPTOKEN(model);
        }
    }
}
