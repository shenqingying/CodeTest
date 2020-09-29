using Sonluk.UI.Model.CRM.HG_ROLEService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class HG_ROLE
    {
        private HG_ROLESoapClient client = new HG_ROLESoapClient("HG_ROLESoap", AppConfig.Settings("RemoteAddress") + "CRM/HG_ROLE.asmx");

        public int Create(CRM_HG_ROLE model, string ptoken)
        {
            return client.Create(model, ptoken);
        }

        public int Update(CRM_HG_ROLE model, string ptoken)
        {
            return client.Update(model, ptoken);
        }

        public int Delete(int ROLEID, string ptoken)
        {
            return client.Delete(ROLEID, ptoken);
        }

        public CRM_HG_ROLE[] Read(string ptoken)
        {
            return client.Read(ptoken);
        }
        public CRM_HG_ROLE[] ReadByParam(CRM_HG_ROLE model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int Create_STAFFROLE(int STAFFID, int ROLEID, string ptoken)
        {
            return client.Create_STAFFROLE(STAFFID, ROLEID, ptoken);
        }

        public string[][] Read_STAFFROLEbyROLEID(int ROLEID, string ptoken)
        {
            return client.Read_STAFFROLEbyROLEID(ROLEID, ptoken);
        }

        public int Delete_STAFFROLE(int STAFFID, int ROLEID, string ptoken)
        {
            return client.Delete_STAFFROLE(STAFFID, ROLEID, ptoken);
        }

        public int Create_ROLERIGHT(int ROLEID, int RIGHTID, string ptoken)
        {
            return client.Create_ROLERIGHT(ROLEID, RIGHTID, ptoken);
        }

        public string[][] Read_ROLERIGHTByRIGHTID(int RIGHTID, string ptoken)
        {
            return client.Read_ROLERIGHTByRIGHTID(RIGHTID, ptoken);
        }

        public int Delete_ROLERIGHT(int ROLEID, int RIGHTID, string ptoken)
        {
            return client.Delete_ROLERIGHT(ROLEID, RIGHTID, ptoken);
        }
        public CRM_HG_STAFFROLEList[] Read_STAFFROLEbySTAFFID(int STAFFID, string ptoken)
        {

            return client.Read_STAFFROLEbySTAFFID(STAFFID, ptoken);


        }
        public int Delete_STAFFROLEByStaffid(int STAFFID, string ptoken)
        {

            return client.Delete_STAFFROLEByStaffid(STAFFID, ptoken);


        }
        public int[] ROLERIGHTByROLEID(int ROLEID, string ptoken)
        {

            return client.Read_ROLERIGHTByROLEID(ROLEID, ptoken);


        }
    }
}
