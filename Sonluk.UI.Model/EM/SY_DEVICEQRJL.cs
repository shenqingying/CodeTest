using Sonluk.UI.Model.EM.SY_DEVICEQRJLService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.EM
{
    public class SY_DEVICEQRJL
    {
        private SY_DEVICEQRJLSoapClient client = new SY_DEVICEQRJLSoapClient("SY_DEVICEQRJLSoap", AppConfig.Settings("RemoteAddress") + "EM/SY_DEVICEQRJL.asmx");
        public MES_RETURN_UI Create(EM_SY_DEVICEQRJL model, string ptoken)
        {
            MES_RETURN mr = client.Create(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public EM_SY_DEVICEQRJL[] Read(EM_SY_DEVICEQRJL model, string ptoken)
        {
            return client.Read(model, ptoken);
        }
    }
}
