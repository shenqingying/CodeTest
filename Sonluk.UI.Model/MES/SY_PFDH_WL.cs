﻿using Sonluk.UI.Model.MES.SY_PFDH_WLService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class SY_PFDH_WL
    {
        private SY_PFDH_WLSoapClient client = new SY_PFDH_WLSoapClient("SY_PFDH_WLSoap", AppConfig.Settings("RemoteAddress") + "MES/SY_PFDH_WL.asmx");

        public MES_RETURN_UI INSERT(MES_SY_PFDH_WL[] model, string ptoken)
        {
            MES_RETURN mr = client.INSERT(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI DELETE(MES_SY_PFDH_WL model, string ptoken)
        {
            MES_RETURN mr = client.DELETE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_SY_PFDH_WL_SELECT_LAY SELECT_LAY(MES_SY_PFDH_WL model, string ptoken)
        {
            return client.SELECT_LAY(model, ptoken);
        }
        public MES_SY_PFDH_WL_SELECT SELECT(MES_SY_PFDH_WL model, string ptoken)
        {
            return client.SELECT(model, ptoken);
        }
    }
}