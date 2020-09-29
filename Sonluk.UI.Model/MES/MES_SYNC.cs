using Sonluk.UI.Model.MES.MES_SYNCService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.MES
{
    public class MES_SYNC
    {
        private MES_SYNCSoapClient client = new MES_SYNCSoapClient("MES_SYNCSoap", AppConfig.Settings("RemoteAddress") + "MES/MES_SYNC.asmx");
        public MES_RETURN_UI MES_WLGROUP_SYNC(string ptoken)
        {
            MES_RETURN mr = client.MES_WLGROUP_SYNC(ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }

        public MES_RETURN_UI MES_SYNC_WL(string GC, string WLGROUP, string WLH, int JLR, string ptoken)
        {
            MES_RETURN mr = client.MES_SYNC_WL(GC, WLGROUP, WLH, JLR, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI MES_SYNC_KCDD(string GC, string ptoken)
        {
            MES_RETURN mr = client.MES_SYNC_KCDD(GC, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public MES_RETURN_UI MES_SYNC_GZZX(string GC, string ptoken)
        {
            MES_RETURN mr = client.MES_SYNC_GZZX(GC, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
    }
}
