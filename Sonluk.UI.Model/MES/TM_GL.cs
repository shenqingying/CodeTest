using Sonluk.UI.Model.MES.TM_GLService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class TM_GL
    {
        private WS_MES_TM_GLSoapClient client = new WS_MES_TM_GLSoapClient("WS_MES_TM_GLSoap", AppConfig.Settings("RemoteAddress") + "MES/WS_MES_TM_GL.asmx");
        public MES_TM_GL_SELECT SELECT(MES_TM_GL model, string ptoken)
        {
            return client.SELECT(model, ptoken);
        }
    }
}
