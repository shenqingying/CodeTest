using Sonluk.UI.Model.CRM.HG_DICTService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class HG_DICT
    {
        private HG_DICTSoapClient client = new HG_DICTSoapClient("HG_DICTSoap", AppConfig.Settings("RemoteAddress") + "CRM/HG_DICT.asmx");

        public int Create(CRM_HG_DICT model, string ptoken)
        {
            return client.Create(model, ptoken);
        }

        public int Update(CRM_HG_DICT model, string ptoken)
        {
            return client.Update(model, ptoken);
        }

        public int Delete(int DICID, string ptoken)
        {
            return client.Delete(DICID, ptoken);
        }

        public CRM_HG_DICT[] Read(int TYPEID, int FID, string ptoken)
        {
            return client.Read(TYPEID, FID, ptoken);
        }
        public CRM_HG_DICT[] ReadByParam(CRM_HG_DICT model, int STAFFID, string ptoken)
        {
            return client.ReadByParam(model, STAFFID, ptoken);
        }
        public int ReadByDICNAME(string DICNAME, int typeID, string ptoken)
        {
            return client.ReadByDICNAME(DICNAME, typeID, ptoken);
        }
        public int ReadByDICNAMEandFID(string DICNAME, int typeID, int FID, string ptoken)
        {
            return client.ReadByDICNAMEandFID(DICNAME, typeID, FID, ptoken);
        }

        public CRM_HG_DICT ReadByDICID(int DICID, string ptoken)
        {

            return client.ReadByDICID(DICID, ptoken);


        }
    }

}
