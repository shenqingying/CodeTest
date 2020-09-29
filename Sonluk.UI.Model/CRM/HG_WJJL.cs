using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sonluk.UI.Model.CRM.HG_WJJLService;
using Sonluk.Utility;
namespace Sonluk.UI.Model.CRM
{
    public class HG_WJJL
    {
        private HG_WJJLSoapClient client = new HG_WJJLSoapClient("HG_WJJLSoap", AppConfig.Settings("RemoteAddress") + "CRM/HG_WJJL.asmx");

        public int Create(CRM_HG_WJmodel model, string ptoken)
        {
            return client.Create(model, ptoken);
        }

        public int Delete(int JLID, string ptoken)
        {
            return client.Delete(JLID, ptoken);
        }

        public CRM_HG_WJJL[] Read(int GSDX, int GSDXID, string ptoken)
        {
            return client.Read(GSDX, GSDXID, ptoken);
        }
        public CRM_HG_WJJL[] ReadByParam(CRM_HG_WJJL model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public CRM_HG_WJJL[] ReadLocation(int GSDX, int GSDXID, string ptoken)
        {
            return client.ReadLocation(GSDX, GSDXID, ptoken);
        }
        public int Update_SP(CRM_HG_WJJL model, string ptoken)
        {
            return client.Update_SP(model, ptoken);
        }
        public CRM_HG_WJJL[] DisplayImgReport(CRM_HG_WJJL_KHModel model, int STAFFID, string ptoken)
        {
            return client.DisplayImgReport(model, STAFFID, ptoken);
        }
    }
}
