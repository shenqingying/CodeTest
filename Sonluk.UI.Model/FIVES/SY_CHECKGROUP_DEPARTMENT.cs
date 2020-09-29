using Sonluk.UI.Model.MODEL;
using Sonluk.UI.Model.S5.SY_CHECKGROUP_DEPARTMENTService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.FIVES
{
    public class SY_CHECKGROUP_DEPARTMENT
    {
        private SY_CHECKGROUP_DEPARTMENTSoapClient client = new SY_CHECKGROUP_DEPARTMENTSoapClient("SY_CHECKGROUP_DEPARTMENTSoap", AppConfig.Settings("RemoteAddress") + "FIVES/SY_CHECKGROUP_DEPARTMENT.asmx");
        public MES_RETURN_UI Create(FIVES_SY_CHECKGROUP_DEPARTMENT model, string ptoken) 
        { 
            MES_RETURN mr = client.Create(model, ptoken); 
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE; 
            mrui.MESSAGE = mr.MESSAGE; 
            return mrui; 
        }
        public MES_RETURN_UI Update(FIVES_SY_CHECKGROUP_DEPARTMENT model, string ptoken) 
        { 
            MES_RETURN mr = client.UPDATE(model, ptoken); 
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE; 
            mrui.MESSAGE = mr.MESSAGE; 
            return mrui; 
        }
        public FIVES_SY_CHECKGROUP_DEPARTMENT[] Read(FIVES_SY_CHECKGROUP_DEPARTMENT model, string ptoken) 
        { 
            return client.Read(model, ptoken);
        }
        public MES_RETURN_UI Delete(FIVES_SY_CHECKGROUP_DEPARTMENT model, string ptoken)
        {
            MES_RETURN mr = client.DELETE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI(); 
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE; 
            return mrui; }

    }
}
