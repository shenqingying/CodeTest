using Sonluk.UI.Model.MES.SY_GCService;
using Sonluk.UI.Model.MES.SY_GZZX_WLLBService;
using Sonluk.UI.Model.MES.SY_GZZXService;
using Sonluk.UI.Model.MES.SY_MATERIAL_GROUPService;
using Sonluk.UI.Model.MES.SY_MATERIALService;
using Sonluk.UI.Model.MES.SY_TYPEMXService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.PC.Areas.MES.Models
{
    public class MODEL_Assign_WorkOrder
    {
        private MES_SY_GC[] _MES_SY_GC;

        public MES_SY_GC[] MES_SY_GC
        {
            get { return _MES_SY_GC; }
            set { _MES_SY_GC = value; }
        }

        private MES_SY_TYPEMXLIST[] _BC;

        public MES_SY_TYPEMXLIST[] BC
        {
            get { return _BC; }
            set { _BC = value; }
        }

        private MES_SY_GZZX[] _GZXX;

        public MES_SY_GZZX[] GZXX
        {
            get { return _GZXX; }
            set { _GZXX = value; }
        }

        private MES_SY_MATERIAL_GROUP[] _WLGROUP;

        public MES_SY_MATERIAL_GROUP[] WLGROUP
        {
            get { return _WLGROUP; }
            set { _WLGROUP = value; }
        }

        private MES_SY_MATERIAL_LIST[] _WL;

        public MES_SY_MATERIAL_LIST[] WL
        {
            get { return _WL; }
            set { _WL = value; }
        }

        private MES_SY_TYPEMXLIST[] _DW;

        public MES_SY_TYPEMXLIST[] DW
        {
            get { return _DW; }
            set { _DW = value; }
        }

        private int _GZZXCOUNT;

        public int GZZXCOUNT
        {
            get { return _GZZXCOUNT; }
            set { _GZZXCOUNT = value; }
        }

        private MES_SY_GZZX_WLLB[] _WLLB;

        public MES_SY_GZZX_WLLB[] WLLB
        {
            get { return _WLLB; }
            set { _WLLB = value; }
        }

        private MES_SY_TYPEMXLIST[] _SBFL;

        public MES_SY_TYPEMXLIST[] SBFL
        {
            get { return _SBFL; }
            set { _SBFL = value; }
        }

    }
}