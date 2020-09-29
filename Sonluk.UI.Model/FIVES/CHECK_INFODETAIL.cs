using Sonluk.UI.Model.MODEL;
using Sonluk.UI.Model.S5.CHECK_INFODETAILService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.FIVES
{
    public class CHECK_INFODETAIL
    {
        private CHECK_INFODETAILSoapClient client = new CHECK_INFODETAILSoapClient("CHECK_INFODETAILSoap", AppConfig.Settings("RemoteAddress") + "FIVES/CHECK_INFODETAIL.asmx");
        public MES_RETURN_UI Create(FIVES_CHECK_INFODETAIL[] model, string ptoken)
        { 
            MES_RETURN mr = client.Create(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE; 
            mrui.MESSAGE = mr.MESSAGE; 
            return mrui;
        }
        public MES_RETURN_UI Update(FIVES_CHECK_INFODETAIL model, string ptoken) 
        { 
            MES_RETURN mr = client.UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI(); 
            mrui.TYPE = mr.TYPE; 
            mrui.MESSAGE = mr.MESSAGE; 
            return mrui;
        }
        public FIVES_CHECK_INFODETAILList[] Read(FIVES_CHECK_INFODETAIL model, string ptoken) 
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
