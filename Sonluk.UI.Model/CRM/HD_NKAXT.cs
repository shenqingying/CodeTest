using Sonluk.UI.Model.CRM.HD_NKAXTService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class HD_NKAXT
    {
        private HD_NKAXTSoapClient client = new HD_NKAXTSoapClient("HD_NKAXTSoap", AppConfig.Settings("RemoteAddress") + "CRM/HD_NKAXT.asmx");

    
        public int Create_TT(CRM_HD_NKAXTTT model, string ptoken)
        {

            return client.Create_TT(model,ptoken);
           

        }
       
        public int Update_TT(CRM_HD_NKAXTTT model, string ptoken)
        {

            return client.Update_TT(model,ptoken);
           

        }
       
        public int Delete_TT(int NKAXTID, string ptoken)
        {

            return client.Delete_TT(NKAXTID,ptoken);
           

        }






       
        public int Create_MX(CRM_HD_NKAXTMX model, string ptoken)
        {

            return client.Create_MX(model,ptoken);
           

        }
        
        public int Update_MX(CRM_HD_NKAXTMX model, string ptoken)
        {

            return client.Update_MX(model,ptoken);
           

        }
       
        public int Delete_MX(int NKAXTMXID, string ptoken)
        {

            return client.Delete_MX(NKAXTMXID,ptoken);
            

        }



    }
}
