using Sonluk.UI.Model.CRM.HD_ZDFService;
using Sonluk.UI.Model.CRM.HD_ZYCXYSerivce;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class HD_ZYCXY
    {
        private HD_ZYCXYSoapClient client = new HD_ZYCXYSoapClient("HD_ZYCXYSoap", AppConfig.Settings("RemoteAddress") + "CRM/HD_ZYCXY.asmx");
        public int Create_TT(CRM_HD_ZYCXYTT model, string ptoken)
        {

            return client.Create_TT(model,ptoken);
           

        }
       
        public int Update_TT(CRM_HD_ZYCXYTT model, string ptoken)
        {

            return client.Update_TT(model,ptoken);
          

        }
    
        public int Delete_TT(int ZYCXYID, string ptoken)
        {

            return client.Delete_TT(ZYCXYID,ptoken);
          

        }








        public int Create_MX(CRM_HD_ZYCXYMX model, string ptoken)
        {

            return client.Create_MX(model,ptoken);
          

        }
      
        public int Update_MX(CRM_HD_ZYCXYMX model, string ptoken)
        {

            return client.Update_MX(model,ptoken);
          

        }
      
        public int Delete_MX(int ZYCXYMXID, string ptoken)
        {
            
            return client.Delete_MX(ZYCXYMXID,ptoken);
           

        }




    }
}
