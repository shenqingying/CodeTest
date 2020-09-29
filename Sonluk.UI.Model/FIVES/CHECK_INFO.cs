using Sonluk.UI.Model.MODEL;
using Sonluk.UI.Model.S5.CHECK_INFOService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.FIVES
{
    public class CHECK_INFO
    {
        private CHECK_INFOSoapClient client = new CHECK_INFOSoapClient("CHECK_INFOSoap", AppConfig.Settings("RemoteAddress") + "FIVES/CHECK_INFO.asmx");
        public MES_RETURN_UI Create(FIVES_CHECK_INFO model, string ptoken) 
        { 
            MES_RETURN mr = client.Create(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE; 
            mrui.MESSAGE = mr.MESSAGE;
            return mrui; 
        }
        public MES_RETURN_UI Update(FIVES_CHECK_INFO model, string ptoken) 
        { 
            MES_RETURN mr = client.UPDATE(model, ptoken); 
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui; 
        }
        public FIVES_CHECK_INFOList[] Read(FIVES_CHECK_INFOList model, string ptoken) 
        { return client.Read(model, ptoken);
        }
       
        public FIVES_CHECK_INFOList[] Read_HZINFO(FIVES_CHECK_INFOList model, string ptoken)
        {
            return client.Read_HZINFO(model, ptoken);
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
