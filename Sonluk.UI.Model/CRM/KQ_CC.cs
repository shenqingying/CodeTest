using Sonluk.UI.Model.CRM.KQ_CCService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class KQ_CC
    {
        private KQ_CCSoapClient client = new KQ_CCSoapClient("KQ_CCSoap", AppConfig.Settings("RemoteAddress") + "CRM/KQ_CC.asmx");
        public int Create_MX(CRM_KQ_CCMX model, string ptoken)
        {

            return client.Create_MX(model,ptoken);
          

        }
       
        public int Update_MX(CRM_KQ_CCMX model, string ptoken)
        {

            return client.Update_MX(model,ptoken);
          

        }
       
        public int Delete_MX(int ID, string ptoken)
        {

            return client.Delete_MX(ID,ptoken);
            

        }
      
        public CRM_KQ_CCMX[] Read_MXbyCCID(int CCID, string ptoken)
        {
           

            return client.Read_MXbyCCID(CCID,ptoken);
           

        }

        public CRM_KQ_CCMXList[] Read_MXQDbyCCID(int CCID, string ptoken)
        {


            return client.Read_MXQDbyCCID(CCID, ptoken);


        }
        
        public int Create_TT(CRM_KQ_CCTT model, string ptoken)
        {

            return client.Create_TT(model,ptoken);
          

        }
        
        public int Update_TT(CRM_KQ_CCTT model, string ptoken)
        {

            return client.Update_TT(model,ptoken);
           

        }
       
        public int Delete_TT(int CCID, string ptoken)
        {

            return client.Delete_TT(CCID,ptoken);
         

        }
       
        public CRM_KQ_CCTTList[] Read_TTbySTAFFID(int STAFFID,int status, string ptoken)
        {
           

            return client.Read_TTbySTAFFID(STAFFID,status,ptoken);
           

        }
        public CRM_KQ_CCTT Read_TTbyCCID(int CCID, string ptoken)
        {

            return client.Read_TTbyCCID(CCID, ptoken);
           

        }
        public CRM_KQ_CCTTList[] Read_TTbyParam(CRM_KQ_CCTT model,int STATUS, string ptoken)
        {
            return client.Read_TTbyParam(model,STATUS, ptoken);
        }
    }
}
