using Sonluk.UI.Model.MES;
using Sonluk.UI.Model.MES.MES_TPMService;
using Sonluk.UI.Model.MES.MM_CKService;
using Sonluk.UI.Model.MES.PD_SCRWService;
using Sonluk.UI.Model.MES.ROLE_ASSEMBLEService;
using Sonluk.UI.Model.MES.ROLE_GZZXService;
using Sonluk.UI.Model.MES.SY_GCService;
using Sonluk.UI.Model.MES.SY_GZZX_SBHService;
using Sonluk.UI.Model.MES.SY_GZZXService;
using Sonluk.UI.Model.MES.SY_MACHINEINFOService;
using Sonluk.UI.Model.MES.SY_MATERIAL_GROUPService;
using Sonluk.UI.Model.MES.SY_TYPEMXService;
using Sonluk.UI.Model.MES.SY_TYPEService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.Mobile.Areas.MES.Models
{
    public class MODLE_TPM
    {
        private MES_SY_TYPE[] _sy_type;

        public MES_SY_TYPE[] Sy_type
        {
            get { return _sy_type; }
            set { _sy_type = value; }
        }
        private MES_SY_GC[] _sy_gc;

        public MES_SY_GC[] Sy_gc
        {
            get { return _sy_gc; }
            set { _sy_gc = value; }
        }
        private MES_SY_TYPEMX[] _sy_typemx;

        public MES_SY_TYPEMX[] Sy_typemx
        {
            get { return _sy_typemx; }
            set { _sy_typemx = value; }
        }
        private MES_SY_GZZX[] _sy_gzzx;

        public MES_SY_GZZX[] Sy_gzzx
        {
            get { return _sy_gzzx; }
            set { _sy_gzzx = value; }
        }

        private MES_SY_GZZX_SBH[] _sy_gzzx_sbh;

        public MES_SY_GZZX_SBH[] Sy_gzzx_sbh
        {
            get { return _sy_gzzx_sbh; }
            set { _sy_gzzx_sbh = value; }
        }

        private MES_SY_TYPEMXLIST[] _sy_typemxlist;

        public MES_SY_TYPEMXLIST[] Sy_typemxlist
        {
            get { return _sy_typemxlist; }
            set { _sy_typemxlist = value; }
        }

        private MES_ROLE_ASSEMBLE[] _role_assemble;

        public MES_ROLE_ASSEMBLE[] Role_assemble
        {
            get { return _role_assemble; }
            set { _role_assemble = value; }
        }
        private MES_ROLE_ASSEMBLE_SELECT _role_assemble_select;

        public MES_ROLE_ASSEMBLE_SELECT Role_assemble_select
        {
            get { return _role_assemble_select; }
            set { _role_assemble_select = value; }
        }
        private MES_SY_MATERIAL_GROUP_SELECT _sy_material_group_select;

        public MES_SY_MATERIAL_GROUP_SELECT Sy_material_group_select
        {
            get { return _sy_material_group_select; }
            set { _sy_material_group_select = value; }
        }
        private MES_SY_GZZX_SBH _MES_SY_GZZX_SBH;

        public MES_SY_GZZX_SBH MES_SY_GZZX_SBH
        {
            get { return _MES_SY_GZZX_SBH; }
            set { _MES_SY_GZZX_SBH = value; }
        }
        private SELECT_MES_PD_SCRW _select_mes_pd_scrw;

        public SELECT_MES_PD_SCRW Select_mes_pd_scrw
        {
            get { return _select_mes_pd_scrw; }
            set { _select_mes_pd_scrw = value; }
        }
        private PUBLIC_FUNC _PUBLIC_FUNC;

        public PUBLIC_FUNC PUBLIC_FUNC
        {
            get { return _PUBLIC_FUNC; }
            set { _PUBLIC_FUNC = value; }
        }
        private MES_SY_FJ_RWKB_SELECT _mes_sy_fj_rwkb_select;

        public MES_SY_FJ_RWKB_SELECT Mes_sy_fj_rwkb_select
        {
            get { return _mes_sy_fj_rwkb_select; }
            set { _mes_sy_fj_rwkb_select = value; }
        }
        private MES_MM_CK_SELECT _MES_MM_CK_SELECT;

        public MES_MM_CK_SELECT MES_MM_CK_SELECT
        {
            get { return _MES_MM_CK_SELECT; }
            set { _MES_MM_CK_SELECT = value; }
        }
        private ZBCFUN_TP_ZHM_GL _ZBCFUN_TP_ZHM_GL;

        public ZBCFUN_TP_ZHM_GL ZBCFUN_TP_ZHM_GL
        {
            get { return _ZBCFUN_TP_ZHM_GL; }
            set { _ZBCFUN_TP_ZHM_GL = value; }
        }
    }
}