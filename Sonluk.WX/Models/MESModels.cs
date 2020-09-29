﻿using Sonluk.UI.Model.BC;
using Sonluk.UI.Model.MES;
using Sonluk.UI.Model.MES.SY_MATERIALService;
using Sonluk.UI.Model.MES.SY_PFDH_WLService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.WX.Models
{
    public class MESModels
    {
        MES_MM _MES_MM;

        public MES_MM MES_MM
        {
            get
            {
                if (_MES_MM == null)
                {
                    _MES_MM = new MES_MM();
                } return _MES_MM;
            }
            set { _MES_MM = value; }
        }

        private SY_TYPE _SY_TYPE;

        public SY_TYPE SY_TYPE
        {
            get
            {
                if (_SY_TYPE == null)
                    _SY_TYPE = new SY_TYPE();
                return _SY_TYPE;
            }
            set { _SY_TYPE = value; }
        }

        private SY_TYPEMX _SY_TYPEMX;

        public SY_TYPEMX SY_TYPEMX
        {
            get
            {
                if (_SY_TYPEMX == null)
                    _SY_TYPEMX = new SY_TYPEMX();
                return _SY_TYPEMX;
            }
            set { _SY_TYPEMX = value; }
        }

        private SY_GC _SY_GC;

        public SY_GC SY_GC
        {
            get
            {
                if (_SY_GC == null)
                    _SY_GC = new SY_GC();
                return _SY_GC;
            }
            set { _SY_GC = value; }
        }

        private SY_GZZX _SY_GZZX;
        public SY_GZZX SY_GZZX
        {
            get
            {
                if (_SY_GZZX == null)
                    _SY_GZZX = new SY_GZZX();
                return _SY_GZZX;
            }
            set { _SY_GZZX = value; }
        }

        private SY_GZZX_SBH _SY_GZZX_SBH;

        public SY_GZZX_SBH SY_GZZX_SBH
        {
            get
            {
                if (_SY_GZZX_SBH == null)
                    _SY_GZZX_SBH = new SY_GZZX_SBH();
                return _SY_GZZX_SBH;
            }
            set { _SY_GZZX_SBH = value; }
        }

        private SY_GZZX_SBH_WLLB _SY_GZZX_SBH_WLLB;

        public SY_GZZX_SBH_WLLB SY_GZZX_SBH_WLLB
        {
            get
            {
                if (_SY_GZZX_SBH_WLLB == null)
                    _SY_GZZX_SBH_WLLB = new SY_GZZX_SBH_WLLB();
                return _SY_GZZX_SBH_WLLB;
            }
            set { _SY_GZZX_SBH_WLLB = value; }
        }

        private ROLE_GZZX _ROLE_GZZX;

        public ROLE_GZZX ROLE_GZZX
        {
            get
            {
                if (_ROLE_GZZX == null)
                    _ROLE_GZZX = new ROLE_GZZX();
                return _ROLE_GZZX;
            }
            set { _ROLE_GZZX = value; }
        }
        private ROLE_ASSEMBLE _ROLE_ASSEMBLE;

        public ROLE_ASSEMBLE ROLE_ASSEMBLE
        {
            get
            {
                if (_ROLE_ASSEMBLE == null)
                    _ROLE_ASSEMBLE = new ROLE_ASSEMBLE();
                return _ROLE_ASSEMBLE;
            }
            set { _ROLE_ASSEMBLE = value; }
        }
        private ROLR_GZZX_GW _ROLR_GZZX_GW;

        public ROLR_GZZX_GW ROLR_GZZX_GW
        {
            get
            {
                if (_ROLR_GZZX_GW == null)
                    _ROLR_GZZX_GW = new ROLR_GZZX_GW();
                return _ROLR_GZZX_GW;
            }
            set { _ROLR_GZZX_GW = value; }
        }
        private ROLE_CK _ROLE_CK;

        public ROLE_CK ROLE_CK
        {
            get
            {
                if (_ROLE_CK == null)
                    _ROLE_CK = new ROLE_CK();
                return _ROLE_CK;
            }
            set { _ROLE_CK = value; }
        }
        private SY_GZZX_WLLB _SY_GZZX_WLLB;
        public SY_GZZX_WLLB SY_GZZX_WLLB
        {
            get
            {
                if (_SY_GZZX_WLLB == null)
                    _SY_GZZX_WLLB = new SY_GZZX_WLLB();
                return _SY_GZZX_WLLB;
            }
            set { _SY_GZZX_WLLB = value; }
        }
        private PD_GD _PD_GD;

        public PD_GD PD_GD
        {
            get
            {
                if (_PD_GD == null)
                    _PD_GD = new PD_GD();
                return _PD_GD;
            }
            set { _PD_GD = value; }
        }

        private PD_SCRW _PD_SCRW;

        public PD_SCRW PD_SCRW
        {
            get
            {
                if (_PD_SCRW == null)
                    _PD_SCRW = new PD_SCRW();
                return _PD_SCRW;
            }
            set { _PD_SCRW = value; }
        }
        private SY_PFDH _SY_PFDH;

        public SY_PFDH SY_PFDH
        {
            get
            {
                if (_SY_PFDH == null)
                    _SY_PFDH = new SY_PFDH();
                return _SY_PFDH;
            }
            set { _SY_PFDH = value; }
        }
        private SY_PFDH_WL _SY_PFDH_WL;

        public SY_PFDH_WL SY_PFDH_WL
        {
            get
            {
                if (_SY_PFDH_WL == null)
                    _SY_PFDH_WL = new SY_PFDH_WL();
                return _SY_PFDH_WL;

            }
            set { _SY_PFDH_WL = value; }
        }
        private SY_DCXH_COUNT _SY_DCXH_COUNT;

        public SY_DCXH_COUNT SY_DCXH_COUNT
        {
            get
            {
                if (_SY_DCXH_COUNT == null)
                    _SY_DCXH_COUNT = new SY_DCXH_COUNT();
                return _SY_DCXH_COUNT;
            }
            set { _SY_DCXH_COUNT = value; }
        }
        private SY_MATERIAL_GROUP _SY_MATERIAL_GROUP;

        public SY_MATERIAL_GROUP SY_MATERIAL_GROUP
        {
            get
            {
                if (_SY_MATERIAL_GROUP == null)
                    _SY_MATERIAL_GROUP = new SY_MATERIAL_GROUP();
                return _SY_MATERIAL_GROUP;
            }
            set { _SY_MATERIAL_GROUP = value; }
        }
        private SY_MATERIAL _SY_MATERIAL;

        public SY_MATERIAL SY_MATERIAL
        {
            get
            {
                if (_SY_MATERIAL == null)
                    _SY_MATERIAL = new SY_MATERIAL();
                return _SY_MATERIAL;
            }
            set { _SY_MATERIAL = value; }
        }
        private MES_SYNC _MES_SYNC;

        public MES_SYNC MES_SYNC
        {
            get
            {
                if (_MES_SYNC == null)
                    _MES_SYNC = new MES_SYNC();
                return _MES_SYNC;
            }
            set { _MES_SYNC = value; }
        }
        private MES_FJ _MES_FJ;

        public MES_FJ MES_FJ
        {
            get
            {
                if (_MES_FJ == null)
                    _MES_FJ = new MES_FJ();
                return _MES_FJ;
            }
            set { _MES_FJ = value; }
        }

        private MM_CK _MM_CK;

        public MM_CK MM_CK
        {
            get
            {
                if (_MM_CK == null)
                    _MM_CK = new MM_CK();
                return _MM_CK;
            }
            set { _MM_CK = value; }
        }

        private TM_TMINFO _TM_TMINFO;

        public TM_TMINFO TM_TMINFO
        {
            get
            {
                if (_TM_TMINFO == null)
                    _TM_TMINFO = new TM_TMINFO();
                return _TM_TMINFO;
            }
            set { _TM_TMINFO = value; }
        }

        private BarCode _BarCode;
        public BarCode BarCode
        {
            get
            {
                if (_BarCode == null)
                    _BarCode = new BarCode();
                return _BarCode;
            }
            set { _BarCode = value; }
        }

        private SY_STAFF _SY_STAFF;

        public SY_STAFF SY_STAFF
        {
            get
            {
                if (_SY_STAFF == null)
                    _SY_STAFF = new SY_STAFF();
                return _SY_STAFF;
            }
            set { _SY_STAFF = value; }
        }

        private ROLE_GC _ROLE_GC;

        public ROLE_GC ROLE_GC
        {
            get
            {
                if (_ROLE_GC == null)
                    _ROLE_GC = new ROLE_GC();
                return _ROLE_GC;
            }
            set { _ROLE_GC = value; }
        }

        private ROLE_RY_ASSEMBLE _ROLE_RY_ASSEMBLE;

        public ROLE_RY_ASSEMBLE ROLE_RY_ASSEMBLE
        {
            get
            {
                if (_ROLE_RY_ASSEMBLE == null)
                    _ROLE_RY_ASSEMBLE = new ROLE_RY_ASSEMBLE();
                return _ROLE_RY_ASSEMBLE;
            }
            set { _ROLE_RY_ASSEMBLE = value; }
        }

        private PD_TL_ERROR _PD_TL_ERROR;

        public PD_TL_ERROR PD_TL_ERROR
        {
            get
            {
                if (_PD_TL_ERROR == null)
                    _PD_TL_ERROR = new PD_TL_ERROR();
                return _PD_TL_ERROR;
            }
            set { _PD_TL_ERROR = value; }
        }

        private PD_TLGL _PD_TLGL;

        public PD_TLGL PD_TLGL
        {
            get
            {
                if (_PD_TLGL == null)
                    _PD_TLGL = new PD_TLGL();
                return _PD_TLGL;
            }
            set { _PD_TLGL = value; }
        }
        private SY_MATERIAL_BZCOUNT _SY_MATERIAL_BZCOUNT;

        public SY_MATERIAL_BZCOUNT SY_MATERIAL_BZCOUNT
        {
            get
            {
                if (_SY_MATERIAL_BZCOUNT == null)
                    _SY_MATERIAL_BZCOUNT = new SY_MATERIAL_BZCOUNT();
                return _SY_MATERIAL_BZCOUNT;
            }
            set { _SY_MATERIAL_BZCOUNT = value; }
        }

        private TM_ZFDCMX _TM_ZFDCMX;

        public TM_ZFDCMX TM_ZFDCMX
        {
            get
            {
                if (_TM_ZFDCMX == null)
                    _TM_ZFDCMX = new TM_ZFDCMX();
                return _TM_ZFDCMX;
            }
            set { _TM_ZFDCMX = value; }
        }
        private SY_PLDH _SY_PLDH;

        public SY_PLDH SY_PLDH
        {
            get
            {
                if (_SY_PLDH == null)
                    _SY_PLDH = new SY_PLDH();
                return _SY_PLDH;
            }
            set { _SY_PLDH = value; }
        }
        private SY_PFDH_CHILD _SY_PFDH_CHILD;

        public SY_PFDH_CHILD SY_PFDH_CHILD
        {
            get
            {
                if (_SY_PFDH_CHILD == null)
                    _SY_PFDH_CHILD = new SY_PFDH_CHILD();

                return _SY_PFDH_CHILD;
            }
            set { _SY_PFDH_CHILD = value; }
        }
        private PD_GD_BOM _PD_GD_BOM;

        public PD_GD_BOM PD_GD_BOM
        {
            get
            {
                if (_PD_GD_BOM == null)
                    _PD_GD_BOM = new PD_GD_BOM();
                return _PD_GD_BOM;
            }
            set { _PD_GD_BOM = value; }
        }
        private SY_MACHINEINFO _SY_MACHINEINFO;

        public SY_MACHINEINFO SY_MACHINEINFO
        {
            get
            {
                if (_SY_MACHINEINFO == null)
                    _SY_MACHINEINFO = new SY_MACHINEINFO();
                return _SY_MACHINEINFO;
            }
            set { _SY_MACHINEINFO = value; }
        }
        private SY_CHANGEINFO _SY_CHANGEINFO;

        public SY_CHANGEINFO SY_CHANGEINFO
        {
            get
            {
                if (_SY_CHANGEINFO == null)
                {
                    _SY_CHANGEINFO = new SY_CHANGEINFO();
                } return _SY_CHANGEINFO;
            }
            set { _SY_CHANGEINFO = value; }
        }
        private PUBLIC_FUNC _PUBLIC_FUNC;

        public PUBLIC_FUNC PUBLIC_FUNC
        {
            get
            {
                if (_PUBLIC_FUNC == null)
                    _PUBLIC_FUNC = new PUBLIC_FUNC();
                return _PUBLIC_FUNC;
            }
            set { _PUBLIC_FUNC = value; }
        }
        private MES_TPM _MES_TPM;

        public MES_TPM MES_TPM
        {
            get
            {
                if (_MES_TPM == null)
                    _MES_TPM = new MES_TPM();
                return _MES_TPM;
            }
            set { _MES_TPM = value; }
        }

        private SY_SCDATE_TH _SY_SCDATE_TH;

        public SY_SCDATE_TH SY_SCDATE_TH
        {
            get
            {
                if (_SY_SCDATE_TH == null)
                    _SY_SCDATE_TH = new SY_SCDATE_TH();
                return _SY_SCDATE_TH;
            }
            set { _SY_SCDATE_TH = value; }
        }
    }
}