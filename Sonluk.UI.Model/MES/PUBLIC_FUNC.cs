using Sonluk.UI.Model.MES.PUBLIC_FUNCService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class PUBLIC_FUNC
    {
        private PUBLIC_FUNCSoapClient client = new PUBLIC_FUNCSoapClient("PUBLIC_FUNCSoap", AppConfig.Settings("RemoteAddress") + "MES/PUBLIC_FUNC.asmx");

        public string GET_TIME(string ptoken)
        {
            return client.GET_TIME(ptoken);
        }

        public MES_RETURN_UI GET_YGNAME(string GH, string ptoken)
        {
            MES_RETURN mr = client.GET_YGNAME(GH, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
    }
}
