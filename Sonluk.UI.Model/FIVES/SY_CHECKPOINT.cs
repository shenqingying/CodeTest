using Sonluk.UI.Model.MODEL;
using Sonluk.UI.Model.S5.SY_CHECKPOINTService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.FIVES
{
    public class SY_CHECKPOINT
    {
        private SY_CHECKPOINTSoapClient client = new SY_CHECKPOINTSoapClient("SY_CHECKPOINTSoap", AppConfig.Settings("RemoteAddress") + "FIVES/SY_CHECKPOINT.asmx");
        public MES_RETURN_UI Create(FIVES_SY_CHECKPOINT model, string ptoken) 
        { 
            Sonluk.UI.Model.S5.SY_CHECKPOINTService.MES_RETURN mr = client.Create(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI(); 
            mrui.TYPE = mr.TYPE; 
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI Update(FIVES_SY_CHECKPOINT model, string ptoken) 
        { 
            MES_RETURN mr = client.UPDATE(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE; 
            mrui.MESSAGE = mr.MESSAGE; 
            return mrui;
        }
        public FIVES_SY_CHECKPOINT[] Read(FIVES_SY_CHECKPOINT model, string ptoken) 
        { 
            return client.Read(model, ptoken);
        }
        public FIVES_SY_CHECKPOINT[] Compare(FIVES_SY_CHECKPOINT model, string ptoken)
        {
            return client.Compare(model, ptoken);
        }
        public FIVES_SY_CHECKPOINTList[] ReadaddDepName(FIVES_SY_CHECKPOINT model, string ptoken)
        {
            return client.ReadaddDepName(model, ptoken);
        }
        public MES_RETURN_UI Delete(int ID, string ptoken) 
        { 
            MES_RETURN mr = client.DELETE(ID, ptoken); 
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE; 
            return mrui;
        }
        public MES_RETURN_UI Create_ALL(FIVES_SY_CHECKPOINT_CREATE model, string ptoken)
        {
            MES_RETURN mr = client.Create_All(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI Update_ALL(FIVES_SY_CHECKPOINT_CREATE model, string ptoken)
        {
            MES_RETURN mr = client.Update_All(model, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI Delete_ALL(int pointid, string ptoken)
        {
            MES_RETURN mr = client.Delete_All(pointid, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public FIVES_SY_CHECKPOINT_CREATE Select_CHECKPOINT_byParms(int pointid, int staffid, string ptoken)
        {
            FIVES_SY_CHECKPOINT_CREATE res = client.Select_CHECKPOINT_byParms(pointid, staffid, ptoken);
            return res;
        }
        public FIVES_SY_CHECKPOINT_CREATE Select_CHECKPOINT_byPointid(int pointid, string ptoken)
        {
            FIVES_SY_CHECKPOINT_CREATE res = client.Select_ByPointID(pointid, ptoken);
            return res;
        }
    }
}
