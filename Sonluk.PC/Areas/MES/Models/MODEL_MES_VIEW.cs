using Sonluk.UI.Model.MES.SY_GCService;
using Sonluk.UI.Model.MES.SY_GZZX_SBHService;
using Sonluk.UI.Model.MES.SY_GZZXService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.PC.Areas.MES.Models
{
    public class MODEL_MES_VIEW
    {
        private string _GC;

        public string GC
        {
            get { return _GC; }
            set { _GC = value; }
        }

        private string _GZZXBH;

        public string GZZXBH
        {
            get { return _GZZXBH; }
            set { _GZZXBH = value; }
        }

        private string _SBBH;

        public string SBBH
        {
            get { return _SBBH; }
            set { _SBBH = value; }
        }

        private string _ZPRQ;

        public string ZPRQ
        {
            get { return _ZPRQ; }
            set { _ZPRQ = value; }
        }

        private MES_SY_GC[] _MES_SY_GC;

        public MES_SY_GC[] MES_SY_GC
        {
            get { return _MES_SY_GC; }
            set { _MES_SY_GC = value; }
        }

        private MES_SY_GZZX[] _MES_SY_GZZX;

        public MES_SY_GZZX[] MES_SY_GZZX
        {
            get { return _MES_SY_GZZX; }
            set { _MES_SY_GZZX = value; }
        }

        private MES_SY_GZZX_SBH[] _MES_SY_GZZX_SBH;

        public MES_SY_GZZX_SBH[] MES_SY_GZZX_SBH
        {
            get { return _MES_SY_GZZX_SBH; }
            set { _MES_SY_GZZX_SBH = value; }
        }
    }
}