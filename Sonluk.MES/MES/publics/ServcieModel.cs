using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sonluk.UI.Model.CRM;
using Sonluk.UI.Model.MES;
using Sonluk.UI.Model.BC;
namespace Sonluk.MES.MES.model
{
    public class ServcieModel
    {
        TM_GL _TM_GL;

        public TM_GL TM_GL
        {
            get
            {
                if (_TM_GL == null)
                {
                    _TM_GL = new TM_GL();
                } return _TM_GL;
            }
            set { _TM_GL = value; }
        }
        PMM_MOULD _PMM_MOULD;

        public PMM_MOULD PMM_MOULD
        {
            get
            {
                if (_PMM_MOULD == null)
                {
                    _PMM_MOULD = new PMM_MOULD();
                } return _PMM_MOULD;
            }
            set { _PMM_MOULD = value; }
        }

        SY_MATERIAL_BZCOUNT _SY_MATERIAL_BZCOUNT;

        public SY_MATERIAL_BZCOUNT SY_MATERIAL_BZCOUNT
        {
            get
            {
                if (_SY_MATERIAL_BZCOUNT == null)
                {
                    _SY_MATERIAL_BZCOUNT = new SY_MATERIAL_BZCOUNT();
                } return _SY_MATERIAL_BZCOUNT;
            }
            set { _SY_MATERIAL_BZCOUNT = value; }
        }
        SY_GZZX_WLLB _SY_GZZX_WLLB;

        public SY_GZZX_WLLB SY_GZZX_WLLB
        {
            get
            {
                if (_SY_GZZX_WLLB == null)
                {
                    _SY_GZZX_WLLB = new SY_GZZX_WLLB();
                } return _SY_GZZX_WLLB;
            }
            set { _SY_GZZX_WLLB = value; }
        }
        SY_STAFF _SY_STAFF;

        public SY_STAFF SY_STAFF
        {
            get
            {
                if (_SY_STAFF == null)
                {
                    _SY_STAFF = new SY_STAFF();
                } return _SY_STAFF;
            }
            set { _SY_STAFF = value; }
        }
        SY_MATERIAL_GROUP _SY_MATERIAL_GROUP;

        public SY_MATERIAL_GROUP SY_MATERIAL_GROUP
        {
            get
            {
                if (_SY_MATERIAL_GROUP == null)
                {
                    _SY_MATERIAL_GROUP = new SY_MATERIAL_GROUP();
                } return _SY_MATERIAL_GROUP;
            }
            set { _SY_MATERIAL_GROUP = value; }
        }
        SY_MATERIAL _SY_MATERIAL;

        public SY_MATERIAL SY_MATERIAL
        {
            get
            {
                if (_SY_MATERIAL == null)
                {
                    _SY_MATERIAL = new SY_MATERIAL();
                } return _SY_MATERIAL;
            }
            set { _SY_MATERIAL = value; }
        }
        MES_WLKCBS _MES_WLKCBS;

        public MES_WLKCBS MES_WLKCBS
        {
            get
            {
                if (_MES_WLKCBS == null)
                {
                    _MES_WLKCBS = new MES_WLKCBS();
                } return _MES_WLKCBS;
            }
            set { _MES_WLKCBS = value; }
        }
        MES_SYNC _MES_SYNC;

        public MES_SYNC MES_SYNC
        {
            get
            {
                if (_MES_SYNC == null)
                {
                    _MES_SYNC = new MES_SYNC();
                } return _MES_SYNC;
            }
            set { _MES_SYNC = value; }
        }

        MM_CK _MM_CK;

        public MM_CK MM_CK
        {
            get
            {
                if (_MM_CK == null)
                {
                    _MM_CK = new MM_CK();
                } return _MM_CK;
            }
            set { _MM_CK = value; }
        }


        SY_PFDH_WL _SY_PFDH_WL;

        public SY_PFDH_WL SY_PFDH_WL
        {
            get
            {
                if (_SY_PFDH_WL == null)
                {
                    _SY_PFDH_WL = new SY_PFDH_WL();
                } return _SY_PFDH_WL;
            }
            set { _SY_PFDH_WL = value; }
        }
        SY_PFDH _SY_PFDH;

        public SY_PFDH SY_PFDH
        {
            get
            {
                if (_SY_PFDH == null)
                {
                    _SY_PFDH = new SY_PFDH();
                } return _SY_PFDH;
            }
            set { _SY_PFDH = value; }
        }
        PUBLIC_FUNC _PUBLIC_FUNC;

        public PUBLIC_FUNC PUBLIC_FUNC
        {
            get
            {
                if (_PUBLIC_FUNC == null)
                {
                    _PUBLIC_FUNC = new PUBLIC_FUNC();
                } return _PUBLIC_FUNC;
            }
            set { _PUBLIC_FUNC = value; }
        }
        PD_TLGL _PD_TLGL;

        public PD_TLGL PD_TLGL
        {
            get
            {
                if (_PD_TLGL == null)
                {
                    _PD_TLGL = new PD_TLGL();
                } return _PD_TLGL;
            }
            set { _PD_TLGL = value; }
        }

     
        BarCode _BarCode;

        public BarCode BarCode
        {
            get
            {
                if (_BarCode == null)
                {
                    _BarCode = new BarCode();
                } return _BarCode;
            }
            set { _BarCode = value; }
        }
        TM_CZR _TM_CZR;

        public TM_CZR TM_CZR
        {
            get
            {
                if (_TM_CZR == null)
                {
                    _TM_CZR = new TM_CZR();
                } return _TM_CZR;
            }
            set { _TM_CZR = value; }
        }
        TM_TMINFO _TM_TMINFO;

        public TM_TMINFO TM_TMINFO
        {
            get
            {
                if (_TM_TMINFO == null)
                {
                    _TM_TMINFO = new TM_TMINFO();
                } return _TM_TMINFO;
            }
            set { _TM_TMINFO = value; }
        }
        MES_Login _MES_Login;

        public MES_Login MES_Login
        {
            get
            {
                if (_MES_Login == null)
                {
                    _MES_Login = new MES_Login();
                } return _MES_Login;
            }
            set { _MES_Login = value; }
        }
        PD_GD _PD_GD;

        public PD_GD PD_GD
        {
            get
            {
                if (_PD_GD == null)
                {
                    _PD_GD = new PD_GD();
                } return _PD_GD;
            }
            set { _PD_GD = value; }
        }
        PD_SCRW _PD_SCRW;

        public PD_SCRW PD_SCRW
        {
            get
            {
                if (_PD_SCRW == null)
                {
                    _PD_SCRW = new PD_SCRW();
                } return _PD_SCRW;
            }
            set { _PD_SCRW = value; }
        }

        SY_TYPEMX _SY_TYPEMX;

        public SY_TYPEMX SY_TYPEMX
        {
            get
            {
                if (_SY_TYPEMX == null)
                {
                    _SY_TYPEMX = new SY_TYPEMX();
                } return _SY_TYPEMX;
            }
            set { _SY_TYPEMX = value; }
        }
        CRM_Login _CRM_Login;

        public CRM_Login CRM_Login
        {
            get
            {
                if (_CRM_Login == null)
                {
                    _CRM_Login = new CRM_Login();
                } return _CRM_Login;
            }
            set { _CRM_Login = value; }
        }
        SY_GC _SY_GC;

        public SY_GC SY_GC
        {
            get
            {
                if (_SY_GC == null)
                {
                    _SY_GC = new SY_GC();
                } return _SY_GC;
            }
            set { _SY_GC = value; }
        }
        SY_MACHINEINFO _SY_MACHINEINFO;

        public SY_MACHINEINFO SY_MACHINEINFO
        {
            get
            {
                if (_SY_MACHINEINFO == null)
                {
                    _SY_MACHINEINFO = new SY_MACHINEINFO();
                } return _SY_MACHINEINFO;
            }
            set { _SY_MACHINEINFO = value; }
        }
        SY_TYPE _SY_TYPE;

        public SY_TYPE SY_TYPE
        {
            get
            {
                if (_SY_TYPE == null)
                {
                    _SY_TYPE = new SY_TYPE();
                } return _SY_TYPE;
            }
            set { _SY_TYPE = value; }
        }
        SY_GZZX _SY_GZZX;

        public SY_GZZX SY_GZZX
        {
            get
            {
                if (_SY_GZZX == null)
                {
                    _SY_GZZX = new SY_GZZX();
                } return _SY_GZZX;
            }
            set { _SY_GZZX = value; }
        }
        SY_GZZX_SBH _SY_GZZX_SBH;

        public SY_GZZX_SBH SY_GZZX_SBH
        {
            get
            {
                if (_SY_GZZX_SBH == null)
                {
                    _SY_GZZX_SBH = new SY_GZZX_SBH();
                } return _SY_GZZX_SBH;
            }
            set { _SY_GZZX_SBH = value; }
        }

    }
}
