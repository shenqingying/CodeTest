using Sonluk.UI.Model.CRM_OAService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class CRM_OA
    {
        private CRM_OASoapClient client = new CRM_OASoapClient("CRM_OASoap", AppConfig.Settings("RemoteAddress") + "CRM/CRM_OA.asmx");


        public string GetAuthority(string ptoken)
        {

            return client.GetAuthority(ptoken);
        }
        public CRM_OA_INFO[] Pending(string ticketId, int firstNum, int pageSize,string address ,string ptoken)
        {

            return client.Pending(ticketId, firstNum, pageSize,address,ptoken);
          
        }
     
        public CRM_OA_INFO[] Track(string ticketId, int firstNum, int pageSize,string address, string ptoken)
        {

            return client.Track(ticketId, firstNum, pageSize,address,ptoken);
          
        }
        
        //public string Launch(CRM_OA_BASIC basic, CRM_OA_QJList QJ_model, string ptoken)
        public MessageInfo Launch(CRM_OA_BASIC basic,object model, string ptoken)
        {

            return client.Launch(basic,model,ptoken);
          
        }
        //public MessageInfo Launch_Test(CRM_OA_BASIC basic, object model, string ptoken)
        //{

        //    return client.Launch_Test(basic, model, ptoken);

        //}
        public void CRM_OA_FLOW()
        {
            client.CRM_OA_FLOW();
        }

        public void Auto_UPDATE_All()
        {
            client.Auto_UPDATE_All();
        }


    }
}
