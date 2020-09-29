﻿using Sonluk.UI.Model.CRM.HG_RIGHTService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.CRM
{
    public class HG_RIGHT
    {
        private HG_RIGHTSoapClient client = new HG_RIGHTSoapClient("HG_RIGHTSoap", AppConfig.Settings("RemoteAddress") + "CRM/HG_RIGHT.asmx");


        public int Create(CRM_HG_RIGHT model, string ptoken)
        {
            return client.Create(model, ptoken);
        }

        public int Update(CRM_HG_RIGHT model, string ptoken)
        {
            return client.Update(model, ptoken);
        }

        public int Delete(int RIGHTID, string ptoken)
        {
            return client.Delete(RIGHTID, ptoken);
        }

        public CRM_HG_RIGHT[] ReadByRGROUPID(int RGROUPID, string ptoken)
        {
            return client.ReadByRGROUPID(RGROUPID, ptoken);
        }
        public CRM_HG_RIGHTList[] Read(string ptoken)
        {
            return client.Read(ptoken);
        }
        public CRM_HG_RIGHT[] ReadByParam(CRM_HG_RIGHT model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
    }
}
