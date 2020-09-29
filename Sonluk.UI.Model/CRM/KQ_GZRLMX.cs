using Sonluk.UI.Model.CRM.KQ_GZRLMXService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class KQ_GZRLMX
    {
        private KQ_GZRLMXSoapClient client = new KQ_GZRLMXSoapClient("KQ_GZRLMXSoap", AppConfig.Settings("RemoteAddress") + "CRM/KQ_GZRLMX.asmx");
        

        public int Create(CRM_KQ_GZRLMX model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
     
        public int Update(CRM_KQ_GZRLMX model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
       
        public CRM_KQ_GZRLMX[] Read(int BBID,string Fromdate,string todate, string ptoken)
        {
            return client.Read(BBID,Fromdate,todate,ptoken);
        }
        public double CountDaysByGZRLMX(int BBID,string beginTime, string endTime, bool isfullbegin, bool isfullend, string ptoken)
        {

            return client.CountDaysByGZRLMX(BBID,beginTime, endTime, isfullbegin, isfullend, ptoken);


        }
        public int Delete(int BBID, string @DATE_BEGIN, string DATE_END, string ptoken)
        {
            return client.Delete(BBID, @DATE_BEGIN, DATE_END, ptoken);
        }
    }
}
