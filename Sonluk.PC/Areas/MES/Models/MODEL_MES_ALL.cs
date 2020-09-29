using Sonluk.UI.Model.MES.SY_GCService;
using Sonluk.UI.Model.MES.SY_GZZX_SBHService;
using Sonluk.UI.Model.MES.SY_GZZXService;
using Sonluk.UI.Model.MES.SY_TYPEMXService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.PC.Areas.MES.Models
{
    public class MODEL_MES_ALL
    {
        private MES_SY_GC[] _MES_SY_GC;

        public MES_SY_GC[] MES_SY_GC
        {
            get { return _MES_SY_GC; }
            set { _MES_SY_GC = value; }
        }
        private int _GCCOUNT;

        public int GCCOUNT
        {
            get { return _GCCOUNT; }
            set { _GCCOUNT = value; }
        }
        private MES_SY_GZZX[] _MES_SY_GZZX;

        public MES_SY_GZZX[] MES_SY_GZZX
        {
            get { return _MES_SY_GZZX; }
            set { _MES_SY_GZZX = value; }
        }
        private int _GZZXCOUNT;

        public int GZZXCOUNT
        {
            get { return _GZZXCOUNT; }
            set { _GZZXCOUNT = value; }
        }
        private MES_SY_GZZX_SBH[] _MES_SY_GZZX_SBH;

        public MES_SY_GZZX_SBH[] MES_SY_GZZX_SBH
        {
            get { return _MES_SY_GZZX_SBH; }
            set { _MES_SY_GZZX_SBH = value; }
        }
        private int _SBHCOUNT;

        public int SBHCOUNT
        {
            get { return _SBHCOUNT; }
            set { _SBHCOUNT = value; }
        }
        private MES_SY_TYPEMXLIST[] _MES_SY_TYPEMXLIST_CPZT;

        public MES_SY_TYPEMXLIST[] MES_SY_TYPEMXLIST_CPZT
        {
            get { return _MES_SY_TYPEMXLIST_CPZT; }
            set { _MES_SY_TYPEMXLIST_CPZT = value; }
        }
        private MES_SY_TYPEMXLIST[] _MES_SY_TYPEMXLIST_ZFLB;

        public MES_SY_TYPEMXLIST[] MES_SY_TYPEMXLIST_ZFLB
        {
            get { return _MES_SY_TYPEMXLIST_ZFLB; }
            set { _MES_SY_TYPEMXLIST_ZFLB = value; }
        }
        private MES_SY_TYPEMXLIST[] _MES_SY_TYPEMXLIST_TSFH;

        public MES_SY_TYPEMXLIST[] MES_SY_TYPEMXLIST_TSFH
        {
            get { return _MES_SY_TYPEMXLIST_TSFH; }
            set { _MES_SY_TYPEMXLIST_TSFH = value; }
        }
    }
}