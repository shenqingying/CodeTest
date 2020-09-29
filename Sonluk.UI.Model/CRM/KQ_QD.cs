using Sonluk.UI.Model.CRM.KQ_QDService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class KQ_QD
    {
        private KQ_QDSoapClient client = new KQ_QDSoapClient("KQ_QDSoap", AppConfig.Settings("RemoteAddress") + "CRM/KQ_QD.asmx");

        public int Create(CRM_KQ_QD model, string ptoken)
        {
            return client.Create(model, ptoken);
        }

        public int Update(CRM_KQ_QD model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public CRM_KQ_QD ReadByKQQDID(int KQQDID, string ptoken)
        {
            return client.ReadByKQQDID(KQQDID, ptoken);
        }
        public CRM_KQ_QD[] ReadByQDLXandQDGSID(int QDLX, int QDGSID, string ptoken)
        {
            return client.ReadByQDLXandQDGSID(QDLX, QDGSID, ptoken);
        }
        public CRM_KQ_QD[] ReadYCQD_ByDATE(string QDRQ, int SXB, int STAFFID, string ptoken)
        {
            return client.ReadYCQD_ByDATE(QDRQ, SXB, STAFFID, ptoken);
        }

        public int Delete(int KQQDID, string ptoken)
        {
            return client.Delete(KQQDID, ptoken);
        }

        public string[][] Verify_QD(int STAFFID, string ED, string JD, double WXRC, string ptoken)
        {

            return client.Verify_QD(STAFFID, ED, JD, WXRC, ptoken);


        }
        public int ReadQD_COUNTS(CRM_KQ_QD model, string ptoken)
        {

            return client.ReadQD_COUNTS(model, ptoken);


        }

    }
}
