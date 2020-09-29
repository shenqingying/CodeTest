using Sonluk.UI.Model.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.PC.Models
{
    public class HRModels
    {
        private SY_GS _SY_GS;

        public SY_GS SY_GS
        {
            get
            {
                if (_SY_GS == null)
                    _SY_GS = new SY_GS();
                return _SY_GS;
            }
            set { _SY_GS = value; }
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
        private SY_DEPT _SY_DEPT;

        public SY_DEPT SY_DEPT
        {
            get
            {
                if (_SY_DEPT == null)
                {
                    _SY_DEPT = new SY_DEPT();
                } return _SY_DEPT;
            }
            set { _SY_DEPT = value; }
        }
        private GS_GSSL _GS_GSSL;

        public GS_GSSL GS_GSSL
        {
            get
            {
                if (_GS_GSSL == null)
                    _GS_GSSL = new GS_GSSL();
                return _GS_GSSL;
            }
            set { _GS_GSSL = value; }
        }
        private SY_DUTY _SY_DUTY;

        public SY_DUTY SY_DUTY
        {
            get
            {
                if (_SY_DUTY == null)
                    _SY_DUTY = new SY_DUTY();
                return _SY_DUTY;
            }
            set { _SY_DUTY = value; }
        }
        private XZGL_FLFA _XZGL_FLFA;

        public XZGL_FLFA XZGL_FLFA
        {
            get
            {
                if (_XZGL_FLFA == null)
                    _XZGL_FLFA = new XZGL_FLFA();
                return _XZGL_FLFA;
            }
            set { _XZGL_FLFA = value; }
        }
        private XZGL_FLFAMX _XZGL_FLFAMX;

        public XZGL_FLFAMX XZGL_FLFAMX
        {
            get
            {
                if (_XZGL_FLFAMX == null)
                    _XZGL_FLFAMX = new XZGL_FLFAMX();
                return _XZGL_FLFAMX;
            }
            set { _XZGL_FLFAMX = value; }
        }
        private RY_RYINFO _RY_RYINFO;

        public RY_RYINFO RY_RYINFO
        {
            get
            {
                if (_RY_RYINFO == null)
                    _RY_RYINFO = new RY_RYINFO();
                return _RY_RYINFO;
            }
            set { _RY_RYINFO = value; }
        }
        private XZGL_XZDA_GZLB _XZGL_XZDA_GZLB;

        public XZGL_XZDA_GZLB XZGL_XZDA_GZLB
        {
            get
            {
                if (_XZGL_XZDA_GZLB == null)
                    _XZGL_XZDA_GZLB = new XZGL_XZDA_GZLB();
                return _XZGL_XZDA_GZLB;
            }
            set { _XZGL_XZDA_GZLB = value; }
        }
        private XZGL_FFJLZD _XZGL_FFJLZD;

        public XZGL_FFJLZD XZGL_FFJLZD
        {
            get
            {
                if (_XZGL_FFJLZD == null)
                    _XZGL_FFJLZD = new XZGL_FFJLZD();
                return _XZGL_FFJLZD;
            }
            set { _XZGL_FFJLZD = value; }
        }
        private SY_MYINFO _SY_MYINFO;

        public SY_MYINFO SY_MYINFO
        {
            get
            {
                if (_SY_MYINFO == null)
                    _SY_MYINFO = new SY_MYINFO();
                return _SY_MYINFO;
            }
            set { _SY_MYINFO = value; }
        }
        private XZGL_XZDA _XZGL_XZDA;

        public XZGL_XZDA XZGL_XZDA
        {
            get
            {
                if (_XZGL_XZDA == null)
                    _XZGL_XZDA = new XZGL_XZDA();
                return _XZGL_XZDA;
            }
            set { _XZGL_XZDA = value; }
        }

        XZGL_ZXFJKC _XZGL_ZXFJKC;

        public XZGL_ZXFJKC XZGL_ZXFJKC
        {
            get
            {
                if (_XZGL_ZXFJKC == null)
                    _XZGL_ZXFJKC = new XZGL_ZXFJKC();
                return _XZGL_ZXFJKC;
            }
            set { _XZGL_ZXFJKC = value; }
        }

        XZGL_FLDA _XZGL_FLDA;

        public XZGL_FLDA XZGL_FLDA
        {
            get
            {
                if (_XZGL_FLDA == null)
                    _XZGL_FLDA = new XZGL_FLDA();
                return _XZGL_FLDA;
            }
            set { _XZGL_FLDA = value; }
        }

        KQ_JQGL _KQ_JQGL;

        public KQ_JQGL KQ_JQGL
        {
            get
            {
                if (_KQ_JQGL == null)
                    _KQ_JQGL = new KQ_JQGL();
                return _KQ_JQGL;
            }
            set { _KQ_JQGL = value; }
        }

        KQ_JQGLMX _KQ_JQGLMX;

        public KQ_JQGLMX KQ_JQGLMX
        {
            get
            {
                if (_KQ_JQGLMX == null)
                    _KQ_JQGLMX = new KQ_JQGLMX();
                return _KQ_JQGLMX;
            }
            set { _KQ_JQGLMX = value; }
        }

        RY_BANKNO _RY_BANKNO;

        public RY_BANKNO RY_BANKNO
        {
            get
            {
                if (_RY_BANKNO == null)
                    _RY_BANKNO = new RY_BANKNO();
                return _RY_BANKNO;
            }
            set { _RY_BANKNO = value; }
        }
        private XZGL_MBGL _XZGL_MBGL;

        public XZGL_MBGL XZGL_MBGL
        {
            get
            {
                if (_XZGL_MBGL == null)
                    _XZGL_MBGL = new XZGL_MBGL();
                return _XZGL_MBGL;
            }
            set { _XZGL_MBGL = value; }
        }
        private XZGL_MBGLMX _XZGL_MBGLMX;

        public XZGL_MBGLMX XZGL_MBGLMX
        {
            get
            {
                if (_XZGL_MBGLMX == null)
                    _XZGL_MBGLMX = new XZGL_MBGLMX();
                return _XZGL_MBGLMX;
            }
            set { _XZGL_MBGLMX = value; }
        }

        XZGL_FLDATZ _XZGL_FLDATZ;

        public XZGL_FLDATZ XZGL_FLDATZ
        {
            get
            {
                if (_XZGL_FLDATZ == null)
                    _XZGL_FLDATZ = new XZGL_FLDATZ();
                return _XZGL_FLDATZ;
            }
            set { _XZGL_FLDATZ = value; }
        }

        XZGL_FLDATZMX _XZGL_FLDATZMX;

        public XZGL_FLDATZMX XZGL_FLDATZMX
        {
            get
            {
                if (_XZGL_FLDATZMX == null)
                    _XZGL_FLDATZMX = new XZGL_FLDATZMX();
                return _XZGL_FLDATZMX;
            }
            set { _XZGL_FLDATZMX = value; }
        }

        XZGL_KKGL _XZGL_KKGL;

        public XZGL_KKGL XZGL_KKGL
        {
            get
            {
                if (_XZGL_KKGL == null)
                    _XZGL_KKGL = new XZGL_KKGL();
                return _XZGL_KKGL;
            }
            set { _XZGL_KKGL = value; }
        }

        XZGL_KKGLMX _XZGL_KKGLMX;

        public XZGL_KKGLMX XZGL_KKGLMX
        {
            get
            {
                if (_XZGL_KKGLMX == null)
                    _XZGL_KKGLMX = new XZGL_KKGLMX();
                return _XZGL_KKGLMX;
            }
            set { _XZGL_KKGLMX = value; }
        }

        private XZGL_FFJL _XZGL_FFJL;

        public XZGL_FFJL XZGL_FFJL
        {
            get
            {
                if (_XZGL_FFJL == null)
                    _XZGL_FFJL = new XZGL_FFJL();
                return _XZGL_FFJL;
            }
            set { _XZGL_FFJL = value; }
        }

        private XZGL_FFJLMX _XZGL_FFJLMX;

        public XZGL_FFJLMX XZGL_FFJLMX
        {
            get
            {
                if (_XZGL_FFJLMX == null)
                    _XZGL_FFJLMX = new XZGL_FFJLMX();
                return _XZGL_FFJLMX;
            }
            set { _XZGL_FFJLMX = value; }
        }
        private GS_LY _GS_LY;

        public GS_LY GS_LY
        {
            get
            {
                if (_GS_LY == null)
                    _GS_LY = new GS_LY();
                return _GS_LY;
            }
            set { _GS_LY = value; }
        }
        private SY_ZJH _SY_ZJH;

        public SY_ZJH SY_ZJH
        {
            get
            {
                if (_SY_ZJH == null)
                    _SY_ZJH = new SY_ZJH();
                return _SY_ZJH;
            }
            set { _SY_ZJH = value; }
        }
        private XZGL_ZDGLGL _XZGL_ZDGLGL;

        public XZGL_ZDGLGL XZGL_ZDGLGL
        {
            get
            {
                if (_XZGL_ZDGLGL == null)
                    _XZGL_ZDGLGL = new XZGL_ZDGLGL();
                return _XZGL_ZDGLGL;
            }
            set { _XZGL_ZDGLGL = value; }
        }
        private ROLE_DEPT _ROLE_DEPT;

        public ROLE_DEPT ROLE_DEPT
        {
            get
            {
                if (_ROLE_DEPT == null)
                    _ROLE_DEPT = new ROLE_DEPT();
                return _ROLE_DEPT;
            }
            set { _ROLE_DEPT = value; }
        }
        private RY_RYINFO_RSDA _RY_RYINFO_RSDA;

        public RY_RYINFO_RSDA RY_RYINFO_RSDA
        {
            get
            {
                if (_RY_RYINFO_RSDA == null)
                    _RY_RYINFO_RSDA = new RY_RYINFO_RSDA();
                return _RY_RYINFO_RSDA;
            }
            set { _RY_RYINFO_RSDA = value; }
        }
        private KQ_BD _KQ_BD;

        public KQ_BD KQ_BD
        {
            get
            {
                if (_KQ_BD == null)
                    _KQ_BD = new KQ_BD();
                return _KQ_BD;
            }
            set { _KQ_BD = value; }
        }
        private KQ_DEPTKQ _KQ_DEPTKQ;

        public KQ_DEPTKQ KQ_DEPTKQ
        {
            get
            {
                if (_KQ_DEPTKQ == null)
                    _KQ_DEPTKQ = new KQ_DEPTKQ();
                return _KQ_DEPTKQ;
            }
            set { _KQ_DEPTKQ = value; }
        }
        private KQ_PBFZ _KQ_PBFZ;

        public KQ_PBFZ KQ_PBFZ
        {
            get
            {
                if (_KQ_PBFZ == null)
                    _KQ_PBFZ = new KQ_PBFZ();
                return _KQ_PBFZ;
            }
            set { _KQ_PBFZ = value; }
        }
        private KQ_DEPTID_FZID _KQ_DEPTID_FZID;

        public KQ_DEPTID_FZID KQ_DEPTID_FZID
        {
            get
            {
                if (_KQ_DEPTID_FZID == null)
                    _KQ_DEPTID_FZID = new KQ_DEPTID_FZID();
                return _KQ_DEPTID_FZID;
            }
            set { _KQ_DEPTID_FZID = value; }
        }
        private KQ_PBFZ_BZID _KQ_PBFZ_BZID;

        public KQ_PBFZ_BZID KQ_PBFZ_BZID
        {
            get
            {
                if (_KQ_PBFZ_BZID == null)
                    _KQ_PBFZ_BZID = new KQ_PBFZ_BZID();
                return _KQ_PBFZ_BZID;
            }
            set { _KQ_PBFZ_BZID = value; }
        }
        private KQ_BZ _KQ_BZ;

        public KQ_BZ KQ_BZ
        {
            get
            {
                if (_KQ_BZ == null)
                    _KQ_BZ = new KQ_BZ();
                return _KQ_BZ;
            }
            set { _KQ_BZ = value; }
        }
        private PX_PXZT _PX_PXZT;
        public PX_PXZT PX_PXZT
        {
            get
            {
                if (_PX_PXZT == null)
                    _PX_PXZT = new PX_PXZT();
                return _PX_PXZT;
            }
            set { _PX_PXZT = value; }
        }
        private KQ_BZ_BDID _KQ_BZ_BDID;

        public KQ_BZ_BDID KQ_BZ_BDID
        {
            get
            {
                if (_KQ_BZ_BDID == null)
                    _KQ_BZ_BDID = new KQ_BZ_BDID();
                return _KQ_BZ_BDID;
            }
            set { _KQ_BZ_BDID = value; }
        }
        private KQ_RYID_BZID _KQ_RYID_BZID;

        public KQ_RYID_BZID KQ_RYID_BZID
        {
            get
            {
                if (_KQ_RYID_BZID == null)
                    _KQ_RYID_BZID = new KQ_RYID_BZID();
                return _KQ_RYID_BZID;
            }
            set { _KQ_RYID_BZID = value; }
        }
        private KQ_WCDJ _KQ_WCDJ;

        public KQ_WCDJ KQ_WCDJ
        {
            get
            {
                if (_KQ_WCDJ == null)
                    _KQ_WCDJ = new KQ_WCDJ();
                return _KQ_WCDJ;
            }
            set { _KQ_WCDJ = value; }
        }
        private DA_DAINFO _DA_DAINFO;

        public DA_DAINFO DA_DAINFO
        {
            get
            {
                if (_DA_DAINFO == null)
                    _DA_DAINFO = new DA_DAINFO();
                return _DA_DAINFO;
            }
            set { _DA_DAINFO = value; }
        }
        private KQ_GSKQ _KQ_GSKQ;

        public KQ_GSKQ KQ_GSKQ
        {
            get
            {
                if (_KQ_GSKQ == null)
                    _KQ_GSKQ = new KQ_GSKQ();
                return _KQ_GSKQ;
            }
            set { _KQ_GSKQ = value; }
        }
        private KQ_KQINFO _KQ_KQINFO;

        public KQ_KQINFO KQ_KQINFO
        {
            get
            {
                if (_KQ_KQINFO == null)
                    _KQ_KQINFO = new KQ_KQINFO();
                return _KQ_KQINFO;
            }
            set { _KQ_KQINFO = value; }
        }
        private BOOK_BOOKINFO _BOOK_BOOKINFO;

        public BOOK_BOOKINFO BOOK_BOOKINFO
        {
            get
            {
                if (_BOOK_BOOKINFO == null)
                    _BOOK_BOOKINFO = new BOOK_BOOKINFO();
                return _BOOK_BOOKINFO;
            }
            set { _BOOK_BOOKINFO = value; }
        }
        private KQ_YCKQ _KQ_YCKQ;

        public KQ_YCKQ KQ_YCKQ
        {
            get
            {
                if (_KQ_YCKQ == null)
                    _KQ_YCKQ = new KQ_YCKQ();
                return _KQ_YCKQ;
            }
            set { _KQ_YCKQ = value; }
        }
        private XZGL_JJFL_HEARNAME _XZGL_JJFL_HEARNAME;

        public XZGL_JJFL_HEARNAME XZGL_JJFL_HEARNAME
        {
            get
            {
                if (_XZGL_JJFL_HEARNAME == null)
                    _XZGL_JJFL_HEARNAME = new XZGL_JJFL_HEARNAME();
                return _XZGL_JJFL_HEARNAME;
            }
            set { _XZGL_JJFL_HEARNAME = value; }
        }
        private XZGL_JJFL_HEAD _XZGL_JJFL_HEAD;

        public XZGL_JJFL_HEAD XZGL_JJFL_HEAD
        {
            get
            {
                if (_XZGL_JJFL_HEAD == null)
                    _XZGL_JJFL_HEAD = new XZGL_JJFL_HEAD();
                return _XZGL_JJFL_HEAD;
            }
            set { _XZGL_JJFL_HEAD = value; }
        }
        private XZGL_JJFL_MX _XZGL_JJFL_MX;

        public XZGL_JJFL_MX XZGL_JJFL_MX
        {
            get
            {
                if (_XZGL_JJFL_MX == null)
                    _XZGL_JJFL_MX = new XZGL_JJFL_MX();
                return _XZGL_JJFL_MX;
            }
            set { _XZGL_JJFL_MX = value; }
        }
        private KQ_QJ _KQ_QJ;

        public KQ_QJ KQ_QJ
        {
            get
            {
                if (_KQ_QJ == null)
                    _KQ_QJ = new KQ_QJ();
                return _KQ_QJ;
            }
            set { _KQ_QJ = value; }
        }
        private SY_CHANGEINFO _SY_CHANGEINFO;

        public SY_CHANGEINFO SY_CHANGEINFO
        {
            get
            {
                if (_SY_CHANGEINFO == null)
                    _SY_CHANGEINFO = new SY_CHANGEINFO();
                return _SY_CHANGEINFO;
            }
            set { _SY_CHANGEINFO = value; }
        }
        private ADMINISTRATION_YHRY _ADMINISTRATION_YHRY;

        public ADMINISTRATION_YHRY ADMINISTRATION_YHRY
        {
            get
            {
                if (_ADMINISTRATION_YHRY == null)
                    _ADMINISTRATION_YHRY = new ADMINISTRATION_YHRY();
                return _ADMINISTRATION_YHRY;
            }
            set { _ADMINISTRATION_YHRY = value; }
        }
        private ADMINISTRATION_DORM _ADMINISTRATION_DORM;

        public ADMINISTRATION_DORM ADMINISTRATION_DORM
        {
            get
            {
                if (_ADMINISTRATION_DORM == null)
                    _ADMINISTRATION_DORM = new ADMINISTRATION_DORM();
                return _ADMINISTRATION_DORM;
            }
            set { _ADMINISTRATION_DORM = value; }
        }
    }
}