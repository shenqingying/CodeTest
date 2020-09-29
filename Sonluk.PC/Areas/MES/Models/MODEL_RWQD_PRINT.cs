using Sonluk.UI.Model.MES.MES_TPMService;
using Sonluk.UI.Model.MES.PD_GDService;
using Sonluk.UI.Model.MES.PD_SCRWService;
using Sonluk.UI.Model.MES.SY_GZZX_SBHService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.PC.Areas.MES.Models
{
    public class MODEL_RWQD_PRINT
    {
        private MES_PD_SCRW_LIST _MES_PD_SCRW_LIST;

        public MES_PD_SCRW_LIST MES_PD_SCRW_LIST
        {
            get { return _MES_PD_SCRW_LIST; }
            set { _MES_PD_SCRW_LIST = value; }
        }

        private ZBCFUN_GDJGXX_READ _ZBCFUN_GDJGXX_READ;

        public ZBCFUN_GDJGXX_READ ZBCFUN_GDJGXX_READ
        {
            get { return _ZBCFUN_GDJGXX_READ; }
            set { _ZBCFUN_GDJGXX_READ = value; }
        }
        private MES_SY_GZZX_SBH _MES_SY_GZZX_SBH;

        public MES_SY_GZZX_SBH MES_SY_GZZX_SBH
        {
            get { return _MES_SY_GZZX_SBH; }
            set { _MES_SY_GZZX_SBH = value; }
        }
        private ZSL_BCS025 _ZSL_BCS025;

        public ZSL_BCS025 ZSL_BCS025
        {
            get { return _ZSL_BCS025; }
            set { _ZSL_BCS025 = value; }
        }
        private ZSL_BCT012 _ZSL_BCT012;

        public ZSL_BCT012 ZSL_BCT012
        {
            get { return _ZSL_BCT012; }
            set { _ZSL_BCT012 = value; }
        }
        private ZSL_BCT011 _ZSL_BCT011;

        public ZSL_BCT011 ZSL_BCT011
        {
            get { return _ZSL_BCT011; }
            set { _ZSL_BCT011 = value; }
        }
        private ZSL_BCT012[] _zsl_bct012;

        public ZSL_BCT012[] Zsl_bct012
        {
            get { return _zsl_bct012; }
            set { _zsl_bct012 = value; }
        }
    }
}