using Sonluk.UI.Model.CRM.HD_NKAMDService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class HD_NKAMD
    {
        private HD_NKAMDSoapClient client = new HD_NKAMDSoapClient("HD_NKAMDSoap", AppConfig.Settings("RemoteAddress") + "CRM/HD_NKAMD.asmx");

        public int Create_TT(CRM_HD_NKAMDTT model, string ptoken)
        {

            return client.Create_TT(model,ptoken);
           
        }
      
        public int Update_TT(CRM_HD_NKAMDTT model, string ptoken)
        {

            return client.Update_TT(model, ptoken);
           

        }
       
        public int Delete_TT(int NKAMDID, string ptoken)
        {

            return client.Delete_TT(NKAMDID, ptoken);
           

        }

      
        public int Create_MX(CRM_HD_NKAMDMX model, string ptoken)
        {

            return client.Create_MX(model, ptoken);
          

        }
     
        public int Update_MX(CRM_HD_NKAMDMX model, string ptoken)
        {

            return client.Update_MX(model, ptoken);
          

        }
       
        public int Delete_MX(int NKAMDMXID, string ptoken)
        {

            return client.Delete_MX(NKAMDMXID, ptoken);
           

        }

    }
}
