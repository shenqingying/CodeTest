using Sonluk.UI.Model.BARCODE.SY_CODINGService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.BARCODE
{
   public class SY_CODING
    {
        private SY_CODINGSoapClient client = new SY_CODINGSoapClient("SY_CODINGSoap", AppConfig.Settings("RemoteAddress") + "BARCODE/SY_CODING.asmx");

        public MES_RETURN_UI Create(BARCODE_SY_CODING model, string ptoken)
        {
            MES_RETURN mr = client.Create(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI Update(BARCODE_SY_CODING model, string ptoken)
        {
            MES_RETURN mr = client.UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public BARCODE_SY_CODING[] ReadByParam(BARCODE_SY_CODING model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public MES_RETURN_UI Delete(int ID, string ptoken)
        {
            MES_RETURN mr = client.DELETE(ID, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
    }
}
