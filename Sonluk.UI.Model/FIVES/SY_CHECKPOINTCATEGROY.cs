using Sonluk.UI.Model.MODEL;
using Sonluk.UI.Model.S5.SY_CHECKPOINTCATEGROYService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.FIVES
{
    public class SY_CHECKPOINTCATEGROY
    {
        private SY_CHECKPOINTCATEGROYSoapClient client = new SY_CHECKPOINTCATEGROYSoapClient("SY_CHECKPOINTCATEGROYSoap", AppConfig.Settings("RemoteAddress") + "FIVES/SY_CHECKPOINTCATEGROY.asmx");
        public MES_RETURN_UI Create(FIVES_SY_CHECKPOINTCATEGROY model, string ptoken)
        { 
            MES_RETURN mr = client.Create(model, ptoken); 
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE; 
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI Update(FIVES_SY_CHECKPOINTCATEGROY model, string ptoken) 
        { 
            MES_RETURN mr = client.UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI(); 
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui; 
        }
        public FIVES_SY_CHECKPOINTCATEGROY[] Read(FIVES_SY_CHECKPOINTCATEGROY model, string ptoken) 
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

    }
}
