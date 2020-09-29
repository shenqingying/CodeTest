using Sonluk.UI.Model.MODEL;
using Sonluk.UI.Model.S5.SY_POINTCATEGROY_DETAILService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.FIVES
{
    public class SY_POINTCATEGROY_DETAIL
    {
        private SY_POINTCATEGROY_DETAILSoapClient client = new SY_POINTCATEGROY_DETAILSoapClient("SY_POINTCATEGROY_DETAILSoap", AppConfig.Settings("RemoteAddress") + "FIVES/SY_POINTCATEGROY_DETAIL.asmx");
        public MES_RETURN_UI Create(FIVES_SY_POINTCATEGROY_DETAIL model, string ptoken) 
        {
            MES_RETURN mr = client.Create(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE; 
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI Update(FIVES_SY_POINTCATEGROY_DETAIL model, string ptoken) 
        { 
            MES_RETURN mr = client.UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI(); 
            mrui.TYPE = mr.TYPE; 
            mrui.MESSAGE = mr.MESSAGE; 
            return mrui;
        }
        public FIVES_SY_POINTCATEGROY_DETAILList[] Read(FIVES_SY_POINTCATEGROY_DETAIL model, string ptoken) 
        {
            return client.Read(model, ptoken); 
        }
        public MES_RETURN_UI Delete(FIVES_SY_POINTCATEGROY_DETAIL model, string ptoken) 
        {
            MES_RETURN mr = client.DELETE(model, ptoken); 
            MES_RETURN_UI mrui = new MES_RETURN_UI(); 
            mrui.TYPE = mr.TYPE; 
            mrui.MESSAGE = mr.MESSAGE; 
            return mrui; 
        }

    }
}
