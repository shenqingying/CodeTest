using Sonluk.UI.Model.MODEL;
using Sonluk.UI.Model.S5.SY_PRINCIPALCATEGROYService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.FIVES
{
    public class SY_PRINCIPALCATEGROY
    {
        private SY_PRINCIPALCATEGROYSoapClient client = new SY_PRINCIPALCATEGROYSoapClient("SY_PRINCIPALCATEGROYSoap", AppConfig.Settings("RemoteAddress") + "FIVES/SY_PRINCIPALCATEGROY.asmx");
        public MES_RETURN_UI Create(FIVES_SY_PRINCIPALCATEGROY model, string ptoken) 
        { 
            MES_RETURN mr = client.Create(model, ptoken); 
            MES_RETURN_UI mrui = new MES_RETURN_UI(); 
            mrui.TYPE = mr.TYPE; 
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI Update(FIVES_SY_PRINCIPALCATEGROY model, string ptoken) 
        { 
            MES_RETURN mr = client.UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public FIVES_SY_PRINCIPALCATEGROYList[] Read(FIVES_SY_PRINCIPALCATEGROY model, string ptoken) 
        {
            return client.Read(model, ptoken);
        }
        public MES_RETURN_UI Delete(FIVES_SY_PRINCIPALCATEGROY model, string ptoken)
        { 
            MES_RETURN mr = client.DELETE(model, ptoken); 
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE; 
            mrui.MESSAGE = mr.MESSAGE; 
            return mrui;
        }

    }
}
