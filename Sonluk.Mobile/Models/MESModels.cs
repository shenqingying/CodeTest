using Sonluk.UI.Model.BC;
using Sonluk.UI.Model.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.Mobile.Models
{
    public class MESModels
    {
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

        private TM_CZR _TM_CZR;

        public TM_CZR TM_CZR
        {
            get
            {
                if (_TM_CZR == null)
                    _TM_CZR = new TM_CZR();
                return _TM_CZR;
            }
            set { _TM_CZR = value; }
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
        private TM_GL _TM_GL;

        public TM_GL TM_GL
        {
            get
            {
                if (_TM_GL == null)
                    _TM_GL = new TM_GL();
                return _TM_GL;
            }
            set { _TM_GL = value; }
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
        private ZS_SY_KU _ZS_SY_KU;

        public ZS_SY_KU ZS_SY_KU
        {
            get
            {
                if (_ZS_SY_KU == null)
                    _ZS_SY_KU = new ZS_SY_KU();
                return _ZS_SY_KU;
            }
            set { _ZS_SY_KU = value; }
        }
        private ZS_QJ_QJJL _ZS_QJ_QJJL;

        public ZS_QJ_QJJL ZS_QJ_QJJL
        {
            get
            {
                if (_ZS_QJ_QJJL == null)
                    _ZS_QJ_QJJL = new ZS_QJ_QJJL();
                return _ZS_QJ_QJJL;
            }
            set { _ZS_QJ_QJJL = value; }
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

        private SY_TYPEMX _SY_TYPEMX;

        public SY_TYPEMX SY_TYPEMX
        {
            get {
                if (_SY_TYPEMX == null)
                    _SY_TYPEMX = new SY_TYPEMX();
                return _SY_TYPEMX; }
            set { _SY_TYPEMX = value; }
        }
        private ZS_SY_JL _ZS_SY_JL;

        public ZS_SY_JL ZS_SY_JL
        {
            get {
                if (_ZS_SY_JL == null)
                    _ZS_SY_JL = new ZS_SY_JL();
                return _ZS_SY_JL; }
            set { _ZS_SY_JL = value; }
        }
    }
}