using Sonluk.UI.Model.MODEL;
using Sonluk.UI.Model.S5.SY_CHECKPOINT_CHECKDETAILService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.FIVES
{
    public class SY_CHECKPOINT_CHECKDETAIL
    {
        private SY_CHECKPOINT_CHECKDETAILSoapClient client = new SY_CHECKPOINT_CHECKDETAILSoapClient("SY_CHECKPOINT_CHECKDETAILSoap", AppConfig.Settings("RemoteAddress") + "/SY_CHECKPOINT_CHECKDETAIL.asmx"); 
        public MES_RETURN_UI Create(FIVES_SY_CHECKPOINT_CHECKDETAIL model, string ptoken) { 
            MES_RETURN mr = client.Create(model, ptoken); 
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui; 
        }	
        public MES_RETURN_UI Update(FIVES_SY_CHECKPOINT_CHECKDETAIL model, string ptoken) { 
            MES_RETURN mr = client.UPDATE(model, ptoken); 
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE; 
            mrui.MESSAGE = mr.MESSAGE; 
            return mrui; 
        }
        public FIVES_SY_CHECKPOINT_CHECKDETAILLIST[] Read(FIVES_SY_CHECKPOINT_CHECKDETAIL model, string ptoken)
        { 
            return client.Read(model, ptoken);
        }	
        public MES_RETURN_UI Delete(FIVES_SY_CHECKPOINT_CHECKDETAIL model, string ptoken) { 
            MES_RETURN mr = client.DELETE(model, ptoken); 
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE; 
            return mrui; 
        }

    }
}
